using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.LostFocus += PlaylistForm_LostFocus;
            SearchBox.LostFocus += PlaylistForm_LostFocus;
            this.ActiveControl = null;
            if (File.Exists(CoverImagePath)) CoverImage.Image = Image.FromFile(CoverImagePath);

            ResetProperties();
        }

        private void PlaylistForm_LostFocus(object sender, EventArgs e)
        {
            if (!SearchBox.ContainsFocus) this.Focus();
        }

        private void ResetProperties()
        {
            PlayMusicList = new Playlist();
            PlayMusicList.StopAndDisposePlayerDevice();
            PlayMusicList.NewAudioFile += StartNewMusic;
            PlayMusicList.FinishPlayingFile += EndMusic;
            PlayMusicList.Tick += TimerTick;
            PlayMusicList.PrepareToPlay();
            PlayMusicList.Pause();

            this.Controls.Remove(this.Controls["MusicList"]);
            MusicList = new MusicListPanel(PlayMusicList, Path.Combine(Directory.GetCurrentDirectory(), "PlaylistFiles"));
            this.Controls.Add(MusicList);
            {
                MusicList.Name = "MusicList";
                MusicList.Location = new Point(127, 170);
                MusicList.UpperLimit = CoverImage.Location.Y + CoverImage.Height;
                MusicList.LowerLimit = PlayPanel.Location.Y;
                MusicList.Trash = Trash;
                MusicList.PlayPauseButton = this.PlayPauseButton;
                MusicList.ChoosingAnotherMusic += MusicList_ChoosingAnotherMusic;
            }

            MusicList.InitializeComponent();
        }

        private readonly string CoverImagePath = Path.Combine(Directory.GetCurrentDirectory(), "CoverImage");
        private MusicListPanel MusicList;
        private Playlist PlayMusicList; // Dùng để phát nhạc tích hợp danh sách liên kết đôi
        private int VolumeWas; // Dùng để hồi phục lại vị trí cũ của thanh âm lượng khi nhấn nút loa

        // Khi bắt đầu phát bài hát mới
        private void StartNewMusic(object sender, EventArgs e)
        {
            MusicBar.Maximum = PlayMusicList.TotalTime;
            MusicBar.Value = 0;

            MusicName.Text = Path.GetFileNameWithoutExtension(PlayMusicList.CurrentNode.FileName);

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
            if (File.Exists(Path.Combine(MusicList.FilesPath, Path.GetFileNameWithoutExtension((MusicList.Current.Controls["ImageMusic"] as PictureBox).Tag.ToString()))))
            {
                ImageMusicPlaying1.Image = new Bitmap((MusicList.Current.Controls["ImageMusic"] as PictureBox).Image);
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
            if (!string.IsNullOrEmpty(PlayMusicList.CurrentNode.FileName))
            {
                if (MusicBar.Maximum == MusicBar.Value) PlayMusicList.PrepareToPlay();
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
            int Index = PlayMusicList.CurrentIndex - 1;
            if (Index < 0) Index = PlayMusicList.Count - 1;
            MusicList.PlayClick(Index);
        }

        // Phát bài hát sau
        private void Next_Click(object sender, EventArgs e)
        {
            int Index = PlayMusicList.CurrentIndex + 1;
            if (Index > PlayMusicList.Count - 1) Index = 0;
            MusicList.PlayClick(Index);
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
            if (!PlayMusicList.IsPlaying) MusicList.PlayClick(PlayMusicList.CurrentIndex);

            PlayPauseButton.Image = Resources.PauseButton_Image;
            PlayMusicList.CurrentTime = MusicBar.Value;
            CurrentTime.Text = PlayMusicList.CurrentTime > 3600 ?
                string.Format("{0:h\\:mm\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime)) :
                string.Format("{0:m\\:ss}", TimeSpan.FromSeconds(PlayMusicList.CurrentTime));
        }

        // Bỏ dấu các kí tự tiếng Việt
        public static string RemoveDiacritics(string Text)
        {
            string NormalizedText = Text.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            return regex.Replace(NormalizedText, string.Empty).Normalize(NormalizationForm.FormC);
        }

        private string[] TempMusicFiles; // Lưu tạm thời danh sách File nhạc trong MusicList
        private void SearchBox_Enter(object sender, EventArgs e)
        {
            TempMusicFiles = MusicList.MusicFiles;
        }

        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (MusicList.MusicFiles != TempMusicFiles)
            {
                MusicList.MusicFiles = TempMusicFiles;
                MusicList.InitializeComponent();
            }
        }

        // Tìm kiếm nhạc
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string SearchTerm = RemoveDiacritics(SearchBox.Text.ToLower().Trim());

            List<string> Result = new List<string>();
            foreach (string FileName in TempMusicFiles)
                if (RemoveDiacritics(FileName.ToLower().Trim()).Contains(SearchTerm)) Result.Add(FileName);

            MusicList.MusicFiles = Result.ToArray();
            MusicList.InitializeComponent();
        }

        private void CoverImage_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OpenFileDialog OpenImage = new OpenFileDialog()
                {
                    Title = "Open Your Cover Image",
                    Filter = "Image Files(*.jpg; *.png; *.gif; *.bmp)| *.jpg; *.png; *.gif; *.bmp",
                    Multiselect = false
                };
                if (OpenImage.ShowDialog() == DialogResult.OK)
                {
                    CoverImage.Image?.Dispose();
                    CoverImage.Image = Image.FromFile(OpenImage.FileName);

                    if (File.Exists(CoverImagePath)) File.Delete(CoverImagePath);

                    File.Copy(OpenImage.FileName, CoverImagePath);
                }
            }
        }
    }
}

