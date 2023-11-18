namespace Playlist
{
    partial class PlaylistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistForm));
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.MessageBox = new System.Windows.Forms.Label();
            this.AutoNextMusic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VolumePercent = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.MusicTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeakerTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeakerButton = new System.Windows.Forms.PictureBox();
            this.PreviousSongButton = new System.Windows.Forms.PictureBox();
            this.NextSongButton = new System.Windows.Forms.PictureBox();
            this.TimerForMusicBar = new System.Windows.Forms.Timer(this.components);
            this.LeftSidePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Panel_OpenFileButton = new System.Windows.Forms.Panel();
            this.OpenFileButton = new System.Windows.Forms.PictureBox();
            this.Panel_IconApp = new System.Windows.Forms.Panel();
            this.IconApp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MusicList = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextSongButton)).BeginInit();
            this.LeftSidePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Panel_OpenFileButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).BeginInit();
            this.Panel_IconApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(466, 14);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(30, 30);
            this.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayButton.TabIndex = 1;
            this.PlayButton.TabStop = false;
            this.PlayButton.Click += new System.EventHandler(this.Play_Click);
            // 
            // PlayPanel
            // 
            this.PlayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            this.PlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayPanel.Controls.Add(this.MessageBox);
            this.PlayPanel.Controls.Add(this.AutoNextMusic);
            this.PlayPanel.Controls.Add(this.pictureBox1);
            this.PlayPanel.Controls.Add(this.VolumePercent);
            this.PlayPanel.Controls.Add(this.PauseButton);
            this.PlayPanel.Controls.Add(this.MusicTrackBar);
            this.PlayPanel.Controls.Add(this.SpeakerTrackBar);
            this.PlayPanel.Controls.Add(this.SpeakerButton);
            this.PlayPanel.Controls.Add(this.PreviousSongButton);
            this.PlayPanel.Controls.Add(this.NextSongButton);
            this.PlayPanel.Controls.Add(this.PlayButton);
            this.PlayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlayPanel.Location = new System.Drawing.Point(0, 450);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(951, 127);
            this.PlayPanel.TabIndex = 1;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(11, 93);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(178, 24);
            this.MessageBox.TabIndex = 10;
            this.MessageBox.Text = "label2";
            // 
            // AutoNextMusic
            // 
            this.AutoNextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoNextMusic.Image = ((System.Drawing.Image)(resources.GetObject("AutoNextMusic.Image")));
            this.AutoNextMusic.Location = new System.Drawing.Point(615, 13);
            this.AutoNextMusic.Name = "AutoNextMusic";
            this.AutoNextMusic.Size = new System.Drawing.Size(30, 30);
            this.AutoNextMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AutoNextMusic.TabIndex = 9;
            this.AutoNextMusic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(310, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Repeating_Click);
            // 
            // VolumePercent
            // 
            this.VolumePercent.AutoSize = true;
            this.VolumePercent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.VolumePercent.Location = new System.Drawing.Point(887, 57);
            this.VolumePercent.Name = "VolumePercent";
            this.VolumePercent.Size = new System.Drawing.Size(28, 16);
            this.VolumePercent.TabIndex = 7;
            this.VolumePercent.Text = "100";
            // 
            // PauseButton
            // 
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(466, 14);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(30, 30);
            this.PauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PauseButton.TabIndex = 6;
            this.PauseButton.TabStop = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // MusicTrackBar
            // 
            this.MusicTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MusicTrackBar.Location = new System.Drawing.Point(291, 57);
            this.MusicTrackBar.Name = "MusicTrackBar";
            this.MusicTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MusicTrackBar.Size = new System.Drawing.Size(377, 56);
            this.MusicTrackBar.TabIndex = 2;
            this.MusicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MusicTrackBar.Scroll += new System.EventHandler(this.MusicBar_Scroll);
            // 
            // SpeakerTrackBar
            // 
            this.SpeakerTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerTrackBar.LargeChange = 15;
            this.SpeakerTrackBar.Location = new System.Drawing.Point(777, 49);
            this.SpeakerTrackBar.Maximum = 100;
            this.SpeakerTrackBar.Name = "SpeakerTrackBar";
            this.SpeakerTrackBar.Size = new System.Drawing.Size(113, 56);
            this.SpeakerTrackBar.TabIndex = 3;
            this.SpeakerTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeakerTrackBar.Value = 100;
            this.SpeakerTrackBar.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("SpeakerButton.Image")));
            this.SpeakerButton.Location = new System.Drawing.Point(741, 49);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(30, 30);
            this.SpeakerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpeakerButton.TabIndex = 5;
            this.SpeakerButton.TabStop = false;
            this.SpeakerButton.Click += new System.EventHandler(this.Speaker_Click);
            // 
            // PreviousSongButton
            // 
            this.PreviousSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousSongButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousSongButton.Image")));
            this.PreviousSongButton.Location = new System.Drawing.Point(399, 14);
            this.PreviousSongButton.Name = "PreviousSongButton";
            this.PreviousSongButton.Size = new System.Drawing.Size(30, 30);
            this.PreviousSongButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousSongButton.TabIndex = 3;
            this.PreviousSongButton.TabStop = false;
            this.PreviousSongButton.Click += new System.EventHandler(this.PreviousMusic_Click);
            // 
            // NextSongButton
            // 
            this.NextSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextSongButton.Image = ((System.Drawing.Image)(resources.GetObject("NextSongButton.Image")));
            this.NextSongButton.Location = new System.Drawing.Point(532, 14);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(30, 30);
            this.NextSongButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextSongButton.TabIndex = 2;
            this.NextSongButton.TabStop = false;
            this.NextSongButton.Click += new System.EventHandler(this.NextVideo_Click);
            // 
            // TimerForMusicBar
            // 
            this.TimerForMusicBar.Interval = 1000;
            this.TimerForMusicBar.Tick += new System.EventHandler(this.MusicBar_TimerTick);
            // 
            // LeftSidePanel
            // 
            this.LeftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            this.LeftSidePanel.Controls.Add(this.panel1);
            this.LeftSidePanel.Controls.Add(this.Panel_OpenFileButton);
            this.LeftSidePanel.Controls.Add(this.Panel_IconApp);
            this.LeftSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.LeftSidePanel.Name = "LeftSidePanel";
            this.LeftSidePanel.Size = new System.Drawing.Size(121, 450);
            this.LeftSidePanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 47);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Panel_OpenFileButton
            // 
            this.Panel_OpenFileButton.Controls.Add(this.OpenFileButton);
            this.Panel_OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel_OpenFileButton.Location = new System.Drawing.Point(0, 169);
            this.Panel_OpenFileButton.Name = "Panel_OpenFileButton";
            this.Panel_OpenFileButton.Size = new System.Drawing.Size(121, 47);
            this.Panel_OpenFileButton.TabIndex = 4;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.Location = new System.Drawing.Point(40, 3);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(37, 37);
            this.OpenFileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.TabStop = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Panel_IconApp
            // 
            this.Panel_IconApp.Controls.Add(this.IconApp);
            this.Panel_IconApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_IconApp.Location = new System.Drawing.Point(0, 0);
            this.Panel_IconApp.Name = "Panel_IconApp";
            this.Panel_IconApp.Size = new System.Drawing.Size(121, 144);
            this.Panel_IconApp.TabIndex = 2;
            // 
            // IconApp
            // 
            this.IconApp.Image = ((System.Drawing.Image)(resources.GetObject("IconApp.Image")));
            this.IconApp.Location = new System.Drawing.Point(21, 25);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(83, 58);
            this.IconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconApp.TabIndex = 0;
            this.IconApp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // MusicList
            // 
            this.MusicList.Location = new System.Drawing.Point(333, 43);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(506, 189);
            this.MusicList.TabIndex = 5;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.MusicList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LeftSidePanel);
            this.Controls.Add(this.PlayPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(969, 624);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            this.PlayPanel.ResumeLayout(false);
            this.PlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextSongButton)).EndInit();
            this.LeftSidePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Panel_OpenFileButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).EndInit();
            this.Panel_IconApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.PictureBox PreviousSongButton;
        private System.Windows.Forms.PictureBox NextSongButton;
        private System.Windows.Forms.PictureBox SpeakerButton;
        private System.Windows.Forms.TrackBar MusicTrackBar;
        private System.Windows.Forms.TrackBar SpeakerTrackBar;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.Label VolumePercent;
        private System.Windows.Forms.Timer TimerForMusicBar;
        private System.Windows.Forms.Panel LeftSidePanel;
        private System.Windows.Forms.Panel Panel_OpenFileButton;
        private System.Windows.Forms.PictureBox OpenFileButton;
        private System.Windows.Forms.Panel Panel_IconApp;
        private System.Windows.Forms.PictureBox IconApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox AutoNextMusic;
        private System.Windows.Forms.Label MessageBox;
        private System.Windows.Forms.FlowLayoutPanel MusicList;
    }
}

