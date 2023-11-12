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

namespace Playlist
{
    public partial class PlaylistForm : Form
    {
        public PlaylistForm()
        {
            InitializeComponent();
        }

        OpenFileDialog OpenFile;
        string[] PathOfFiles;
        string[] NameOfFiles;

        IWavePlayer PlayerDevice;
        AudioFileReader PlayCurrentFile;

        private void ClickToOpenFile(object sender, EventArgs e)
        {
            OpenFile = new OpenFileDialog();
            OpenFile.Filter = "MP3 Files (*.mp3)|*.mp3";
            OpenFile.FilterIndex = 1;
            OpenFile.Multiselect = true;
            OpenFile.Title = "Open";

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                PathOfFiles = OpenFile.FileNames;
            }
        }

        // Xử lý sự kiện khi nhấn nút Play
        private void ClickToPlay(object sender, EventArgs e)
        {
            PlayButton.Visible = false;
            PauseButton.Visible = true;

            if (PlayCurrentFile == null && PathOfFiles[0] != "")
            {
                PlayerDevice = new WaveOut();
                PlayCurrentFile = new AudioFileReader(PathOfFiles[0]);

                MusicTrackBar.Maximum = Convert.ToInt32(PlayCurrentFile.TotalTime.TotalSeconds);
                MusicTrackBar.Value = 0;
                PlayerDevice.Volume = 1;
            }
            if (PlayCurrentFile != null) TimerForMusicBar.Start();
            PlayerDevice.Init(PlayCurrentFile);
            PlayerDevice.Play();
        }

        // Xử lý sự kiện khi nhấn Pause
        private void ClickToPause(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;
            PlayerDevice.Pause();
            TimerForMusicBar.Stop();
        }

        // Thanh Volume
        int SpeakerVolumeIs;
        private void Volume_Scroll(object sender, EventArgs e)
        {
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();
            SpeakerVolumeIs = SpeakerTrackBar.Value;

            PlayerDevice.Volume = (float)SpeakerTrackBar.Value / 100;
        }
        private void SpeakerButton_Click(object sender, EventArgs e)
        {
            SpeakerTrackBar.Value = SpeakerTrackBar.Value != 0 ? 0 : SpeakerVolumeIs;
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();

            PlayerDevice.Volume = (float)SpeakerTrackBar.Value / 100;
        }


        // Khi con trỏ đi ngang qua nút OpenFile thì màu nền nó nổi bật lên
        private void MouseHover_OpenFileButton(object sender, EventArgs e)
        {
            Panel_OpenFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(10))))); ;
        }
        private void SelectOpen_FileButton(object sender, EventArgs e)
        {
            MouseHover_OpenFileButton(sender, e);
        }
        // Khi con trỏ không nằm trên nút OpenFile nữa thì đặt lại màu nền ban đầu của nó
        private void MouseLeave_OpenFileButton(object sender, EventArgs e)
        {
            Panel_OpenFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14))))); ;
        }


        // Đồng hồ, để dịch chuyển thanh Trackbar theo đúng vị trí phát của đoạn nhạc
        private void MusicBar_TimerTick(object sender, EventArgs e)
        {
            MusicTrackBar.Value++;
        }
        private void MusicTrackbar_Scroll(object sender, EventArgs e)
        {
            PlayCurrentFile.CurrentTime = TimeSpan.FromSeconds(MusicTrackBar.Value);
        }
    }
}
