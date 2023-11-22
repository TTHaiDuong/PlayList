using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            this.TimerMusicBar = new System.Windows.Forms.Timer(this.components);
            this.LeftSidePanel = new System.Windows.Forms.Panel();
            this.IconApp = new System.Windows.Forms.PictureBox();
            this.SearchButton = new System.Windows.Forms.PictureBox();
            this.OpenFileButton = new System.Windows.Forms.PictureBox();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.AutoNextMusic = new System.Windows.Forms.PictureBox();
            this.RepeatingButton = new System.Windows.Forms.PictureBox();
            this.SpeakerBar = new System.Windows.Forms.TrackBar();
            this.SpeakerButton = new System.Windows.Forms.PictureBox();
            this.PreviousButton = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.MusicBar = new System.Windows.Forms.TrackBar();
            this.Account = new System.Windows.Forms.Panel();
            this.CoverImage = new System.Windows.Forms.PictureBox();
            this.MusicList = new System.Windows.Forms.FlowLayoutPanel();
            this.LeftSidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).BeginInit();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatingButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).BeginInit();
            this.Account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerMusicBar
            // 
            this.TimerMusicBar.Interval = 1000;
            this.TimerMusicBar.Tick += new System.EventHandler(this.MusicBar_TimerTick);
            // 
            // LeftSidePanel
            // 
            this.LeftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.LeftSidePanel.Controls.Add(this.IconApp);
            this.LeftSidePanel.Controls.Add(this.SearchButton);
            this.LeftSidePanel.Controls.Add(this.OpenFileButton);
            this.LeftSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.LeftSidePanel.Name = "LeftSidePanel";
            this.LeftSidePanel.Size = new System.Drawing.Size(121, 577);
            this.LeftSidePanel.TabIndex = 2;
            // 
            // IconApp
            // 
            this.IconApp.Image = ((System.Drawing.Image)(resources.GetObject("IconApp.Image")));
            this.IconApp.Location = new System.Drawing.Point(22, 28);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(83, 58);
            this.IconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconApp.TabIndex = 0;
            this.IconApp.TabStop = false;
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.Location = new System.Drawing.Point(39, 262);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(34, 34);
            this.SearchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchButton.TabIndex = 1;
            this.SearchButton.TabStop = false;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.Location = new System.Drawing.Point(39, 181);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(37, 37);
            this.OpenFileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.TabStop = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // PlayPanel
            // 
            this.PlayPanel.BackColor = System.Drawing.Color.Black;
            this.PlayPanel.Controls.Add(this.PauseButton);
            this.PlayPanel.Controls.Add(this.AutoNextMusic);
            this.PlayPanel.Controls.Add(this.RepeatingButton);
            this.PlayPanel.Controls.Add(this.SpeakerBar);
            this.PlayPanel.Controls.Add(this.SpeakerButton);
            this.PlayPanel.Controls.Add(this.PreviousButton);
            this.PlayPanel.Controls.Add(this.NextButton);
            this.PlayPanel.Controls.Add(this.PlayButton);
            this.PlayPanel.Controls.Add(this.MusicBar);
            this.PlayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlayPanel.Location = new System.Drawing.Point(121, 450);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(830, 127);
            this.PlayPanel.TabIndex = 7;
            // 
            // PauseButton
            // 
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(385, 60);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(30, 30);
            this.PauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PauseButton.TabIndex = 6;
            this.PauseButton.TabStop = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // AutoNextMusic
            // 
            this.AutoNextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoNextMusic.Image = ((System.Drawing.Image)(resources.GetObject("AutoNextMusic.Image")));
            this.AutoNextMusic.Location = new System.Drawing.Point(534, 59);
            this.AutoNextMusic.Name = "AutoNextMusic";
            this.AutoNextMusic.Size = new System.Drawing.Size(30, 30);
            this.AutoNextMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AutoNextMusic.TabIndex = 9;
            this.AutoNextMusic.TabStop = false;
            this.AutoNextMusic.Click += new System.EventHandler(this.AutoNext_Click);
            // 
            // RepeatingButton
            // 
            this.RepeatingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RepeatingButton.Image = ((System.Drawing.Image)(resources.GetObject("RepeatingButton.Image")));
            this.RepeatingButton.Location = new System.Drawing.Point(228, 60);
            this.RepeatingButton.Name = "RepeatingButton";
            this.RepeatingButton.Size = new System.Drawing.Size(30, 30);
            this.RepeatingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RepeatingButton.TabIndex = 8;
            this.RepeatingButton.TabStop = false;
            this.RepeatingButton.Click += new System.EventHandler(this.Repeating_Click);
            // 
            // SpeakerBar
            // 
            this.SpeakerBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerBar.LargeChange = 15;
            this.SpeakerBar.Location = new System.Drawing.Point(650, 59);
            this.SpeakerBar.Maximum = 100;
            this.SpeakerBar.Name = "SpeakerBar";
            this.SpeakerBar.Size = new System.Drawing.Size(113, 56);
            this.SpeakerBar.TabIndex = 3;
            this.SpeakerBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeakerBar.Scroll += new System.EventHandler(this.SpeakerBar_Scroll);
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("SpeakerButton.Image")));
            this.SpeakerButton.Location = new System.Drawing.Point(614, 59);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(30, 30);
            this.SpeakerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpeakerButton.TabIndex = 5;
            this.SpeakerButton.TabStop = false;
            this.SpeakerButton.Click += new System.EventHandler(this.Speaker_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousButton.Image")));
            this.PreviousButton.Location = new System.Drawing.Point(318, 60);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(30, 30);
            this.PreviousButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousButton.TabIndex = 3;
            this.PreviousButton.TabStop = false;
            this.PreviousButton.Click += new System.EventHandler(this.Previous_Click);
            // 
            // NextButton
            // 
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.Location = new System.Drawing.Point(451, 60);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(30, 30);
            this.NextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextButton.TabIndex = 2;
            this.NextButton.TabStop = false;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(385, 60);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(30, 30);
            this.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayButton.TabIndex = 1;
            this.PlayButton.TabStop = false;
            this.PlayButton.Click += new System.EventHandler(this.Play_Click);
            // 
            // MusicBar
            // 
            this.MusicBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MusicBar.Location = new System.Drawing.Point(185, 21);
            this.MusicBar.Name = "MusicBar";
            this.MusicBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MusicBar.Size = new System.Drawing.Size(578, 56);
            this.MusicBar.TabIndex = 2;
            this.MusicBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MusicBar.Scroll += new System.EventHandler(this.MusicBar_Scroll);
            // 
            // Account
            // 
            this.Account.Controls.Add(this.CoverImage);
            this.Account.Dock = System.Windows.Forms.DockStyle.Top;
            this.Account.Location = new System.Drawing.Point(121, 0);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(830, 209);
            this.Account.TabIndex = 8;
            // 
            // CoverImage
            // 
            this.CoverImage.ImageLocation = "20";
            this.CoverImage.Location = new System.Drawing.Point(0, 0);
            this.CoverImage.Name = "CoverImage";
            this.CoverImage.Size = new System.Drawing.Size(830, 209);
            this.CoverImage.TabIndex = 0;
            this.CoverImage.TabStop = false;
            // 
            // MusicList
            // 
            this.MusicList.AutoSize = true;
            this.MusicList.BackColor = System.Drawing.Color.Transparent;
            this.MusicList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MusicList.Location = new System.Drawing.Point(124, 215);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(200, 100);
            this.MusicList.TabIndex = 9;
            this.MusicList.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MusicList_Wheel);
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.PlayPanel);
            this.Controls.Add(this.MusicList);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.LeftSidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(969, 624);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.LeftSidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileButton)).EndInit();
            this.PlayPanel.ResumeLayout(false);
            this.PlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoNextMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatingButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).EndInit();
            this.Account.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TimerMusicBar;
        private System.Windows.Forms.Panel LeftSidePanel;
        private System.Windows.Forms.PictureBox IconApp;
        private System.Windows.Forms.PictureBox SearchButton;
        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.PictureBox AutoNextMusic;
        private System.Windows.Forms.PictureBox RepeatingButton;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.TrackBar MusicBar;
        private System.Windows.Forms.TrackBar SpeakerBar;
        private System.Windows.Forms.PictureBox SpeakerButton;
        private System.Windows.Forms.PictureBox PreviousButton;
        private System.Windows.Forms.PictureBox NextButton;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.Panel Account;
        private System.Windows.Forms.FlowLayoutPanel MusicList;
        private System.Windows.Forms.PictureBox CoverImage;
        private System.Windows.Forms.PictureBox OpenFileButton;
    }
}

