namespace ASP
{
    partial class ASP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASP));
            this.tracks = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.volume = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ports = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.track = new System.Windows.Forms.Label();
            this.artist = new System.Windows.Forms.Label();
            this.album = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.sort = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.PictureBox();
            this.fodlers = new System.Windows.Forms.PictureBox();
            this.repeat = new System.Windows.Forms.PictureBox();
            this.shuffle = new System.Windows.Forms.PictureBox();
            this.volume1 = new System.Windows.Forms.PictureBox();
            this.cover = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.stream = new System.Windows.Forms.PictureBox();
            this.trackdel = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.forward = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.stop = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fodlers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackdel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tracks
            // 
            this.tracks.FormattingEnabled = true;
            this.tracks.HorizontalScrollbar = true;
            this.tracks.ItemHeight = 17;
            this.tracks.Location = new System.Drawing.Point(178, 191);
            this.tracks.Name = "tracks";
            this.tracks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tracks.Size = new System.Drawing.Size(497, 276);
            this.tracks.TabIndex = 4;
            this.tracks.DoubleClick += new System.EventHandler(this.tracks_DoubleClick);
            this.tracks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tracks_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar1.Location = new System.Drawing.Point(9, 65);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(666, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(508, 100);
            this.volume.Maximum = 100;
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(153, 45);
            this.volume.TabIndex = 10;
            this.volume.Scroll += new System.EventHandler(this.volume_Scroll);
            this.volume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volume_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Volume 0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "00:00";
            // 
            // ports
            // 
            this.ports.FormattingEnabled = true;
            this.ports.ItemHeight = 17;
            this.ports.Location = new System.Drawing.Point(14, 191);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(147, 276);
            this.ports.TabIndex = 23;
            this.ports.DoubleClick += new System.EventHandler(this.ports_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Avaliable Clients";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Playlist";
            // 
            // track
            // 
            this.track.AutoSize = true;
            this.track.Location = new System.Drawing.Point(94, 100);
            this.track.Name = "track";
            this.track.Size = new System.Drawing.Size(38, 17);
            this.track.TabIndex = 26;
            this.track.Text = "Track";
            // 
            // artist
            // 
            this.artist.AutoSize = true;
            this.artist.Location = new System.Drawing.Point(94, 118);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(39, 17);
            this.artist.TabIndex = 27;
            this.artist.Text = "Artist";
            // 
            // album
            // 
            this.album.AutoSize = true;
            this.album.Location = new System.Drawing.Point(94, 154);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(44, 17);
            this.album.TabIndex = 28;
            this.album.Text = "Album";
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(94, 136);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(33, 17);
            this.year.TabIndex = 34;
            this.year.Text = "Year";
            // 
            // sort
            // 
            this.sort.Image = global::ASP.Properties.Resources.order;
            this.sort.Location = new System.Drawing.Point(460, 471);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(30, 30);
            this.sort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sort.TabIndex = 38;
            this.sort.TabStop = false;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // save
            // 
            this.save.Image = global::ASP.Properties.Resources.save;
            this.save.Location = new System.Drawing.Point(496, 471);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(30, 30);
            this.save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.save.TabIndex = 37;
            this.save.TabStop = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // clear
            // 
            this.clear.Image = global::ASP.Properties.Resources.garbage;
            this.clear.Location = new System.Drawing.Point(645, 471);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(30, 30);
            this.clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clear.TabIndex = 36;
            this.clear.TabStop = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // fodlers
            // 
            this.fodlers.Image = global::ASP.Properties.Resources.folder_1_;
            this.fodlers.Location = new System.Drawing.Point(568, 469);
            this.fodlers.Name = "fodlers";
            this.fodlers.Size = new System.Drawing.Size(35, 35);
            this.fodlers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fodlers.TabIndex = 35;
            this.fodlers.TabStop = false;
            this.fodlers.Click += new System.EventHandler(this.fodlers_Click);
            // 
            // repeat
            // 
            this.repeat.Image = global::ASP.Properties.Resources.repeat0;
            this.repeat.Location = new System.Drawing.Point(591, 28);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(35, 25);
            this.repeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.repeat.TabIndex = 33;
            this.repeat.TabStop = false;
            this.repeat.Click += new System.EventHandler(this.repeat_Click);
            // 
            // shuffle
            // 
            this.shuffle.Image = global::ASP.Properties.Resources.shuffle0;
            this.shuffle.Location = new System.Drawing.Point(548, 28);
            this.shuffle.Name = "shuffle";
            this.shuffle.Size = new System.Drawing.Size(35, 25);
            this.shuffle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.shuffle.TabIndex = 32;
            this.shuffle.TabStop = false;
            this.shuffle.Click += new System.EventHandler(this.shuffle_Click);
            // 
            // volume1
            // 
            this.volume1.Location = new System.Drawing.Point(477, 100);
            this.volume1.Name = "volume1";
            this.volume1.Size = new System.Drawing.Size(25, 25);
            this.volume1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.volume1.TabIndex = 31;
            this.volume1.TabStop = false;
            this.volume1.Click += new System.EventHandler(this.volume1_Click);
            // 
            // cover
            // 
            this.cover.Location = new System.Drawing.Point(14, 100);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(70, 70);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cover.TabIndex = 29;
            this.cover.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ASP.Properties.Resources.share1;
            this.pictureBox5.Location = new System.Drawing.Point(97, 471);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.receive_Click);
            // 
            // stream
            // 
            this.stream.Image = global::ASP.Properties.Resources.receive1;
            this.stream.Location = new System.Drawing.Point(131, 471);
            this.stream.Name = "stream";
            this.stream.Size = new System.Drawing.Size(30, 30);
            this.stream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stream.TabIndex = 21;
            this.stream.TabStop = false;
            this.stream.Click += new System.EventHandler(this.stream_Click);
            // 
            // trackdel
            // 
            this.trackdel.Image = global::ASP.Properties.Resources.remove;
            this.trackdel.Location = new System.Drawing.Point(609, 471);
            this.trackdel.Name = "trackdel";
            this.trackdel.Size = new System.Drawing.Size(30, 30);
            this.trackdel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trackdel.TabIndex = 20;
            this.trackdel.TabStop = false;
            this.trackdel.Click += new System.EventHandler(this.delete_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ASP.Properties.Resources.next;
            this.pictureBox4.Location = new System.Drawing.Point(431, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.next_Click);
            // 
            // forward
            // 
            this.forward.Image = global::ASP.Properties.Resources.previous;
            this.forward.Location = new System.Drawing.Point(207, 12);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(50, 50);
            this.forward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.forward.TabIndex = 18;
            this.forward.TabStop = false;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ASP.Properties.Resources.pause;
            this.pictureBox3.Location = new System.Drawing.Point(375, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pause_Click);
            // 
            // stop
            // 
            this.stop.Image = global::ASP.Properties.Resources.stop;
            this.stop.Location = new System.Drawing.Point(263, 12);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(50, 50);
            this.stop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stop.TabIndex = 16;
            this.stop.TabStop = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ASP.Properties.Resources.folder;
            this.pictureBox2.Location = new System.Drawing.Point(532, 471);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.add_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ASP.Properties.Resources.play;
            this.pictureBox1.Location = new System.Drawing.Point(319, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.play_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 39;
            // 
            // ASP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 505);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.save);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.fodlers);
            this.Controls.Add(this.year);
            this.Controls.Add(this.repeat);
            this.Controls.Add(this.shuffle);
            this.Controls.Add(this.volume1);
            this.Controls.Add(this.cover);
            this.Controls.Add(this.album);
            this.Controls.Add(this.artist);
            this.Controls.Add(this.track);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ports);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.stream);
            this.Controls.Add(this.trackdel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tracks);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ASP";
            this.Text = "ASP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fodlers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackdel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox tracks;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar volume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox stop;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox forward;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox trackdel;
        private System.Windows.Forms.PictureBox stream;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ListBox ports;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label track;
        private System.Windows.Forms.Label artist;
        private System.Windows.Forms.Label album;
        private System.Windows.Forms.PictureBox cover;
        private System.Windows.Forms.PictureBox volume1;
        private System.Windows.Forms.PictureBox shuffle;
        private System.Windows.Forms.PictureBox repeat;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.PictureBox fodlers;
        private System.Windows.Forms.PictureBox clear;
        private System.Windows.Forms.PictureBox save;
        private System.Windows.Forms.PictureBox sort;
        private System.Windows.Forms.Label label6;
    }
}

