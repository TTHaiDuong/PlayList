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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistForm));
            this.LeftSidePanel = new System.Windows.Forms.Panel();
            this.Panel_OpenFileButton = new System.Windows.Forms.Panel();
            this.OpenFileButton = new System.Windows.Forms.PictureBox();
            this.Panel_IconApp = new System.Windows.Forms.Panel();
            this.IconApp = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.VolumePercent = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.MusicTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeakerTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeakerButton = new System.Windows.Forms.PictureBox();
            this.PreviousSongButton = new System.Windows.Forms.PictureBox();
            this.NextSongButton = new System.Windows.Forms.PictureBox();
            this.LeftSidePanel.SuspendLayout();
            this.Panel_OpenFileButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).BeginInit();
            this.Panel_IconApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextSongButton)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftSidePanel
            // 
            this.LeftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            this.LeftSidePanel.Controls.Add(this.Panel_OpenFileButton);
            this.LeftSidePanel.Controls.Add(this.Panel_IconApp);
            this.LeftSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.LeftSidePanel.Name = "LeftSidePanel";
            this.LeftSidePanel.Size = new System.Drawing.Size(121, 577);
            this.LeftSidePanel.TabIndex = 0;
            // 
            // Panel_OpenFileButton
            // 
            this.Panel_OpenFileButton.Controls.Add(this.OpenFileButton);
            this.Panel_OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel_OpenFileButton.Location = new System.Drawing.Point(0, 205);
            this.Panel_OpenFileButton.Name = "Panel_OpenFileButton";
            this.Panel_OpenFileButton.Size = new System.Drawing.Size(121, 47);
            this.Panel_OpenFileButton.TabIndex = 4;
            this.Panel_OpenFileButton.MouseLeave += new System.EventHandler(this.MouseLeaveOpenFileButton);
            this.Panel_OpenFileButton.MouseHover += new System.EventHandler(this.MouseHoverOpenFileButton);
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
            this.OpenFileButton.Click += new System.EventHandler(this.ClickToOpenFile);
            this.OpenFileButton.MouseHover += new System.EventHandler(this.SelectOpenFileButton);
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
            this.PlayButton.Click += new System.EventHandler(this.ClickToPlay);
            // 
            // PlayPanel
            // 
            this.PlayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            this.PlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayPanel.Controls.Add(this.VolumePercent);
            this.PlayPanel.Controls.Add(this.PauseButton);
            this.PlayPanel.Controls.Add(this.MusicTrackBar);
            this.PlayPanel.Controls.Add(this.SpeakerTrackBar);
            this.PlayPanel.Controls.Add(this.SpeakerButton);
            this.PlayPanel.Controls.Add(this.PreviousSongButton);
            this.PlayPanel.Controls.Add(this.NextSongButton);
            this.PlayPanel.Controls.Add(this.PlayButton);
            this.PlayPanel.Location = new System.Drawing.Point(-16, 463);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(977, 127);
            this.PlayPanel.TabIndex = 1;
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
            this.PauseButton.Click += new System.EventHandler(this.ClickToPause);
            this.PauseButton.Visible = false;
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
            SpeakerVolumeIs = SpeakerTrackBar.Value;
            this.SpeakerTrackBar.Scroll += new System.EventHandler(this.VolumeScroll);
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
            this.SpeakerButton.Click += new System.EventHandler(this.SpeakerButtonClick);
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
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.PlayPanel);
            this.Controls.Add(this.LeftSidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(969, 624);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.LeftSidePanel.ResumeLayout(false);
            this.Panel_OpenFileButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).EndInit();
            this.Panel_IconApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            this.PlayPanel.ResumeLayout(false);
            this.PlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextSongButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftSidePanel;
        private System.Windows.Forms.Panel Panel_IconApp;
        private System.Windows.Forms.PictureBox IconApp;
        private System.Windows.Forms.Panel Panel_OpenFileButton;
        private System.Windows.Forms.PictureBox OpenFileButton;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.PictureBox PreviousSongButton;
        private System.Windows.Forms.PictureBox NextSongButton;
        private System.Windows.Forms.PictureBox SpeakerButton;
        private System.Windows.Forms.TrackBar MusicTrackBar;
        private System.Windows.Forms.TrackBar SpeakerTrackBar;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.Label VolumePercent;
    }
}

