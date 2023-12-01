using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using NAudio.Wave;
using Playlist.Properties;

namespace Playlist
{
    public partial class PlaylistForm : Form
    {
        public PlaylistForm()
        {
            InitializeComponent();
            OnAutoNext.Visible = true;
            OnRepeating.Visible = false;
            ResetProperties();
        }

        private void ResetProperties()
        {
            PlayMusicList = new Playlist();
            PlayMusicList.StopAndDisposePlayerDevice();
            PlayMusicList.StartPlayingFile += StartNewMusic;
            PlayMusicList.FinishPlayingFile += EndMusic;
            PlayMusicList.Tick += TimerTick;
            PlayMusicList.StartToPlay();
            PlayMusicList.Pause();

            this.Controls.Remove(this.Controls["MusicList"]);
            MusicList = new MusicListPanel(PlayMusicList, Path.Combine(Directory.GetCurrentDirectory(), "PlaylistFiles"));
            this.Controls.Add(MusicList);
            {
                MusicList.Name = "MusicList";
                MusicList.Location = new Point(127, 150);
                MusicList.UpperLimit = TopPanel.Location.Y + TopPanel.Height;
                MusicList.LowerLimit = PlayPanel.Location.Y;
                MusicList.Trash = Trash;
                MusicList.PlayPause += PlayPause_Click;
                MusicList.PlayPauseButton = this.PlayPauseButton;
                MusicList.ChoosingAnotherMusic += MusicList_ChoosingAnotherMusic;
            }

            MusicList.InitializeComponent();
        }

        MusicListPanel MusicList;
        private Playlist PlayMusicList; // Dùng để phát nhạc tích hợp danh sách liên kết đôi
        private int VolumeWas; // Dùng để hồi phục lại vị trí cũ của thanh âm lượng khi nhấn nút loa

        // Khi bắt đầu phát bài hát mới
        private void StartNewMusic(object sender, EventArgs e)
        {
            MusicBar.Maximum = PlayMusicList.TotalTime;
            MusicBar.Value = 0;

            CurrentTime.Text = "0:00";
            TotalTime.Text = PlayMusicList.TotalTime > 3600 ?
                string.Format("{0:h\\:mm\\:ss}", TimeSpan.FromSeconds(PlayMusicList.TotalTime)) :
                string.Format("{0:m\\:ss}", TimeSpan.FromSeconds(PlayMusicList.TotalTime));
        }

        // Khi bài hát kết thúc
        private void EndMusic(object sender, EventArgs e)
        {
            if (!(PlayMusicList.AutoNext || PlayMusicList.Repeating))
                PlayPauseButton.Image = Resources.PlayButton_Image;
            
            MusicList.PlayClick(PlayMusicList.CurrentIndex);

            if (PlayMusicList.Repeating) MusicList.PlayClick(PlayMusicList.CurrentIndex);
        }

        private void MusicList_ChoosingAnotherMusic(object sender, EventArgs e)
        {
            ImageMusicPlaying1.Image = null;
            ImageMusicPlaying2.Image = null;
            if (File.Exists(Path.Combine(MusicList.FilesPath, Path.GetFileNameWithoutExtension((MusicList.Current.Controls["ImageMusic" + PlayMusicList.CurrentIndex] as PictureBox).Tag.ToString()))))
            {
                ImageMusicPlaying1.Image = new Bitmap((MusicList.Current.Controls["ImageMusic" + PlayMusicList.CurrentIndex] as PictureBox).Image);
                ImageMusicPlaying2.Image = ImageMusicPlaying1.Image;
            }
        }

        // Timer Tick dùng để dịch chuyển vị trí thanh MusicBar
        private void TimerTick(object sender, EventArgs e)
        {
            if (MusicBar.Value < MusicBar.Maximum)
                MusicBar.Value++;

            CurrentTime.Text = PlayMusicList.CurrentTime > 3600 ?
                string.Format("{0:h\\:mm\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime)) :
                string.Format("{0:m\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime));
        }

        // Nhấn nút OpenFile
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog()
            {
                Filter = "MP3 Files (*.mp3)|*.mp3",
                Multiselect = true,
                Title = "Open Music Files"
            };

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string File in OpenFile.FileNames)
                {
                    if (!System.IO.File.Exists(Path.Combine(MusicList.FilesPath, Path.GetFileName(File))))
                        System.IO.File.Copy(File, Path.Combine(MusicList.FilesPath, Path.GetFileName(File)));
                }                
                MusicList.PlayerDevice.StopAndDisposePlayerDevice();
                ResetProperties();
            }
        }

        // Nhấn nút Play
        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PlayMusicList.CurrentFile))
            {
                if (MusicBar.Maximum == MusicBar.Value) PlayMusicList.StartToPlay();
                if (PlayMusicList.IsPlaying)
                {
                    PlayMusicList.Pause();
                    PlayPauseButton.Image = Resources.PlayButton_Image;
                }
                else
                {
                    PlayMusicList.Play();
                    PlayPauseButton.Image = Resources.PauseButton_Image;
                }
                MusicList.PlayClick(PlayMusicList.CurrentIndex);
            }
        }

        // Phát bài hát trước
        private void Previous_Click(object sender, EventArgs e)
        { 
            MusicList.PlayClick(PlayMusicList.CurrentIndex - 1);        
        }

        // Phát bài hát sau
        private void Next_Click(object sender, EventArgs e) 
        { 
            MusicList.PlayClick(PlayMusicList.CurrentIndex + 1);
        }

        // Tự động phát bài tiếp theo
        private void AutoNext_Click(object sender, EventArgs e) 
        { 
            PlayMusicList.AutoNext = !PlayMusicList.AutoNext;
            if (PlayMusicList.AutoNext) OnAutoNext.Visible = true;
            else OnAutoNext.Visible = false;
            OnRepeating.Visible = false;

            if (PlayMusicList.AutoNext && MusicBar.Value == MusicBar.Maximum)
                MusicList.PlayClick(PlayMusicList.CurrentIndex + 1);
        }

        // Tự động lặp lại bài hát
        private void Repeating_Click(object sender, EventArgs e) 
        { 
            PlayMusicList.Repeating = !PlayMusicList.Repeating;
            if (PlayMusicList.Repeating) OnRepeating.Visible = true;
            else OnRepeating.Visible = false;
            OnAutoNext.Visible = false;

            if (PlayMusicList.Repeating && MusicBar.Value == MusicBar.Maximum)
                MusicList.PlayClick(PlayMusicList.CurrentIndex);
        }

        // Nhấn nút loa
        private void Speaker_Click(object sender, EventArgs e)
        {
            if (MusicBar.Value == MusicBar.Maximum) PlayPause_Click(sender, e);
            if (VolumeWas == 0) VolumeWas = 100;
            SpeakerBar.Value = SpeakerBar.Value == 0 ? VolumeWas : 0;
            PlayMusicList.Volume = SpeakerBar.Value;
        }

        // Cuộn thanh âm lượng
        private void SpeakerBar_Scroll(object sender, EventArgs e)
        {
            VolumeWas = SpeakerBar.Value;
            PlayMusicList.Volume = SpeakerBar.Value;
        }

        // Cuộn thanh phát nhạc
        private void MusicBar_Scroll(object sender, EventArgs e) 
        {
            PlayPauseButton.Image = Resources.PauseButton_Image;
            PlayMusicList.CurrentTime = MusicBar.Value;
            CurrentTime.Text = PlayMusicList.CurrentTime > 3600 ?
                string.Format("{0:h\\:mm\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime)) :
                string.Format("{0:m\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime));
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string searchTerm = SearchTextBox.Text.ToLower();

            string[] songArray = PlayMusicList.ToArray();

            // Xóa tất cả các mục cũ khỏi ListBox trước khi hiển thị kết quả tìm kiếm mới
            listBox1.Items.Clear();

            foreach (string filePath in songArray)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                if (fileName.ToLower().Contains(searchTerm))
                {
                    listBox1.Items.Add(fileName);
                }
            }
        }

    }
}

