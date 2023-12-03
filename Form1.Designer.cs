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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.IconApp = new System.Windows.Forms.PictureBox();
            this.OpenFileButton = new System.Windows.Forms.PictureBox();
            this.TotalTime = new System.Windows.Forms.Label();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.MusicName = new System.Windows.Forms.Label();
            this.RepeatingButton = new System.Windows.Forms.PictureBox();
            this.OnRepeating = new System.Windows.Forms.PictureBox();
            this.AutoNextMusic = new System.Windows.Forms.PictureBox();
            this.ImageMusicPlaying2 = new System.Windows.Forms.PictureBox();
            this.SpeakerBar = new System.Windows.Forms.TrackBar();
            this.SpeakerButton = new System.Windows.Forms.PictureBox();
            this.PreviousButton = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.PictureBox();
            this.PlayPauseButton = new System.Windows.Forms.PictureBox();
            this.MusicBar = new System.Windows.Forms.TrackBar();
            this.OnAutoNext = new System.Windows.Forms.PictureBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.PictureBox();
            this.CoverImage = new System.Windows.Forms.PictureBox();
            this.ImageMusicPlaying1 = new System.Windows.Forms.PictureBox();
            this.Trash = new System.Windows.Forms.PictureBox();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).BeginInit();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatingButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnRepeating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayPauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnAutoNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trash)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.LeftPanel.Controls.Add(this.IconApp);
            this.LeftPanel.Controls.Add(this.OpenFileButton);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(105, 753);
            this.LeftPanel.TabIndex = 20;
            // 
            // IconApp
            // 
            this.IconApp.Image = ((System.Drawing.Image)(resources.GetObject("IconApp.Image")));
            this.IconApp.Location = new System.Drawing.Point(26, 45);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(62, 65);
            this.IconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconApp.TabIndex = 0;
            this.IconApp.TabStop = false;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.Location = new System.Drawing.Point(26, 337);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(50, 45);
            this.OpenFileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.TabStop = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // TotalTime
            // 
            this.TotalTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TotalTime.AutoSize = true;
            this.TotalTime.ForeColor = System.Drawing.Color.White;
            this.TotalTime.Location = new System.Drawing.Point(1087, 24);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(0, 16);
            this.TotalTime.TabIndex = 18;
            // 
            // CurrentTime
            // 
            this.CurrentTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTime.ForeColor = System.Drawing.Color.White;
            this.CurrentTime.Location = new System.Drawing.Point(268, 24);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(0, 18);
            this.CurrentTime.TabIndex = 17;
            // 
            // PlayPanel
            // 
            this.PlayPanel.BackColor = System.Drawing.Color.Black;
            this.PlayPanel.Controls.Add(this.MusicName);
            this.PlayPanel.Controls.Add(this.RepeatingButton);
            this.PlayPanel.Controls.Add(this.OnRepeating);
            this.PlayPanel.Controls.Add(this.AutoNextMusic);
            this.PlayPanel.Controls.Add(this.TotalTime);
            this.PlayPanel.Controls.Add(this.CurrentTime);
            this.PlayPanel.Controls.Add(this.ImageMusicPlaying2);
            this.PlayPanel.Controls.Add(this.SpeakerBar);
            this.PlayPanel.Controls.Add(this.SpeakerButton);
            this.PlayPanel.Controls.Add(this.PreviousButton);
            this.PlayPanel.Controls.Add(this.NextButton);
            this.PlayPanel.Controls.Add(this.PlayPauseButton);
            this.PlayPanel.Controls.Add(this.MusicBar);
            this.PlayPanel.Controls.Add(this.OnAutoNext);
            this.PlayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlayPanel.Location = new System.Drawing.Point(105, 626);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(1277, 127);
            this.PlayPanel.TabIndex = 19;
            // 
            // MusicName
            // 
            this.MusicName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MusicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicName.ForeColor = System.Drawing.Color.White;
            this.MusicName.Location = new System.Drawing.Point(242, 68);
            this.MusicName.Name = "MusicName";
            this.MusicName.Size = new System.Drawing.Size(189, 50);
            this.MusicName.TabIndex = 21;
            // 
            // RepeatingButton
            // 
            this.RepeatingButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RepeatingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RepeatingButton.Image = ((System.Drawing.Image)(resources.GetObject("RepeatingButton.Image")));
            this.RepeatingButton.Location = new System.Drawing.Point(476, 59);
            this.RepeatingButton.Name = "RepeatingButton";
            this.RepeatingButton.Size = new System.Drawing.Size(30, 30);
            this.RepeatingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RepeatingButton.TabIndex = 8;
            this.RepeatingButton.TabStop = false;
            this.RepeatingButton.Click += new System.EventHandler(this.Repeating_Click);
            // 
            // OnRepeating
            // 
            this.OnRepeating.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OnRepeating.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OnRepeating.Image = ((System.Drawing.Image)(resources.GetObject("OnRepeating.Image")));
            this.OnRepeating.Location = new System.Drawing.Point(476, 82);
            this.OnRepeating.Name = "OnRepeating";
            this.OnRepeating.Size = new System.Drawing.Size(30, 30);
            this.OnRepeating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OnRepeating.TabIndex = 20;
            this.OnRepeating.TabStop = false;
            // 
            // AutoNextMusic
            // 
            this.AutoNextMusic.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AutoNextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoNextMusic.Image = ((System.Drawing.Image)(resources.GetObject("AutoNextMusic.Image")));
            this.AutoNextMusic.Location = new System.Drawing.Point(782, 58);
            this.AutoNextMusic.Name = "AutoNextMusic";
            this.AutoNextMusic.Size = new System.Drawing.Size(30, 30);
            this.AutoNextMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AutoNextMusic.TabIndex = 9;
            this.AutoNextMusic.TabStop = false;
            this.AutoNextMusic.Click += new System.EventHandler(this.AutoNext_Click);
            // 
            // ImageMusicPlaying2
            // 
            this.ImageMusicPlaying2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ImageMusicPlaying2.Location = new System.Drawing.Point(60, 0);
            this.ImageMusicPlaying2.Name = "ImageMusicPlaying2";
            this.ImageMusicPlaying2.Size = new System.Drawing.Size(163, 127);
            this.ImageMusicPlaying2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageMusicPlaying2.TabIndex = 17;
            this.ImageMusicPlaying2.TabStop = false;
            // 
            // SpeakerBar
            // 
            this.SpeakerBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SpeakerBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerBar.LargeChange = 15;
            this.SpeakerBar.Location = new System.Drawing.Point(898, 58);
            this.SpeakerBar.Maximum = 100;
            this.SpeakerBar.Name = "SpeakerBar";
            this.SpeakerBar.Size = new System.Drawing.Size(113, 56);
            this.SpeakerBar.TabIndex = 2;
            this.SpeakerBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeakerBar.Value = 100;
            this.SpeakerBar.Scroll += new System.EventHandler(this.SpeakerBar_Scroll);
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SpeakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("SpeakerButton.Image")));
            this.SpeakerButton.Location = new System.Drawing.Point(862, 58);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(30, 30);
            this.SpeakerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpeakerButton.TabIndex = 5;
            this.SpeakerButton.TabStop = false;
            this.SpeakerButton.Click += new System.EventHandler(this.Speaker_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousButton.Image")));
            this.PreviousButton.Location = new System.Drawing.Point(566, 59);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(30, 30);
            this.PreviousButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousButton.TabIndex = 3;
            this.PreviousButton.TabStop = false;
            this.PreviousButton.Click += new System.EventHandler(this.Previous_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.Location = new System.Drawing.Point(699, 59);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(30, 30);
            this.NextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextButton.TabIndex = 2;
            this.NextButton.TabStop = false;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayPauseButton.Image")));
            this.PlayPauseButton.Location = new System.Drawing.Point(633, 59);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(30, 30);
            this.PlayPauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayPauseButton.TabIndex = 1;
            this.PlayPauseButton.TabStop = false;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // MusicBar
            // 
            this.MusicBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MusicBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MusicBar.Location = new System.Drawing.Point(333, 20);
            this.MusicBar.Name = "MusicBar";
            this.MusicBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MusicBar.Size = new System.Drawing.Size(721, 56);
            this.MusicBar.TabIndex = 1;
            this.MusicBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MusicBar.Scroll += new System.EventHandler(this.MusicBar_Scroll);
            // 
            // OnAutoNext
            // 
            this.OnAutoNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OnAutoNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OnAutoNext.Image = ((System.Drawing.Image)(resources.GetObject("OnAutoNext.Image")));
            this.OnAutoNext.Location = new System.Drawing.Point(782, 82);
            this.OnAutoNext.Name = "OnAutoNext";
            this.OnAutoNext.Size = new System.Drawing.Size(30, 30);
            this.OnAutoNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OnAutoNext.TabIndex = 19;
            this.OnAutoNext.TabStop = false;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.ForeColor = System.Drawing.SystemColors.Window;
            this.SearchBox.Location = new System.Drawing.Point(581, 57);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(324, 26);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.SearchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.Location = new System.Drawing.Point(526, 57);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(34, 34);
            this.SearchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchButton.TabIndex = 1;
            this.SearchButton.TabStop = false;
            // 
            // CoverImage
            // 
            this.CoverImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CoverImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.CoverImage.InitialImage = null;
            this.CoverImage.Location = new System.Drawing.Point(105, 0);
            this.CoverImage.Name = "CoverImage";
            this.CoverImage.Size = new System.Drawing.Size(1277, 163);
            this.CoverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CoverImage.TabIndex = 21;
            this.CoverImage.TabStop = false;
            this.CoverImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CoverImage_RightClick);
            // 
            // ImageMusicPlaying1
            // 
            this.ImageMusicPlaying1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageMusicPlaying1.BackColor = System.Drawing.Color.Transparent;
            this.ImageMusicPlaying1.Location = new System.Drawing.Point(743, 203);
            this.ImageMusicPlaying1.Name = "ImageMusicPlaying1";
            this.ImageMusicPlaying1.Size = new System.Drawing.Size(610, 386);
            this.ImageMusicPlaying1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageMusicPlaying1.TabIndex = 18;
            this.ImageMusicPlaying1.TabStop = false;
            // 
            // Trash
            // 
            this.Trash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Trash.Image = ((System.Drawing.Image)(resources.GetObject("Trash.Image")));
            this.Trash.Location = new System.Drawing.Point(26, 499);
            this.Trash.Name = "Trash";
            this.Trash.Size = new System.Drawing.Size(50, 46);
            this.Trash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Trash.TabIndex = 2;
            this.Trash.TabStop = false;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.CoverImage);
            this.Controls.Add(this.PlayPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.ImageMusicPlaying1);
            this.Controls.Add(this.Trash);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playlist";
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).EndInit();
            this.PlayPanel.ResumeLayout(false);
            this.PlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatingButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnRepeating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayPauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnAutoNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Trash;
        private System.Windows.Forms.PictureBox IconApp;
        private System.Windows.Forms.PictureBox OpenFileButton;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.PictureBox SearchButton;
        private System.Windows.Forms.Label TotalTime;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.PictureBox ImageMusicPlaying2;
        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.PictureBox AutoNextMusic;
        private System.Windows.Forms.PictureBox RepeatingButton;
        private System.Windows.Forms.TrackBar SpeakerBar;
        private System.Windows.Forms.PictureBox SpeakerButton;
        private System.Windows.Forms.PictureBox PreviousButton;
        private System.Windows.Forms.PictureBox NextButton;
        private System.Windows.Forms.PictureBox PlayPauseButton;
        private System.Windows.Forms.TrackBar MusicBar;
        private System.Windows.Forms.PictureBox ImageMusicPlaying1;
        private System.Windows.Forms.PictureBox CoverImage;
        private System.Windows.Forms.PictureBox OnAutoNext;
        private System.Windows.Forms.PictureBox OnRepeating;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label MusicName;
    }
}
