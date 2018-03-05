namespace SpotifyAPI.Example
{
    partial class LocalControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.bigAlbumPicture = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.repeatShuffleLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.clientVersionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.skipBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextTextBox = new System.Windows.Forms.TextBox();
            this.playUrlBtn = new System.Windows.Forms.Button();
            this.playTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isPlayingLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.trackInfoBox = new System.Windows.Forms.GroupBox();
            this.advertLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeProgressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.albumLinkLabel = new System.Windows.Forms.LinkLabel();
            this.artistLinkLabel = new System.Windows.Forms.LinkLabel();
            this.titleLinkLabel = new System.Windows.Forms.LinkLabel();
            this.smallAlbumPicture = new System.Windows.Forms.PictureBox();
            this.volumeDownBtn = new System.Windows.Forms.Button();
            this.volumeUpBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.volumeMixerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bigAlbumPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.trackInfoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallAlbumPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // bigAlbumPicture
            // 
            this.bigAlbumPicture.Location = new System.Drawing.Point(330, 13);
            this.bigAlbumPicture.Name = "bigAlbumPicture";
            this.bigAlbumPicture.Size = new System.Drawing.Size(640, 640);
            this.bigAlbumPicture.TabIndex = 2;
            this.bigAlbumPicture.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.volumeMixerLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.volumeUpBtn);
            this.groupBox1.Controls.Add(this.volumeDownBtn);
            this.groupBox1.Controls.Add(this.repeatShuffleLabel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.versionLabel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.clientVersionLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.skipBtn);
            this.groupBox1.Controls.Add(this.prevBtn);
            this.groupBox1.Controls.Add(this.pauseBtn);
            this.groupBox1.Controls.Add(this.playBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.contextTextBox);
            this.groupBox1.Controls.Add(this.playUrlBtn);
            this.groupBox1.Controls.Add(this.playTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.isPlayingLabel);
            this.groupBox1.Controls.Add(this.volumeLabel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 286);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spotify Info";
            // 
            // repeatShuffleLabel
            // 
            this.repeatShuffleLabel.AutoSize = true;
            this.repeatShuffleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatShuffleLabel.Location = new System.Drawing.Point(146, 88);
            this.repeatShuffleLabel.Name = "repeatShuffleLabel";
            this.repeatShuffleLabel.Size = new System.Drawing.Size(13, 17);
            this.repeatShuffleLabel.TabIndex = 30;
            this.repeatShuffleLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Repeat and Shuffle:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(72, 37);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(13, 17);
            this.versionLabel.TabIndex = 28;
            this.versionLabel.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Version:";
            // 
            // clientVersionLabel
            // 
            this.clientVersionLabel.AutoSize = true;
            this.clientVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientVersionLabel.Location = new System.Drawing.Point(108, 20);
            this.clientVersionLabel.Name = "clientVersionLabel";
            this.clientVersionLabel.Size = new System.Drawing.Size(13, 17);
            this.clientVersionLabel.TabIndex = 26;
            this.clientVersionLabel.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Client-Version";
            // 
            // skipBtn
            // 
            this.skipBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipBtn.Location = new System.Drawing.Point(245, 252);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(67, 23);
            this.skipBtn.TabIndex = 24;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevBtn.Location = new System.Drawing.Point(164, 252);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(75, 23);
            this.prevBtn.TabIndex = 23;
            this.prevBtn.Text = "Previous";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn.Location = new System.Drawing.Point(83, 252);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 22;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(6, 252);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(71, 23);
            this.playBtn.TabIndex = 21;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Playing-Context:";
            // 
            // contextTextBox
            // 
            this.contextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextTextBox.Location = new System.Drawing.Point(9, 226);
            this.contextTextBox.Name = "contextTextBox";
            this.contextTextBox.Size = new System.Drawing.Size(232, 20);
            this.contextTextBox.TabIndex = 19;
            // 
            // playUrlBtn
            // 
            this.playUrlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playUrlBtn.Location = new System.Drawing.Point(247, 165);
            this.playUrlBtn.Name = "playUrlBtn";
            this.playUrlBtn.Size = new System.Drawing.Size(65, 81);
            this.playUrlBtn.TabIndex = 18;
            this.playUrlBtn.Text = "PlayURL";
            this.playUrlBtn.UseVisualStyleBackColor = true;
            this.playUrlBtn.Click += new System.EventHandler(this.playUrlBtn_Click);
            // 
            // playTextBox
            // 
            this.playTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playTextBox.Location = new System.Drawing.Point(6, 185);
            this.playTextBox.Name = "playTextBox";
            this.playTextBox.Size = new System.Drawing.Size(232, 20);
            this.playTextBox.TabIndex = 17;
            this.playTextBox.Text = "https://open.spotify.com/track/4myBMnNWZlgvVelYeTu55w";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Spotify URI or URL:";
            // 
            // isPlayingLabel
            // 
            this.isPlayingLabel.AutoSize = true;
            this.isPlayingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isPlayingLabel.Location = new System.Drawing.Point(84, 71);
            this.isPlayingLabel.Name = "isPlayingLabel";
            this.isPlayingLabel.Size = new System.Drawing.Size(13, 17);
            this.isPlayingLabel.TabIndex = 14;
            this.isPlayingLabel.Text = "-";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.Location = new System.Drawing.Point(71, 54);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(13, 17);
            this.volumeLabel.TabIndex = 13;
            this.volumeLabel.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Volume:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Is Playing:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(3, 13);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(318, 23);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Connect to Spotify";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // trackInfoBox
            // 
            this.trackInfoBox.Controls.Add(this.advertLabel);
            this.trackInfoBox.Controls.Add(this.timeLabel);
            this.trackInfoBox.Controls.Add(this.timeProgressBar);
            this.trackInfoBox.Controls.Add(this.label5);
            this.trackInfoBox.Controls.Add(this.label4);
            this.trackInfoBox.Controls.Add(this.label3);
            this.trackInfoBox.Controls.Add(this.albumLinkLabel);
            this.trackInfoBox.Controls.Add(this.artistLinkLabel);
            this.trackInfoBox.Controls.Add(this.titleLinkLabel);
            this.trackInfoBox.Controls.Add(this.smallAlbumPicture);
            this.trackInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackInfoBox.Location = new System.Drawing.Point(3, 349);
            this.trackInfoBox.Name = "trackInfoBox";
            this.trackInfoBox.Size = new System.Drawing.Size(318, 304);
            this.trackInfoBox.TabIndex = 4;
            this.trackInfoBox.TabStop = false;
            this.trackInfoBox.Text = "Track Info";
            // 
            // advertLabel
            // 
            this.advertLabel.AutoSize = true;
            this.advertLabel.Location = new System.Drawing.Point(6, 67);
            this.advertLabel.Name = "advertLabel";
            this.advertLabel.Size = new System.Drawing.Size(0, 17);
            this.advertLabel.TabIndex = 31;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(6, 279);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(13, 17);
            this.timeLabel.TabIndex = 29;
            this.timeLabel.Text = "-";
            // 
            // timeProgressBar
            // 
            this.timeProgressBar.Location = new System.Drawing.Point(6, 253);
            this.timeProgressBar.Name = "timeProgressBar";
            this.timeProgressBar.Size = new System.Drawing.Size(306, 23);
            this.timeProgressBar.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Album:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Artist:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Title:";
            // 
            // albumLinkLabel
            // 
            this.albumLinkLabel.AutoSize = true;
            this.albumLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumLinkLabel.Location = new System.Drawing.Point(63, 227);
            this.albumLinkLabel.Name = "albumLinkLabel";
            this.albumLinkLabel.Size = new System.Drawing.Size(13, 17);
            this.albumLinkLabel.TabIndex = 7;
            this.albumLinkLabel.TabStop = true;
            this.albumLinkLabel.Text = "-";
            this.albumLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artistLinkLabel
            // 
            this.artistLinkLabel.AutoSize = true;
            this.artistLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLinkLabel.Location = new System.Drawing.Point(63, 204);
            this.artistLinkLabel.Name = "artistLinkLabel";
            this.artistLinkLabel.Size = new System.Drawing.Size(13, 17);
            this.artistLinkLabel.TabIndex = 6;
            this.artistLinkLabel.TabStop = true;
            this.artistLinkLabel.Text = "-";
            this.artistLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLinkLabel
            // 
            this.titleLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLinkLabel.AutoSize = true;
            this.titleLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLinkLabel.Location = new System.Drawing.Point(63, 182);
            this.titleLinkLabel.Name = "titleLinkLabel";
            this.titleLinkLabel.Size = new System.Drawing.Size(13, 17);
            this.titleLinkLabel.TabIndex = 5;
            this.titleLinkLabel.TabStop = true;
            this.titleLinkLabel.Text = "-";
            this.titleLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smallAlbumPicture
            // 
            this.smallAlbumPicture.Location = new System.Drawing.Point(81, 19);
            this.smallAlbumPicture.Name = "smallAlbumPicture";
            this.smallAlbumPicture.Size = new System.Drawing.Size(160, 160);
            this.smallAlbumPicture.TabIndex = 5;
            this.smallAlbumPicture.TabStop = false;
            // 
            // volumeDownBtn
            // 
            this.volumeDownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeDownBtn.Location = new System.Drawing.Point(247, 134);
            this.volumeDownBtn.Margin = new System.Windows.Forms.Padding(0);
            this.volumeDownBtn.Name = "volumeDownBtn";
            this.volumeDownBtn.Size = new System.Drawing.Size(65, 24);
            this.volumeDownBtn.TabIndex = 32;
            this.volumeDownBtn.Text = "Volume-";
            this.volumeDownBtn.UseVisualStyleBackColor = true;
            this.volumeDownBtn.Click += new System.EventHandler(this.volumeDownBtn_Click);
            // 
            // volumeUpBtn
            // 
            this.volumeUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeUpBtn.Location = new System.Drawing.Point(247, 110);
            this.volumeUpBtn.Margin = new System.Windows.Forms.Padding(0);
            this.volumeUpBtn.Name = "volumeUpBtn";
            this.volumeUpBtn.Size = new System.Drawing.Size(65, 24);
            this.volumeUpBtn.TabIndex = 33;
            this.volumeUpBtn.Text = "Volume+";
            this.volumeUpBtn.UseVisualStyleBackColor = true;
            this.volumeUpBtn.Click += new System.EventHandler(this.volumeUpBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "Volume Mixer\'s volume:";
            // 
            // volumeMixerLabel
            // 
            this.volumeMixerLabel.AutoSize = true;
            this.volumeMixerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeMixerLabel.Location = new System.Drawing.Point(168, 117);
            this.volumeMixerLabel.Name = "volumeMixerLabel";
            this.volumeMixerLabel.Size = new System.Drawing.Size(13, 17);
            this.volumeMixerLabel.TabIndex = 35;
            this.volumeMixerLabel.Text = "-";
            // 
            // LocalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackInfoBox);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bigAlbumPicture);
            this.Name = "LocalControl";
            this.Size = new System.Drawing.Size(970, 670);
            ((System.ComponentModel.ISupportInitialize)(this.bigAlbumPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.trackInfoBox.ResumeLayout(false);
            this.trackInfoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallAlbumPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bigAlbumPicture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.GroupBox trackInfoBox;
        private System.Windows.Forms.PictureBox smallAlbumPicture;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label isPlayingLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playTextBox;
        private System.Windows.Forms.Button playUrlBtn;
        private System.Windows.Forms.TextBox contextTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button skipBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.LinkLabel artistLinkLabel;
        private System.Windows.Forms.LinkLabel titleLinkLabel;
        private System.Windows.Forms.LinkLabel albumLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ProgressBar timeProgressBar;
        private System.Windows.Forms.Label clientVersionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label repeatShuffleLabel;
        private System.Windows.Forms.Label advertLabel;
        private System.Windows.Forms.Button volumeUpBtn;
        private System.Windows.Forms.Button volumeDownBtn;
        private System.Windows.Forms.Label volumeMixerLabel;
        private System.Windows.Forms.Label label9;
    }
}
