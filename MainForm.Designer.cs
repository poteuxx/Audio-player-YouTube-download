#pragma warning disable
using AudioPlayer.Properties;
using System.ComponentModel;

namespace AudioPlayer
{
    partial class MainForm
    {
        private System.Windows.Forms.Panel panelVolume;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.ListBox listBoxDownloads;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnExit;

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnDownload = new System.Windows.Forms.Button();
            this.panelVolume = new System.Windows.Forms.Panel();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.btnVolume = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.listBoxDownloads = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNews = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnPlayAndPause = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelNews = new System.Windows.Forms.Panel();
            this.labelforNewsTexts = new System.Windows.Forms.Label();
            this.btnExit2NewsForm = new System.Windows.Forms.Button();
            this.labelforNews = new System.Windows.Forms.Label();
            this.panelTimeline = new System.Windows.Forms.Panel();
            this.panelVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelNews.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownload.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDownload.Location = new System.Drawing.Point(2, 284);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(73, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // panelVolume
            // 
            this.panelVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.panelVolume.Controls.Add(this.trackBarVolume);
            this.panelVolume.Location = new System.Drawing.Point(290, 196);
            this.panelVolume.Name = "panelVolume";
            this.panelVolume.Size = new System.Drawing.Size(23, 111);
            this.panelVolume.TabIndex = 1;
            this.panelVolume.Visible = false;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.trackBarVolume.Location = new System.Drawing.Point(3, 3);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(18, 105);
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Visible = false;
            // 
            // btnVolume
            // 
            this.btnVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnVolume.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolume.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVolume.Location = new System.Drawing.Point(224, 284);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(73, 23);
            this.btnVolume.TabIndex = 13;
            this.btnVolume.Text = "Volume";
            this.btnVolume.UseVisualStyleBackColor = false;
            this.btnVolume.Click += new System.EventHandler(this.BtnVolume_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFolder.Location = new System.Drawing.Point(81, 284);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(73, 23);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "Folder";
            this.btnFolder.UseVisualStyleBackColor = false;
            this.btnFolder.Click += new System.EventHandler(this.BtnFolder_Click);
            // 
            // listBoxDownloads
            // 
            this.listBoxDownloads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.listBoxDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxDownloads.ForeColor = System.Drawing.SystemColors.Control;
            this.listBoxDownloads.FormattingEnabled = true;
            this.listBoxDownloads.Location = new System.Drawing.Point(2, 33);
            this.listBoxDownloads.Name = "listBoxDownloads";
            this.listBoxDownloads.Size = new System.Drawing.Size(369, 182);
            this.listBoxDownloads.Sorted = true;
            this.listBoxDownloads.TabIndex = 3;
            this.listBoxDownloads.SelectedIndexChanged += new System.EventHandler(this.ListBoxDownloads_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.panel1.Controls.Add(this.btnNews);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 33);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // btnNews
            // 
            this.btnNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnNews.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNews.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNews.Location = new System.Drawing.Point(38, 5);
            this.btnNews.Name = "btnNews";
            this.btnNews.Size = new System.Drawing.Size(46, 24);
            this.btnNews.TabIndex = 17;
            this.btnNews.Text = "News";
            this.btnNews.UseVisualStyleBackColor = false;
            this.btnNews.Click += new System.EventHandler(this.BtnNews_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(274, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 24);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AudioPlayer.Properties.Resources.music_video;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(344, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 24);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Pill Gothic 600mg Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio player";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.progressBar.ForeColor = System.Drawing.Color.DarkRed;
            this.progressBar.Location = new System.Drawing.Point(2, 238);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(372, 5);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            this.progressBar.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDuration.Location = new System.Drawing.Point(169, 249);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(40, 13);
            this.lblDuration.TabIndex = 6;
            this.lblDuration.Text = "00 : 00";
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.txtUrl.Location = new System.Drawing.Point(2, 265);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(372, 13);
            this.txtUrl.TabIndex = 9;
            // 
            // btnPlayAndPause
            // 
            this.btnPlayAndPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnPlayAndPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlayAndPause.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPlayAndPause.Location = new System.Drawing.Point(303, 284);
            this.btnPlayAndPause.Name = "btnPlayAndPause";
            this.btnPlayAndPause.Size = new System.Drawing.Size(73, 23);
            this.btnPlayAndPause.TabIndex = 12;
            this.btnPlayAndPause.Text = "Play";
            this.btnPlayAndPause.UseVisualStyleBackColor = false;
            this.btnPlayAndPause.Click += new System.EventHandler(this.BtnPlayAndPause_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPrevious.Location = new System.Drawing.Point(160, 285);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 23);
            this.btnPrevious.TabIndex = 14;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNext.Location = new System.Drawing.Point(191, 285);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // panelNews
            // 
            this.panelNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.panelNews.Controls.Add(this.labelforNewsTexts);
            this.panelNews.Controls.Add(this.btnExit2NewsForm);
            this.panelNews.Controls.Add(this.labelforNews);
            this.panelNews.Location = new System.Drawing.Point(2, 90);
            this.panelNews.Name = "panelNews";
            this.panelNews.Size = new System.Drawing.Size(200, 125);
            this.panelNews.TabIndex = 16;
            this.panelNews.Visible = false;
            // 
            // labelforNewsTexts
            // 
            this.labelforNewsTexts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelforNewsTexts.Font = new System.Drawing.Font("Pill Gothic 600mg Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforNewsTexts.ForeColor = System.Drawing.Color.DimGray;
            this.labelforNewsTexts.Location = new System.Drawing.Point(3, 55);
            this.labelforNewsTexts.Name = "labelforNewsTexts";
            this.labelforNewsTexts.Size = new System.Drawing.Size(175, 64);
            this.labelforNewsTexts.TabIndex = 18;
            this.labelforNewsTexts.Text = "Fixes bugs\r\nUpdated features\r\nAdded News panel\r\nAdded Random play";
            // 
            // btnExit2NewsForm
            // 
            this.btnExit2NewsForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.btnExit2NewsForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit2NewsForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit2NewsForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit2NewsForm.Location = new System.Drawing.Point(180, 0);
            this.btnExit2NewsForm.Name = "btnExit2NewsForm";
            this.btnExit2NewsForm.Size = new System.Drawing.Size(20, 20);
            this.btnExit2NewsForm.TabIndex = 17;
            this.btnExit2NewsForm.Text = "X";
            this.btnExit2NewsForm.UseVisualStyleBackColor = false;
            this.btnExit2NewsForm.Click += new System.EventHandler(this.BtnExit2NewsForm_Click);
            // 
            // labelforNews
            // 
            this.labelforNews.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelforNews.Font = new System.Drawing.Font("Pill Gothic 600mg Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforNews.ForeColor = System.Drawing.Color.DimGray;
            this.labelforNews.Location = new System.Drawing.Point(3, 23);
            this.labelforNews.Name = "labelforNews";
            this.labelforNews.Size = new System.Drawing.Size(83, 32);
            this.labelforNews.TabIndex = 1;
            this.labelforNews.Text = "Last update 10-18-2024";
            // 
            // panelTimeline
            // 
            this.panelTimeline.BackColor = System.Drawing.Color.Black;
            this.panelTimeline.Location = new System.Drawing.Point(2, 236);
            this.panelTimeline.Name = "panelTimeline";
            this.panelTimeline.Size = new System.Drawing.Size(6, 7);
            this.panelTimeline.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(375, 310);
            this.Controls.Add(this.panelTimeline);
            this.Controls.Add(this.panelNews);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panelVolume);
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.btnPlayAndPause);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxDownloads);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Audio Player";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.panelVolume.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelNews.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlayAndPause;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNews;
        private System.Windows.Forms.Panel panelNews;
        private System.Windows.Forms.Button btnExit2NewsForm;
        private System.Windows.Forms.Label labelforNews;
        private System.Windows.Forms.Label labelforNewsTexts;
        private System.Windows.Forms.Panel panelTimeline;
    }
}
