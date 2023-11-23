using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using NAudio.Gui;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using NAudio.Wave.SampleProviders;
using System.Runtime.CompilerServices;

namespace Playlist
{
    public partial class PlaylistForm : Form
    {
        // Khởi tạo khi mở App
        public PlaylistForm()
        {
            InitializeComponent();

            // Đặt các thuộc tính điều khiển
            PlayerDevice = new WaveOut();
            AutoNext = true;
            Repeating = false;
            VolumeWas = 1;
            MusicBar.Value = 0;
            SpeakerBar.Value = 100;

            // Tải lại những bài hát đã được up lên app
            File.AppendAllText("MusicList", "");
            PathOfFiles = DoublyLinkedList.FromArray(File.ReadAllLines("MusicList"));
            CurrentFile = PathOfFiles.Head;

            // Khởi tạo bài hát đầu tiên
            if (CurrentFile != null)
            {
                PlayerDevice = new WaveOut();
                PlayCurrentFile = new AudioFileReader(CurrentFile.Value.ToString());
                PlayerDevice.Init(PlayCurrentFile);
                PlayCurrentFile.CurrentTime = TimeSpan.Zero;
                MusicBar.Maximum = (int)PlayCurrentFile.TotalTime.TotalSeconds;
                MusicBar.Value = 0;
            }

            DisplayPlayList();
        }

        #region Các thuộc tính điều khiển
        DoublyLinkedList PathOfFiles; // Lưu đường dẫn của các file
        Node CurrentFile; // Lấy đường dẫn của file phát nhạc hiện tại
        IWavePlayer PlayerDevice; // Dùng để điều khiển đầu đọc file âm thanh đang phát
        AudioFileReader PlayCurrentFile; // Đầu đọc file
        bool Repeating; // Lặp lại bài hát hiện tại khi đã phát xong
        bool AutoNext; // Tự động phát bài tiếp theo khi đã phát xong
        double VolumeWas; // Sử dụng để đặt lại giá trị của loa khi nhấn lần thứ hai
        #endregion

        #region Bộ điều khiển quá trình phát nhạc
        // Xử lý sự kiện khi nhấn nút Play
        private void Play_Click(object sender, EventArgs e)
        {
            PlayButton.Visible = false;
            PauseButton.Visible = true;

            TimerMusicBar.Start();
            PlayerDevice.Play();

            if (MusicBar.Value == MusicBar.Maximum && !(Repeating || AutoNext))
                StartMusic(CurrentFile.Value.ToString());

            DisplayPlayList();
        }
        // Xử lý sự kiện khi nhấn Pause
        private void Pause_Click(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;

            PlayerDevice.Pause();
            TimerMusicBar.Stop();

            DisplayPlayList();
        }

        // Khi cuộn thanh âm lượng
        private void SpeakerBar_Scroll(object sender, EventArgs e)
        {
            VolumeWas = SpeakerBar.Value;

            if (PlayerDevice != null)
                PlayerDevice.Volume = (float)SpeakerBar.Value / 100;
        }
        // Nhấn nút loa
        private void Speaker_Click(object sender, EventArgs e)
        {
            SpeakerBar.Value = (int)(SpeakerBar.Value != 0 ? 0 : VolumeWas);

            if (PlayerDevice != null)
                PlayerDevice.Volume = (float)SpeakerBar.Value / 100;
        }

        // Đồng hồ, để thiết đặt thanh MusicBar theo đúng vị trí đang phát của bài hát
        private void MusicBar_TimerTick(object sender, EventArgs e)
        {
            if (MusicBar.Value == MusicBar.Maximum)
                EndMusic();
            else
                MusicBar.Value++;
        }
        // Khi thay đổi vị trí của con trượt thanh MusicBar
        private void MusicBar_Scroll(object sender, EventArgs e)
        {
            PlayCurrentFile.CurrentTime = TimeSpan.FromSeconds(MusicBar.Value);
        }

        // Phát bài hát tiếp theo
        private void Next_Click(object sender, EventArgs e)
        {
            Pause_Click(sender, e);

            if (CurrentFile != PathOfFiles.Tail)
                CurrentFile = CurrentFile.Next;
            else
                CurrentFile = PathOfFiles.Head;

            StartMusic(CurrentFile.Value.ToString());
            DisplayPlayList();
        }

        // Phát lùi bài hát
        private void Previous_Click(object sender, EventArgs e)
        {
            Pause_Click(sender, e);
            
            if (CurrentFile != PathOfFiles.Head)
                CurrentFile = CurrentFile.Previous;
            else
                CurrentFile = PathOfFiles.Tail;

            StartMusic(CurrentFile.Value.ToString());
            DisplayPlayList();
        }

        // Nhấn nút Repeating
        private void Repeating_Click(object sender, EventArgs e)
        {
            Repeating = Repeating ? false : true;
            AutoNext = false;
        }
        
        // Nhấn nút AutoNext
        private void AutoNext_Click(object sender, EventArgs e)
        {
            AutoNext = AutoNext ? false : true;
            Repeating = false;
        }
        #endregion

        #region Control panel bên trái
        // Mở OpenFileDialog khi nhấn vào nút Open
        private void OpenFile_Click(object sender, EventArgs e)
        {
            // Thiết đặt thuộc tính cho hộp thoại Open File
            OpenFileDialog OpenFile = new OpenFileDialog()
            {
                Filter = "MP3 Files (*.mp3)|*.mp3",
                FilterIndex = 1,
                Multiselect = true,
                Title = "Open Files"
            };

            // Add những file vào trong list
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                PathOfFiles.AddRange(OpenFile.FileNames);
                new PlaylistForm();
            }

            DisplayPlayList();

            // Lưu lại những bài hát được up lên app
            File.WriteAllLines("MusicList", PathOfFiles.ToArray_String());
        }
        #endregion

        #region Xử lý khi bắt đầu, kết thúc đoạn nhạc
        // Xử lý khi bắt đầu phát nhạc mới
        private void StartMusic(string File)
        {
            PlayerDevice.Dispose();
            PlayerDevice = new WaveOut();
            PlayCurrentFile = new AudioFileReader(CurrentFile.Value.ToString());
            PlayerDevice.Init(PlayCurrentFile);
            PlayCurrentFile.CurrentTime = TimeSpan.Zero;
            MusicBar.Maximum = (int)PlayCurrentFile.TotalTime.TotalSeconds;
            MusicBar.Value = 0;

            Play_Click(new object(), new EventArgs());
        }
        // Xử lý khi đã phát hết nhạc
        private void EndMusic()
        {
            Pause_Click(new object(), new EventArgs());

            if (Repeating)
                StartMusic(CurrentFile.Value.ToString());

            if (AutoNext && CurrentFile != PathOfFiles.Tail)
            {
                CurrentFile = CurrentFile.Next;
                StartMusic(CurrentFile.Value.ToString());
                DisplayPlayList();
            }
        }
        #endregion

        #region Xử lý, hiển thị danh sách các bài hát (Đang tiến hành)
        private void DisplayPlayList()
        {
            MusicList.Controls.Clear();
            int i = 0;

            foreach (Node Current in PathOfFiles)
            { 
                Panel MusicPanel = new Panel();
                PictureBox ImageMusic = new PictureBox();
                PictureBox PlayButton = new PictureBox();
                Label MusicName = new Label();
                Label TotalTime = new Label();

                ImageMusic.Size = new Size(30, 30);
                ImageMusic.SizeMode = PictureBoxSizeMode.Zoom;
                ImageMusic.Image = this.IconApp.Image;
                ImageMusic.MouseClick += new MouseEventHandler(this.ImageMusic);

                MusicName.Text = (i + 1) + ". " + Path.GetFileNameWithoutExtension(Current.Value.ToString());
                MusicName.Font = new Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                MusicName.ForeColor = Color.White;
                MusicName.AutoSize = false;
                MusicName.Size = new Size(150, 50);
                MusicName.Cursor = Cursors.Hand;
                MusicName.TextAlign = ContentAlignment.MiddleLeft;
                MusicName.Click += (sender, e) => { PlayPauseThisMusic(sender, e, MusicPanel); };

                PlayButton.Name = "PlayButton";
                PlayButton.Size = new Size(20, 20);
                PlayButton.Cursor = Cursors.Hand;
                PlayButton.SizeMode = PictureBoxSizeMode.Zoom;
                PlayButton.Click += (sender, e) => { PlayPauseThisMusic(sender, e, MusicPanel); };
                if (this.CurrentFile == Current && PlayerDevice.PlaybackState == PlaybackState.Playing)
                    PlayButton.Image = Properties.Resources.PauseThis;
                else
                    PlayButton.Image = Properties.Resources.PlayThis;

                TotalTime.Size = new Size(50, 50);
                TotalTime.Font = new Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                AudioFileReader ReadTime = new AudioFileReader(Current.Value.ToString());
                TotalTime.Text = ReadTime.TotalTime.TotalHours >= 1 ? 
                    string.Format("{0:h\\:mm\\:ss}", ReadTime.TotalTime) : 
                    string.Format("{0:m\\:ss}", ReadTime.TotalTime);
                TotalTime.TextAlign = ContentAlignment.MiddleCenter;
                TotalTime.ForeColor = Color.White;
                TotalTime.AutoSize = false;

                MusicPanel.Tag = Current;
                MusicPanel.Size = new Size(420, 50);
                MusicPanel.AutoSize = false;
                MusicPanel.Controls.Add(ImageMusic);
                MusicPanel.Controls.Add(PlayButton);
                MusicPanel.Controls.Add(MusicName);
                MusicPanel.Controls.Add(TotalTime);
                if (i % 2 != 0)
                    MusicPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
                else
                    MusicPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));

                ImageMusic.Location = new Point(25, 10);
                PlayButton.Location = new Point(110, 15);
                MusicName.Location = new Point(175, 0);
                TotalTime.Location = new Point(350, 0);
                
                MusicList.Controls.Add(MusicPanel);
                MusicList.BringToFront();

                i++;
            }
            PlayPanel.BringToFront();
            Account.BringToFront();
        }

        // Nhấn vào nút Play/Pause trên MusicList
        private void PlayPauseThisMusic(object sender, EventArgs e, Panel MusicPanel)
        {
            Node Current = MusicPanel.Tag as Node;

            if (CurrentFile == Current)
                if (PlayerDevice.PlaybackState == PlaybackState.Playing)
                    Pause_Click(sender, e);
                else
                    Play_Click(sender, e);
            else
            {
                Pause_Click(sender, e);
                CurrentFile = Current;
                StartMusic(CurrentFile.Value.ToString());
            }
        }

        // Cập nhật ảnh đại diện cho bài hát
        private void ImageMusic(object sender, MouseEventArgs e)
        {
            PictureBox ImageMusic = sender as PictureBox;
            if (e.Button == MouseButtons.Right)
            {
                OpenFileDialog OpenImage = new OpenFileDialog()
                {
                    Title = "Cập nhật ảnh đại diện bài hát",
                    Filter = "Image Files(*.jpg; *.png; *.gif; *.bmp)| *.jpg; *.png; *.gif; *.bmp",
                    Multiselect = false,
                };
                if (OpenImage.ShowDialog() == DialogResult.OK)
                {
                    string GetImage = OpenImage.FileName;
                    ImageMusic.Image = Image.FromFile(GetImage);
                }
            }
            else
            {

            }
        }

        // Kéo thả MusicPanel
        private void HoldMusicPanel()
        {

        }

        // Đổi tên bài hát
        private void RenameMusic(object sender, EventArgs e)
        {

        }

        // Xoá bài hát
        private void RemoveMusic(object sender, EventArgs e)
        {

        }

        // Xử lý sự kiện khi lăn chuột trên MusicList
        private void MusicList_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                MusicList.Location = new Point(MusicList.Location.X, MusicList.Location.Y + 10);
            }
            if (e.Delta < 0)
            {
                MusicList.Location = new Point(MusicList.Location.X, MusicList.Location.Y - 10);
            }
        }
        #endregion

        #region Tài khoản người dùng
        #endregion
    }
}
