using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Playlist
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlaylistForm());
        }
    }

    /// <summary>
    /// Dùng làm phần tử của Playlist.
    /// </summary>
    public class PlaylistNode
    {
        /// <summary>
        /// Đường dẫn của File âm thanh.
        /// </summary>
        public string FileName;

        /// <summary>
        /// Dùng để liên kết với các Node khác.
        /// </summary>
        public PlaylistNode Next, Previous;

        /// <summary>
        /// Khởi tạo một Node trống của Playlist.
        /// </summary>
        public PlaylistNode()
        {
            this.FileName = null;
            this.Next = null;
            this.Previous = null;
        }

        /// <summary>
        /// Khởi tạo một Node của Playlist.
        /// </summary>
        /// <param name="File">Đường dẫn File âm thanh.</param>
        /// <param name="NewLink">Có khởi tạo liên kết mới cho Node hay không.</param>
        public PlaylistNode(string File, bool NewLink)
        {
            if (NewLink)
            {
                this.Next = null;
                this.Previous = null;
            }
            this.FileName = File;
        }
    }

    /// <summary>
    /// Dùng để phát các File âm thanh.
    /// </summary>
    public class Playlist : IEnumerable
    {
        private WaveOut PlayerDevice; // cái loa
        private AudioFileReader FileReader; // đầu đọc

        /// <summary>
        /// Sự kiện khi Playlist bắt đầu phát một File.
        /// </summary>
        public event EventHandler NewAudioFile;
        /// <summary>
        /// Sự kiện khi Playlist phát hết một File.
        /// </summary>
        public event EventHandler FinishPlayingFile;

        /// <summary>
        /// Sự kiện Tick của Timer dùng để kích hoạt thanh trượt.
        /// </summary>
        public event EventHandler Tick;
        private readonly Timer TimerTick = new Timer();

        /// <summary>
        /// Dùng để trỏ tới hai phần tử đầu hoặc cuối của Playlist.
        /// </summary>
        private PlaylistNode HeadNode, TailNode;

        /// <summary>
        /// Dùng để trỏ tới File âm thanh được phát hiện tại.
        /// </summary>
        public PlaylistNode CurrentNode;

        /// <summary>
        /// Chỉ số File âm thanh hiện tại trong Playlist dùng để phát.
        /// </summary>
        public int CurrentIndex { get => CurrentNode != null ? FindIndex(CurrentNode.FileName) : 0; }

        /// <summary>
        /// Số lượng phần tử trong Playlist
        /// </summary>
        public int Count { private set; get; }

        /// <summary>
        /// Độ lớn của loa (miền giá trị: 0-100).
        /// </summary>
        public int Volume
        {
            set
            {
                if (PlayerDevice != null)
                {
                    if (value >= 0 && value <= 100)
                        PlayerDevice.Volume = (float)(value / 100f);
                    else if (value < 0)
                        PlayerDevice.Volume = 0f;
                    else
                        PlayerDevice.Volume = 100f;
                }
            }
            get { return PlayerDevice != null ? (int)(PlayerDevice.Volume * 100f) : 0; }
        }

        /// <summary>
        /// Trả về thông tin rằng thiết bị có đang phát âm thanh không.
        /// </summary>
        public bool IsPlaying
        {
            get { return PlayerDevice?.PlaybackState == PlaybackState.Playing; }
        }

        /// <summary>
        /// Vị trí phát hiện tại của File (đơn vị: giây).
        /// </summary>
        public int CurrentTime
        {
            set
            {
                if (PlayerDevice != null && FileReader != null) PlayerDevice.Play();
                if (FileReader != null)
                {
                    if (value >= 0 && TimeSpan.FromSeconds(value) <= FileReader.CurrentTime)
                        FileReader.CurrentTime = TimeSpan.FromSeconds(value);
                    else if (value < 0)
                        FileReader.CurrentTime = TimeSpan.Zero;
                    else
                        FileReader.CurrentTime = TimeSpan.FromSeconds(value);
                }
            }
            get { return FileReader != null ? (int)FileReader.CurrentTime.TotalSeconds : 0; }
        }

        /// <summary>
        /// Tổng thời lượng của Current File (đơn vị: giây).
        /// </summary>
        public int TotalTime
        {
            get { return FileReader != null ? (int)FileReader.TotalTime.TotalSeconds : 0; }
        }

        /// <summary>
        /// Chức năng tự động phát File âm thanh tiếp theo.
        /// </summary>
        public bool AutoNext
        {
            set
            {
                ContainerAutoNext = value;
                if (value) Repeating = false;
            }
            get { return this.ContainerAutoNext; }
        }
        private bool ContainerAutoNext;

        /// <summary>
        /// Chức năng tự động lặp lại.
        /// </summary>
        public bool Repeating
        {
            set
            {
                ContainerRepeating = value;
                if (value) AutoNext = false;
            }
            get { return this.ContainerRepeating; }
        }
        private bool ContainerRepeating;

        /// <summary>
        /// Khởi tạo một Playlist trống.
        /// </summary>
        public Playlist()
        {
            this.HeadNode = null;
            this.TailNode = null;
            this.CurrentNode = null;
            this.Count = 0;
            this.AutoNext = true;
            this.Repeating = false;
            TimerTick.Tick += (sender, e) => { Tick?.Invoke(this, e); };
            StopAndDisposePlayerDevice();
        }

        // Cho phép duyệt các phần tử của Playlist bằng foreach.
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return Find(i).FileName;
            }
        }

        // Truy cập phần tử Playlist bằng cặp dấu [].
        public string this[int Index]
        {
            set { Find(Index).FileName = value; }
            get { return Find(Index).FileName; }
        }

        /// <summary>
        /// Khởi tạo một Playlist mới đến từ một mảng string[].
        /// </summary>
        /// <param name="Files">Các File đầu vào.</param>
        /// <returns>Trả về kiểu dữ liệu là Playlist.</returns>
        public Playlist FromArray(string[] Files)
        {
            HeadNode = null;
            TailNode = null;
            CurrentNode = null;
            this.AddRange(Files);
            return this;
        }

        /// <summary>
        /// Các đường dẫn File mà Playlist đang nắm giữ.
        /// </summary>
        /// <returns>Trả về kiểu dữ liệu kiểu string[]</returns>
        public string[] ToArray()
        {
            string[] Array = new string[this.Count];

            PlaylistNode Current = HeadNode;
            for (int i = 0; i < this.Count; i++)
            {
                Array[i] = Current.FileName;
                Current = Current.Next;
            }
            return Array;
        }

        /// <summary>
        /// Kiểm tra một đường dẫn có thể phát âm thanh được không.
        /// </summary>
        /// <param name="File">Đường dẫn của File âm thanh.</param>
        /// <returns>Nếu là true thì file có thể được phát ra âm thanh.</returns>
        private bool CanPlayAudio(string File)
        {
            if (String.IsNullOrEmpty(File)) return false;
            try { using (var FileReader = new AudioFileReader(File)) return true; }
            catch { return false; }
        }

        /// <summary>
        /// Kiểm tra xem chỉ số có phù hợp với Playlist hay không.
        /// </summary>
        /// <param name="Index">Chỉ số phần tử trong Playlist.</param>
        /// <exception cref="ArgumentOutOfRangeException">Chỉ số không hợp lệ!</exception>
        private void ValidIndex(int Index)
        {
            if (Index < 0 || Index >= Count) throw new ArgumentOutOfRangeException("Chỉ số không hợp lệ!");
        }

        /// <summary>
        /// Tìm kiếm một Node có trong Playlist bằng chỉ số.
        /// </summary>
        /// <param name="Index">Chỉ số phần tử muốn tìm.</param>
        /// <returns>Node cần tìm.</returns>
        public PlaylistNode Find(int Index)
        {
            this.ValidIndex(Index);

            PlaylistNode FindNode = HeadNode;

            for (int i = 0; i < Index; i++)
                FindNode = FindNode.Next;

            return FindNode;
        }

        public int FindIndex(string Find)
        {
            PlaylistNode Current = HeadNode;
            for (int i = 0; i < Count; i++)
            {
                if (Current.FileName == Find) return i;
                Current = Current.Next;
            }
            return -1;
        }

        /// <summary>
        /// Thêm một phần tử vào cuối của Playlist.
        /// </summary>
        /// <param name="NewFile">Đường dẫn của File âm thanh mới được thêm vào Playlist.</param>
        public void Add(string NewFile)
        {
            if (this.CanPlayAudio(NewFile))
            {
                PlaylistNode NewNode = new PlaylistNode(NewFile, true);
                if (HeadNode == null)
                {
                    HeadNode = NewNode;
                    TailNode = NewNode;
                    CurrentNode = NewNode;
                }
                else
                {
                    TailNode.Next = NewNode;
                    NewNode.Previous = TailNode;
                    TailNode = NewNode;
                }
                this.Count++;
            }
        }

        /// <summary>
        /// Thêm các phần tử vào cuối của Playlist.
        /// </summary>
        /// <param name="NewFiles">Đường dẫn của các File âm thanh.</param>
        public void AddRange(string[] NewFiles)
        {
            for (int i = 0; i < NewFiles.Length; i++)
                this.Add(NewFiles[i]);
        }

        /// <summary>
        /// Chèn một phần tử vào Playlist.
        /// </summary>
        /// <param name="File">Đường dẫn của File âm thanh muốn chèn.</param>
        /// <param name="Index">Vị trí muốn chèn trong Playlist.</param>
        public void Insert(string File, int Index)
        {
            if (this.CanPlayAudio(File))
            {
                ValidIndex(Index);

                PlaylistNode NewNode = new PlaylistNode(File, true);

                if (Index == 0)
                {
                    if (HeadNode == null)
                    {
                        HeadNode = NewNode;
                        TailNode = NewNode;
                    }
                    else
                    {
                        NewNode.Next = HeadNode;
                        HeadNode.Previous = NewNode;
                        HeadNode = NewNode;
                    }
                }
                else if (Index == Count)
                {
                    TailNode.Next = NewNode;
                    NewNode.Previous = TailNode;
                    TailNode = NewNode;
                }
                else
                {
                    PlaylistNode FindNode = Find(Index - 1);

                    PlaylistNode TheRest = FindNode.Next;
                    TheRest.Previous = NewNode;
                    FindNode.Next = NewNode;
                    NewNode.Previous = FindNode;
                    NewNode.Next = TheRest;
                }
                Count++;
            }
        }

        /// <summary>
        /// Chèn các File âm thanh vào trong Playlist.
        /// </summary>
        /// <param name="NewFiles">Đường dẫn của các File âm thanh.</param>
        /// <param name="StartIndex">Vị trí bắt đầu chèn.</param>
        public void InsertRange(string[] NewFiles, int StartIndex)
        {
            for (int i = 0; i < NewFiles.Length; i++)
                this.Insert(NewFiles[i], StartIndex + i);
        }

        /// <summary>
        /// Xoá một phần tử trong Playlist.
        /// </summary>
        /// <param name="Index">Vị trí phần tử cần xoá khỏi Playlist.</param>
        public void Remove(int Index)
        {
            ValidIndex(Index);

            if (Index == 0)
            {
                if (this.Count == 1)
                {
                    HeadNode = null;
                    TailNode = null;
                }
                else
                {
                    HeadNode = HeadNode.Next;
                    HeadNode.Previous = null;
                }
            }
            else if (Index == Count - 1)
            {
                TailNode = TailNode.Previous;
                TailNode.Next = null;
            }
            else
            {
                PlaylistNode FindNode = Find(Index - 1);
                PlaylistNode TheRest = FindNode.Next.Next;
                FindNode.Next = TheRest;
            }
            Count--;
        }

        /// <summary>
        /// Xoá một vùng các phần tử trong Playlist.
        /// </summary>
        /// <param name="StartIndex">Vị trí bắt đầu xoá.</param>
        /// <param name="Lenght">Độ dài của vùng cần xoá.</param>
        public void RemoveRange(int StartIndex, int Lenght)
        {
            ValidIndex(StartIndex);
            ValidIndex(StartIndex + Lenght);

            for (int i = StartIndex; i < StartIndex + Lenght; i++)
                this.Remove(i);
        }

        /// <summary>
        /// Giải phóng các thiết bị phát âm thanh.
        /// </summary>
        public void StopAndDisposePlayerDevice()
        {
            if (PlayerDevice != null)
            {
                PlayerDevice.Stop();
                PlayerDevice.Dispose();
                PlayerDevice = null;
            }
            if (FileReader != null)
            {
                FileReader.Dispose();
                FileReader = null;
            }
            TimerTick?.Dispose();
        }

        /// <summary>
        /// Phương thức chuẩn bị, đọc phát File âm thanh.
        /// </summary>
        public void PrepareToPlay()
        {
            StopAndDisposePlayerDevice();
            if (CanPlayAudio(CurrentNode?.FileName))
            {
                FileReader = new AudioFileReader(CurrentNode.FileName);
                PlayerDevice = new WaveOut();
                NewAudioFile?.Invoke(this, new EventArgs());
                PlayerDevice.PlaybackStopped += OnPlaybackStopped;
                PlayerDevice.PlaybackStopped += (sender, e) => { FinishPlayingFile?.Invoke(this, e); };
                PlayerDevice.Init(FileReader);
                TimerTick.Interval = 1000;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi kết thúc phát âm thanh.
        /// </summary>
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            TimerTick.Stop();
            if (ContainerRepeating)
            {
                PrepareToPlay();
                Play();
            }
            if (ContainerAutoNext)
            {
                NextFile();
                Play();
            }
        }

        /// <summary>
        /// Phát File âm thanh tại vị trí phát cụ thể.
        /// </summary>
        /// <param name="Time">Vị trí muốn phát.</param>
        public void SetCurrentTime(int Time)
        {
            if (PlayerDevice != null && FileReader != null)
                FileReader.CurrentTime = TimeSpan.FromSeconds(Time);
        }

        /// <summary>
        /// Dùng để tiếp tục phát âm thanh.
        /// </summary>
        public void Play()
        {

            if (PlayerDevice == null || FileReader == null || CurrentTime == TotalTime)
            {
                NewAudioFile?.Invoke(this, new EventArgs());
                PrepareToPlay();
                PlayerDevice?.Play();
            }
            PlayerDevice?.Play();
            TimerTick?.Start();
        }

        /// <summary>
        /// Dùng để dừng phát âm thanh.
        /// </summary>
        public void Pause()
        {
            if (FileReader != null)
            {
                PlayerDevice?.Pause();
                TimerTick?.Stop();
            }
        }

        /// <summary>
        /// Phát File phía sau.
        /// </summary>
        public void NextFile()
        {
            if (CurrentNode?.Next != null)
                CurrentNode = CurrentNode.Next;
            PrepareToPlay();
            PlayerDevice?.Play();
        }

        /// <summary>
        /// Phát File phía trước.
        /// </summary>
        public void PreviousFile()
        {
            if (CurrentNode?.Previous != null)
                CurrentNode = CurrentNode.Previous;
            PrepareToPlay();
            PlayerDevice?.Play();
        }

        /// <summary>
        /// Chọn một File cụ thể dùng để phát trong Playlist.
        /// </summary>
        /// <param name="Index">Vị trí của File trong Playlist.</param>
        public void ChooseFile(int Index)
        {
            CurrentNode = Find(Index);
            PrepareToPlay();
        }
    }

    /// <summary>
    /// Tạo danh sách hiển thị thông tin bài hát lên Form, điều khiển Playlist.
    /// </summary>
    public class MusicListPanel : FlowLayoutPanel
    {
        /// <summary>
        /// Đường dẫn cho các File âm thanh, hình ảnh.
        /// Tên File âm thanh có phần mở rộng, File hình ảnh không có phần mở rộng.
        /// </summary>
        public string FilesPath { set; get; }

        public string[] MusicFiles;
        private readonly string[] ImageFiles;

        /// <summary>
        /// Kết nối, điều khiển Playlist.
        /// </summary>
        public Playlist PlayerDevice;

        /// <summary>
        /// Điều khiển nút PlayPause bên ngoài.
        /// </summary>
        public PictureBox PlayPauseButton { set; private get; }

        /// <summary>
        /// Sự kiện chọn một bài nhạc khác bài nhạc hiện tại.
        /// </summary>
        public event EventHandler ChoosingAnotherMusic;

        /// <summary>
        /// File âm thanh được phát lúc trước.
        /// </summary>
        public string PreviousMusic;

        /// <summary>
        /// Panel được sử dụng hiện tại.
        /// </summary>
        public Panel Current;

        /// <summary>
        /// Object dùng để dùng làm thùng rác xoá Item trong MusicListPanel.
        /// </summary>
        public PictureBox Trash { set; get; }

        /// <summary>
        /// Giới hạn cuộn lên, xuống của MusicListPanel
        /// </summary>
        public int UpperLimit, LowerLimit;

        public MusicListPanel(Playlist PlayerDevice, string FilesPath)
        {
            this.FlowDirection = FlowDirection.TopDown;
            this.AutoSize = true;
            this.BackColor = Color.Transparent;
            this.UpperLimit = 0;
            this.LowerLimit = 0;
            this.PlayPauseButton = null;
            this.Trash = null;
            this.MusicFiles = null;
            this.ImageFiles = null;
            this.PlayerDevice = PlayerDevice;
            this.FilesPath = FilesPath;
            this.MouseWheel += MusicListPanel_Wheel;
            this.Controls.Clear();
            this.BringToFront();

            if (!Directory.Exists(FilesPath)) Directory.CreateDirectory(FilesPath);
            MusicFiles = Directory.GetFiles(FilesPath).Where(File => Path.GetExtension(File).Equals(".mp3", StringComparison.OrdinalIgnoreCase)).ToArray();
            ImageFiles = Directory.GetFiles(FilesPath).Where(File => string.IsNullOrEmpty(Path.GetExtension(File))).ToArray();

            PlayerDevice.FromArray(MusicFiles);

            if (PlayerDevice.CurrentNode != null) this.PreviousMusic = PlayerDevice.CurrentNode.FileName;
        }

        /// <summary>
        /// Khởi tạo các thành phần của PlayListPanel.
        /// </summary>
        public void InitializeComponent()
        {

            if (Trash != null) this.Trash.Visible = false;
            this.Controls.Clear();

            if (MusicFiles.Length > 0)
                for (int i = 0; i < MusicFiles.Length; i++)
                {
                    // Tạo Panel cho một bài hát và các thành phần của nó
                    Panel MusicPanel = new Panel();
                    PictureBox ImageMusic = new PictureBox();
                    PictureBox PlayButton = new PictureBox();
                    Label MusicName = new Label();
                    Label TotalTime = new Label();
                    //
                    // Hình đại diện bài hát
                    //
                    ImageMusic.Name = "ImageMusic";
                    ImageMusic.Size = new Size(46, 46);
                    ImageMusic.SizeMode = PictureBoxSizeMode.Zoom;
                    ImageMusic.Tag = MusicFiles[i];
                    if (File.Exists(Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(ImageMusic.Tag.ToString()))))
                        ImageMusic.Image = Image.FromFile(Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(ImageMusic.Tag.ToString())));
                    else ImageMusic.Image = (this.Parent as dynamic).Icon.ToBitmap();
                    ImageMusic.MouseClick += ImageMusic_RightClick;
                    //
                    // Nút PlayPause 
                    //
                    PlayButton.Name = "PlayButton";
                    PlayButton.Size = new Size(20, 20);
                    PlayButton.Cursor = Cursors.Hand;
                    PlayButton.SizeMode = PictureBoxSizeMode.Zoom;
                    if (PlayerDevice.CurrentNode.FileName == MusicFiles[i] && PlayerDevice.IsPlaying)
                        PlayButton.Image = Properties.Resources.PauseThis;
                    else
                        PlayButton.Image = Properties.Resources.PlayThis;
                    PlayButton.Tag = false; // true là đang phát, false là dừng
                    PlayButton.Click += (sender, e) => PlayButton_Click(((sender as PictureBox).Parent as dynamic).Name);
                    //
                    // Tên bài hát
                    //
                    MusicName.Name = "MusicName";
                    MusicName.Text = (i + 1) + ". " + Path.GetFileNameWithoutExtension(MusicFiles[i]);
                    MusicName.Font = new Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    MusicName.ForeColor = Color.White;
                    MusicName.AutoSize = false;
                    MusicName.Size = new Size(150, 50);
                    MusicName.Cursor = Cursors.Hand;
                    MusicName.TextAlign = ContentAlignment.MiddleLeft;
                    MusicName.Click += (sender, e) => PlayButton_Click(((sender as Label).Parent as dynamic).Name);
                    //
                    // Thời lượng bài hát
                    //
                    TotalTime.Name = "TotalTime";
                    TotalTime.Size = new Size(50, 50);
                    TotalTime.Font = new Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    AudioFileReader ReadTime = new AudioFileReader(MusicFiles[i]);
                    TotalTime.Text = ReadTime.TotalTime.TotalHours >= 1 ?
                        string.Format("{0:h\\:mm\\:ss}", ReadTime.TotalTime) :
                        string.Format("{0:m\\:ss}", ReadTime.TotalTime);
                    TotalTime.TextAlign = ContentAlignment.MiddleCenter;
                    TotalTime.ForeColor = Color.White;
                    TotalTime.AutoSize = false;
                    //
                    // Cài đặt thuộc tính của Panel bài hát
                    //
                    MusicPanel.Name = MusicFiles[i];
                    MusicPanel.AllowDrop = true;
                    MusicPanel.Tag = MusicFiles[i];
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
                    MusicPanel.MouseDown += MusicPanel_MouseDown;
                    MusicPanel.MouseMove += MusicPanel_MouseMove;
                    MusicPanel.MouseUp += MusicPanel_MouseUp;

                    ImageMusic.Location = new Point(15, 2);
                    PlayButton.Location = new Point(110, 15);
                    MusicName.Location = new Point(175, 0);
                    TotalTime.Location = new Point(350, 0);

                    if (Current == null) Current = MusicPanel;

                    this.Controls.Add(MusicPanel);
                }
        }

        private void ImageMusic_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox ImageMusic = sender as PictureBox;
                OpenFileDialog OpenImage = new OpenFileDialog()
                {
                    Title = "Open Music's Image",
                    Filter = "Image Files(*.jpg; *.png; *.gif; *.bmp)| *.jpg; *.png; *.gif; *.bmp",
                    Multiselect = false
                };
                if (OpenImage.ShowDialog() == DialogResult.OK)
                {
                    ImageMusic.Image.Dispose();
                    ImageMusic.Image = Image.FromFile(OpenImage.FileName);
                    File.Delete(Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(ImageMusic.Tag.ToString())));
                    File.Copy(OpenImage.FileName, Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(ImageMusic.Tag.ToString())));
                    ChoosingAnotherMusic?.Invoke(this, e);
                }
            }
        }
        public void PlayClick(int i)
        {
            PlayButton_Click(PlayerDevice.Find(i).FileName);
        }

        private void PlayButton_Click(string FileName)
        {
            if (this.Controls[FileName] != null && this.Controls[FileName].Controls["PlayButton"] is PictureBox PlayButton)
            {
                PlayButton.Tag = !(PlayButton.Tag as dynamic);

                if (PlayButton.Tag as dynamic)
                {
                    PlayButton.Image = Properties.Resources.PauseThis;

                    if (PreviousMusic != FileName)
                    {
                        if (this.Controls[PreviousMusic] != null)
                        {
                            PictureBox ResetPlayButton = this.Controls[PreviousMusic].Controls["PlayButton"] as PictureBox;
                            ResetPlayButton.Image = Properties.Resources.PlayThis;
                            ResetPlayButton.Tag = false;
                        }
                        PlayerDevice.ChooseFile(PlayerDevice.FindIndex(FileName));
                        Current = this.Controls[FileName] as Panel;
                    }
                    ChoosingAnotherMusic?.Invoke(this, new EventArgs());
                    PlayerDevice.Play();
                    PlayPauseButton.Image = Properties.Resources.PauseButton_Image;
                }
                else
                {
                    PlayButton.Image = Properties.Resources.PlayThis;
                    PlayerDevice.Pause();
                    PlayPauseButton.Image = Properties.Resources.PlayButton_Image;
                }

                PreviousMusic = FileName;
            };
        }
        private void MusicListPanel_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) this.Location = new Point(this.Location.X, this.Location.Y + 10);
            else if (e.Delta < 0) this.Location = new Point(this.Location.X, this.Location.Y - 10);

            if (UpperLimit != 0 && UpperLimit > this.Location.Y + this.Height - 100)
                while (this.Location.Y < UpperLimit)
                    this.Location = new Point(this.Location.X, this.Location.Y + 1);
            if (LowerLimit != 0 && LowerLimit < this.Location.Y + 50)
                while (this.Location.Y + this.Height > LowerLimit)
                    this.Location = new Point(this.Location.X, this.Location.Y - 1);
        }

        private bool Flag;
        private int CursorLocationY;
        private int ThisLocationY;
        private void MusicPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Flag)
            {
                this.Location = new Point(this.Location.X, Cursor.Position.Y - CursorLocationY + this.Location.Y);
                MusicListPanel_Wheel(sender, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            }
            CursorLocationY = Cursor.Position.Y;
        }

        private void MusicPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Trash.Visible = true;
            Trash.BringToFront();
            Flag = true;
            ThisLocationY = this.Location.Y;
        }

        private void MusicPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Panel MusicPanel = sender as Panel;
            if (Trash.Bounds.Contains(Trash.Parent.PointToClient(Cursor.Position)))
            {
                if (MusicPanel.Name == PlayerDevice.CurrentNode.FileName)
                    PlayerDevice.StopAndDisposePlayerDevice();

                File.Delete(MusicPanel.Tag.ToString());
                PictureBox DisposeImage = MusicPanel.Controls["ImageMusic"] as PictureBox;
                DisposeImage.Image.Dispose();
                ChoosingAnotherMusic?.Invoke(this, EventArgs.Empty);
                try
                {
                    if (File.Exists(Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(MusicPanel.Tag.ToString()))))
                        File.Delete(Path.Combine(FilesPath, Path.GetFileNameWithoutExtension(MusicPanel.Tag.ToString())));
                }
                catch { }

                List<string> EditMusicsList = new List<string>();
                for (int i = 0; i < MusicFiles.Length; i++)
                    if (MusicFiles[i] != MusicPanel.Name) EditMusicsList.Add(MusicFiles[i]);
                MusicFiles = EditMusicsList.ToArray();

                this.InitializeComponent();

                while (this.Location.Y != ThisLocationY)
                {
                    if (this.Location.Y > ThisLocationY) this.Location = new Point(this.Location.X, this.Location.Y - 1);
                    else this.Location = new Point(this.Location.X, this.Location.Y + 1);
                }
            }
            Trash.Visible = false;
            Flag = false;
        }
    }
}
