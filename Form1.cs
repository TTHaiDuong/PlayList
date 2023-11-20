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

            if (CurrentFile.Value.ToString() != null)
            StartMusic(CurrentFile.Value.ToString());

            Pause_Click(new object(), new EventArgs());

            EditPlaylist();
        }

        #region Các thuộc tính điều khiển
        DoublyLinkedList PathOfFiles; // Lưu đường dẫn của các file
        Node CurrentFile; // Lấy đường dẫn của file phát nhạc hiện tại
        IWavePlayer PlayerDevice; // Thiết bị dùng để điều khiển file âm thanh đang phát
        AudioFileReader PlayCurrentFile; // Đọc file
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
        }
        // Xử lý sự kiện khi nhấn Pause
        private void Pause_Click(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;

            PlayerDevice.Pause();
            TimerMusicBar.Stop();
        }

        // Xử lý sự kiện khi cuộn thanh âm lượng
        private void SpeakerBar_Scroll(object sender, EventArgs e)
        {
            VolumeWas = SpeakerBar.Value;

            if (PlayerDevice != null)
                PlayerDevice.Volume = (float)SpeakerBar.Value / 100;
        }
        // Xử lý sự kiện khi nhấn nút loa
        private void Speaker_Click(object sender, EventArgs e)
        {
            SpeakerBar.Value = (int)(SpeakerBar.Value != 0 ? 0 : VolumeWas);

            if (PlayerDevice != null)
                PlayerDevice.Volume = (float)SpeakerBar.Value / 100;
        }

        // Đồng hồ, để dịch chuyển thanh Trackbar theo đúng vị trí phát của đoạn nhạc
        private void MusicBar_TimerTick(object sender, EventArgs e)
        {
            if (MusicBar.Value == MusicBar.Maximum)
                EndMusic();
            else
                MusicBar.Value++;
        }
        private void MusicBar_Scroll(object sender, EventArgs e)
        {
            PlayCurrentFile.CurrentTime = TimeSpan.FromSeconds(MusicBar.Value);
        }

        // Xử lý khi bấm next video
        private void Next_Click(object sender, EventArgs e)
        {
            if (CurrentFile != PathOfFiles.Tail)
                CurrentFile = CurrentFile.Next;
            else
                CurrentFile = PathOfFiles.Head;

            StartMusic(CurrentFile.Value.ToString());
        }

        // Xử lý khi bấm previous video
        private void Previous_Click(object sender, EventArgs e)
        {
            if (CurrentFile != PathOfFiles.Head)
                CurrentFile = CurrentFile.Previous;
            else
                CurrentFile = PathOfFiles.Tail;

            StartMusic(CurrentFile.Value.ToString());
        }

        private void Repeating_Click(object sender, EventArgs e)
        {
            Repeating = Repeating ? false : true;
            AutoNext = false;
        }

        private void AutoNext_Click(object sender, EventArgs e)
        {
            AutoNext = AutoNext ? false : true;
            Repeating = false;
        }
        #endregion

        #region Control phía bên trái
        // Mở OpenFileDialog khi nhấn vào nút Open
        private void OpenFile_Click(object sender, EventArgs e)
        {
            // Thiết đặt thuộc tính cho hộp thoại Open File
            OpenFileDialog OpenFile = new OpenFileDialog()
            {
                Filter = "MP3 Files (*.mp3)|*.mp3",
                FilterIndex = 1,
                Multiselect = true,
                Title = "Open"
            };

            // Add những file vào trong list
            if (OpenFile.ShowDialog() == DialogResult.OK)
                PathOfFiles.AddRange(OpenFile.FileNames);

            EditPlaylist();

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
            }
        }
        #endregion

        #region Xử lý, hiển thị danh sách các bài hát
        private void EditPlaylist()
        {
            MusicList.Controls.Clear();

            int i = 0;
            foreach (string Current in PathOfFiles)
            {
                i++;
                Panel Music = new Panel();
                Music.AutoSize = true;
                Label MusicName = new Label();
                MusicName.Text = Path.GetFileName(Current).Replace(".mp3", "");
                MusicName.Font = new Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                MusicName.ForeColor = Color.White;
                MusicName.AutoSize = false;
                MusicName.Size = new Size(400, 50);
                MusicName.Cursor = Cursors.Hand;
                MusicName.TextAlign = ContentAlignment.MiddleLeft;
                MusicName.Click += NameMusic_Click;
                MusicList.Controls.Add(MusicName);
                MusicList.BringToFront();
            }
            PlayPanel.BringToFront();
            Profile.BringToFront();
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

        // Xử lý sự kiện khi nhấn vào tên bài hát ở danh sách bài hát
        private void NameMusic_Click(object sender, EventArgs e)
        {
            Label Current = sender as Label;
            if (Current.Text != null)
            {
                PlayCurrentFile = new AudioFileReader(Array.Find(PathOfFiles.ToArray_String(), find => Path.GetFileName(find) == Current.Text + ".mp3"));
                this.Controls.Add(new Label() { ForeColor = Color.White, Text = PlayCurrentFile.FileName });

                PlayerDevice.Dispose();
                PlayerDevice = new WaveOut();
                PlayerDevice.Init(PlayCurrentFile);

                MusicBar.Maximum = (int)PlayCurrentFile.TotalTime.TotalSeconds;
                MusicBar.Value = 0;
                PlayerDevice.Play();

                TimerMusicBar.Start();

                PlayButton.Visible = false;
                PauseButton.Visible = true;
            }
        }
        #endregion

        #region Tìm kiếm bài hát
        #endregion
    }
}
