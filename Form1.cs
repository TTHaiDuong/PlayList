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

namespace Playlist
{
    public partial class PlaylistForm : Form
    {
        public PlaylistForm()
        {
            InitializeComponent();
        }

        #region Các thuộc tính điều kiển

        OpenFileDialog OpenFile; // Dùng để mở file
        DoublyLinkedList PathOfFiles = new DoublyLinkedList(); // Lưu đường dẫn của các file khi được lấy từ OpenFileDialog

        IWavePlayer PlayerDevice; // Thiết bị dùng để điều khiển file âm thanh đang phát
        AudioFileReader PlayCurrentFile; // Đọc file

        int ChooseMusic = 0; // Số thứ tự của bài hát trong list, chọn để chơi

        bool Repeating = false; // Lặp lại bài hát hiện tại khi đã phát xong

        int SpeakerVolumeIs = 100; // Sử dụng để đặt lại giá trị của loa khi nhấn lần thứ hai

        WaveViewer WaveViewer = new WaveViewer();

        #endregion

        // Mở OpenFileDialog khi nhấn vào nút Open
        private void OpenFile_Click(object sender, EventArgs e)
        {
            // Tạo và đặt thuộc tính cho OpenFileDialog
            OpenFile = new OpenFileDialog();
            OpenFile.Filter = "MP3 Files (*.mp3)|*.mp3"; // Lọc những file có định dạng MP3
            OpenFile.FilterIndex = 1;
            OpenFile.Multiselect = true;
            OpenFile.Title = "Open";

            // Tải lại những bài hát đã được up lên app
            File.WriteAllText("MusicList", "");
            PathOfFiles = DoublyLinkedList.FromArray(File.ReadAllLines("MusicList"));

            // Add những file vào trong list
            if (OpenFile.ShowDialog() == DialogResult.OK)
                PathOfFiles.AddRange(OpenFile.FileNames);

            DoublyLinkedList DisplayList = new DoublyLinkedList();

            foreach (string Current in PathOfFiles)
            {
                MusicList.Controls.Add(new Label() { Text = Current });
            }

            // Lưu lại những bài hát được up lên app
            File.WriteAllLines("MusicList", PathOfFiles.ToList().Select(obj => obj.ToString()).ToArray());
        }

        // Xử lý sự kiện khi nhấn nút Play
        private void Play_Click(object sender, EventArgs e)
        {
            // Thay đổi hình ảnh, từ nút Play sang hình nút Pause
            PlayButton.Visible = false;
            PauseButton.Visible = true;

            if (PlayCurrentFile == null && PathOfFiles.Count != 0)
            {
                if (PathOfFiles[0] == null) Console.Beep(500, 100);

                PlayerDevice = new WaveOut();
                PlayCurrentFile = new AudioFileReader(PathOfFiles[0].ToString());

                MusicTrackBar.Maximum = Convert.ToInt32(PlayCurrentFile.TotalTime.TotalSeconds);
                MusicTrackBar.Value = 0;
                PlayerDevice.Volume = 1;
            }
            if (PlayCurrentFile != null) TimerForMusicBar.Start();
            PlayerDevice.Init(PlayCurrentFile);
            PlayerDevice.Play();

            WaveViewer.WaveStream = PlayCurrentFile;
        }

        // Xử lý sự kiện khi nhấn Pause
        private void Pause_Click(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;
            PlayerDevice.Pause();
            TimerForMusicBar.Stop();
        }

        // Xử lý các sự kiện của loa
        private void Volume_Scroll(object sender, EventArgs e)
        {
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();
            SpeakerVolumeIs = SpeakerTrackBar.Value;

            if (PlayerDevice != null)
            PlayerDevice.Volume = (float)SpeakerTrackBar.Value / 100;
        }
        private void Speaker_Click(object sender, EventArgs e)
        {
            SpeakerTrackBar.Value = SpeakerTrackBar.Value != 0 ? 0 : SpeakerVolumeIs;
            VolumePercent.Text = SpeakerTrackBar.Value.ToString();

            if (PlayerDevice != null)
            PlayerDevice.Volume = (float)SpeakerTrackBar.Value / 100;
        }

        // Đồng hồ, để dịch chuyển thanh Trackbar theo đúng vị trí phát của đoạn nhạc
        private void MusicBar_TimerTick(object sender, EventArgs e)
        {
            if (MusicTrackBar.Value >= PlayCurrentFile.TotalTime.TotalSeconds - 1)
            {
                if (Repeating)
                {
                    MusicTrackBar.Value = 0;
                    PlayCurrentFile.CurrentTime = TimeSpan.Zero;
                    PlayerDevice.Play();
                }
                else
                    TimerForMusicBar.Stop();
            }
            else
                MusicTrackBar.Value++;
        }
        private void MusicBar_Scroll(object sender, EventArgs e)
        {
            PlayCurrentFile.CurrentTime = TimeSpan.FromSeconds(MusicTrackBar.Value);
        }


        // Xử lý khi bấm next video
        private void NextVideo_Click(object sender, EventArgs e)
        {
            ChooseMusic++;
            if (ChooseMusic >= PathOfFiles.Count) ChooseMusic = 0;
        }
        // Xử lý khi bấm previous video
        private void PreviousMusic_Click(object sender, EventArgs e)
        {
            ChooseMusic--;
            if (ChooseMusic <= 0) ChooseMusic = PathOfFiles.Count - 1;
        }

        private void Repeating_Click(object sender, EventArgs e)
        {
            Repeating = Repeating == true ? false : true;
        }
    }
}
