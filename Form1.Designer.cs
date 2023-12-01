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
            this.SearchButton = new System.Windows.Forms.PictureBox();
            this.TotalTime = new System.Windows.Forms.Label();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.PlayPanel = new System.Windows.Forms.Panel();
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
            this.ImageMusicPlaying1 = new System.Windows.Forms.PictureBox();
            this.Trash = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trash)).BeginInit();
            this.TopPanel.SuspendLayout();
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
            this.LeftPanel.Size = new System.Drawing.Size(115, 577);
            this.LeftPanel.TabIndex = 20;
            // 
            // IconApp
            // 
            this.IconApp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IconApp.Image = ((System.Drawing.Image)(resources.GetObject("IconApp.Image")));
            this.IconApp.Location = new System.Drawing.Point(12, 73);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(83, 58);
            this.IconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconApp.TabIndex = 0;
            this.IconApp.TabStop = false;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.Location = new System.Drawing.Point(39, 233);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(37, 37);
            this.OpenFileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.TabStop = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.Location = new System.Drawing.Point(812, 34);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(34, 34);
            this.SearchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchButton.TabIndex = 1;
            this.SearchButton.TabStop = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TotalTime
            // 
            this.TotalTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TotalTime.AutoSize = true;
            this.TotalTime.ForeColor = System.Drawing.Color.White;
            this.TotalTime.Location = new System.Drawing.Point(812, 20);
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
            this.CurrentTime.Location = new System.Drawing.Point(180, 20);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(0, 18);
            this.CurrentTime.TabIndex = 17;
            // 
            // PlayPanel
            // 
            this.PlayPanel.BackColor = System.Drawing.Color.Black;
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
            this.PlayPanel.Location = new System.Drawing.Point(115, 450);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(867, 127);
            this.PlayPanel.TabIndex = 19;
            // 
            // RepeatingButton
            // 
            this.RepeatingButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RepeatingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RepeatingButton.Image = ((System.Drawing.Image)(resources.GetObject("RepeatingButton.Image")));
            this.RepeatingButton.Location = new System.Drawing.Point(271, 59);
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
            this.OnRepeating.Location = new System.Drawing.Point(271, 82);
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
            this.AutoNextMusic.Location = new System.Drawing.Point(577, 58);
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
            this.ImageMusicPlaying2.Location = new System.Drawing.Point(18, 0);
            this.ImageMusicPlaying2.Name = "ImageMusicPlaying2";
            this.ImageMusicPlaying2.Size = new System.Drawing.Size(127, 127);
            this.ImageMusicPlaying2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageMusicPlaying2.TabIndex = 17;
            this.ImageMusicPlaying2.TabStop = false;
            // 
            // SpeakerBar
            // 
            this.SpeakerBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SpeakerBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerBar.LargeChange = 15;
            this.SpeakerBar.Location = new System.Drawing.Point(693, 58);
            this.SpeakerBar.Maximum = 100;
            this.SpeakerBar.Name = "SpeakerBar";
            this.SpeakerBar.Size = new System.Drawing.Size(113, 56);
            this.SpeakerBar.TabIndex = 3;
            this.SpeakerBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeakerBar.Value = 100;
            this.SpeakerBar.Scroll += new System.EventHandler(this.SpeakerBar_Scroll);
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SpeakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("SpeakerButton.Image")));
            this.SpeakerButton.Location = new System.Drawing.Point(657, 58);
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
            this.PreviousButton.Location = new System.Drawing.Point(361, 59);
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
            this.NextButton.Location = new System.Drawing.Point(494, 59);
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
            this.PlayPauseButton.Location = new System.Drawing.Point(428, 59);
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
            this.MusicBar.Location = new System.Drawing.Point(228, 20);
            this.MusicBar.Name = "MusicBar";
            this.MusicBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MusicBar.Size = new System.Drawing.Size(578, 56);
            this.MusicBar.TabIndex = 2;
            this.MusicBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MusicBar.Scroll += new System.EventHandler(this.MusicBar_Scroll);
            // 
            // OnAutoNext
            // 
            this.OnAutoNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OnAutoNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OnAutoNext.Image = ((System.Drawing.Image)(resources.GetObject("OnAutoNext.Image")));
            this.OnAutoNext.Location = new System.Drawing.Point(577, 82);
            this.OnAutoNext.Name = "OnAutoNext";
            this.OnAutoNext.Size = new System.Drawing.Size(30, 30);
            this.OnAutoNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OnAutoNext.TabIndex = 19;
            this.OnAutoNext.TabStop = false;
            // 
            // ImageMusicPlaying1
            // 
            this.ImageMusicPlaying1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageMusicPlaying1.Location = new System.Drawing.Point(743, 203);
            this.ImageMusicPlaying1.Name = "ImageMusicPlaying1";
            this.ImageMusicPlaying1.Size = new System.Drawing.Size(210, 210);
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
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.TopPanel.Controls.Add(this.SearchTextBox);
            this.TopPanel.Controls.Add(this.SearchButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(115, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(867, 100);
            this.TopPanel.TabIndex = 21;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.SearchTextBox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.ForeColor = System.Drawing.Color.White;
            this.SearchTextBox.Location = new System.Drawing.Point(18, 34);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(788, 30);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(148, 329);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(589, 84);
            this.listBox1.TabIndex = 22;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(982, 577);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.PlayPanel);
            this.Controls.Add(this.ImageMusicPlaying1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.Trash);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 624);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playlist";
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.ImageMusicPlaying1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trash)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox OnAutoNext;
        private System.Windows.Forms.PictureBox OnRepeating;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}

