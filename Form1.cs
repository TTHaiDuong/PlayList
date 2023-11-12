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

        private void ClickToPlay(object sender, EventArgs e)
        {
            PlayButton.Visible = false;
            PauseButton.Visible = true;

            if (PlayCurrentFile == null)
            {
                PlayerDevice = new WaveOut();
                PlayCurrentFile = new AudioFileReader(PathOfFiles[0]);
            }
                PlayerDevice.Init(PlayCurrentFile);
                PlayerDevice.Play();
        }

        private void ClickToPause(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;
            PlayerDevice.Pause();
        }
        int SpeakerVolumeIs;
        private void VolumeScroll(object sender, EventArgs e)
        {
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();
            SpeakerVolumeIs = SpeakerTrackBar.Value;
        }
        private void SpeakerButtonClick(object sender, EventArgs e)
        {
            SpeakerTrackBar.Value = SpeakerTrackBar.Value != 0 ? 0 : SpeakerVolumeIs;
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();
        }

        // Khi con trỏ đi ngang qua nút OpenFile thì màu nền nó nổi bật lên
        private void MouseHoverOpenFileButton(object sender, EventArgs e)
        {
            Panel_OpenFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(10))))); ;
        }
        private void SelectOpenFileButton(object sender, EventArgs e)
        {
            MouseHoverOpenFileButton(sender, e);
        }
        // Khi con trỏ không nằm trên nút OpenFile nữa thì đặt lại màu nền ban đầu của nó
        private void MouseLeaveOpenFileButton(object sender, EventArgs e)
        {
            Panel_OpenFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14))))); ;
        }
    }
}
