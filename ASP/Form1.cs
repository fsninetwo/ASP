using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace ASP
{
    public partial class ASP : Form
    {
        static UdpClient client, senders = new UdpClient();
        static IPEndPoint point = new IPEndPoint(IPAddress.Any, 1483);
        static IPEndPoint pts = new IPEndPoint(IPAddress.Broadcast, 1483);
        static TcpListener streams;
        static NetworkStream ns;
        static Thread th1, th2, th3, th4, th5;
        static Boolean flag = false, pt = false, receive = false, se = false,
            vol = false, random = false, rt = false, force = false;
        static AudioFileReader reader = null;
        static Mp3FileReader rd = null;
        static WaveOutEvent sound = null;
        static MemoryStream ms;
        static Tag tg = new Tag();
        static List<int> list = new List<int>();
        static int volm, port, i = 0;
        static string line, adress = null;
        static System.Timers.Timer timer;

        public ASP()
        {
            InitializeComponent();
            track.Text = "";
            artist.Text = "";
            year.Text = "";
            album.Text = "";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader load = new StreamReader("base.txt"))
                while ((line = load.ReadLine()) != null)
                    tracks.Items.Add(line);
            volume.Value = 50;
            setVolume();
            th1 = new Thread(sender_1);
            th2 = new Thread(receivePort);
            th3 = new Thread(Data);
            th4 = new Thread(receiveMessage);
            th5 = new Thread(music);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            disposes();
            StreamWriter save = new StreamWriter("base.txt");
            foreach (var item in tracks.Items)
                if (!item.ToString().Contains("[") && !item.ToString().Contains("]"))
                    save.WriteLine(item.ToString());
            save.Close();
            stopThread();
            if (senders != null) senders.Close();
        }
        //music
        private void play_Click(object sender, EventArgs e)
        {
            if (reader == null && rd == null)
                play();
            else if (sound.PlaybackState == PlaybackState.Paused)
                sound.Play();
            else
            {
                disposes();
                create();
            }
        }

        private void play()
        {
            if (tracks.SelectedItem != null)
            {
                disposes();
                if (random == true)
                {
                    force = false;
                    if (i < list.Count)
                        list.Insert(i + 1, tracks.SelectedIndex);
                    else
                        list.Insert(i, tracks.SelectedIndex);
                    i++;
                }
            }
            else if (tracks.Items.Count != 0)
                if (random == false)
                    tracks.SelectedIndex = 0;
                else
                {
                    Random rand = new Random();
                    int temp = rand.Next(tracks.Items.Count);
                    list.Add(temp);
                    i++;
                    tracks.SelectedIndex = temp;
                }
            create();
        }

        private void create()
        {
            if (th5.IsAlive)
                th5.Abort();
            if (tracks.SelectedItem != null)
            {
                if (tracks.SelectedItem.ToString().Contains("[") && tracks.SelectedItem.ToString().Contains("]"))
                    sendMusic();
                else
                    createmusic();
                if (flag == true)
                    flag = false;
            }
        }

        private void createmusic()
        {
            try
            {
                reader = new AudioFileReader(tracks.SelectedItem.ToString());
                sound = new WaveOutEvent();
                sound.Init(reader);
                try
                {
                    track.Text = tg.trackname(tracks.SelectedItem.ToString());
                    artist.Text = tg.artistname(tracks.SelectedItem.ToString());
                    year.Text = tg.year(tracks.SelectedItem.ToString());
                    album.Text = tg.albumname(tracks.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    track.Text = artist.Text = year.Text = album.Text = "Unknown";
                }
                trackBar1.Maximum = (int)reader.TotalTime.TotalSeconds;
                label3.Text = reader.TotalTime.Minutes.ToString() + ":" + reader.TotalTime.Seconds.ToString();
                cover.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\stream.png");
                var file = TagLib.File.Create(tracks.SelectedItem.ToString());
                if (file.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    cover.Image = Image.FromStream(new MemoryStream(bin));
                }
                setVolume();
                sound.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("File is corrupt or empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendMusic()
        {
            try
            {
                th5 = new Thread(music);
                TcpClient stream = new TcpClient();
                stream.Connect(IPAddress.Parse(tracks.SelectedItem.ToString().Substring(1, tracks.SelectedItem.ToString().IndexOf("]") - 1)), 1483);
                ns = stream.GetStream();
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(tracks.SelectedItem.ToString());
                ns.Write(buffer, 0, buffer.Length);
                buffer = new byte[stream.ReceiveBufferSize];
                int bytesRead = ns.Read(buffer, 0, stream.ReceiveBufferSize);
                track.Invoke(new Action(() => track.Text = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead)));
                bytesRead = ns.Read(buffer, 0, stream.ReceiveBufferSize);
                artist.Invoke(new Action(() => artist.Text = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead)));
                bytesRead = ns.Read(buffer, 0, stream.ReceiveBufferSize);
                year.Invoke(new Action(() => year.Text = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead)));
                bytesRead = ns.Read(buffer, 0, stream.ReceiveBufferSize);
                album.Invoke(new Action(() => album.Text = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead)));
                th5 = new Thread(music);
                th5.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Choosed client is unvaliable!", "Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void music()
        {
            try
            {
                ms = new MemoryStream();
                {
                    new Thread(delegate (object o)
                    {
                        label6.Invoke(new Action(() => label6.Text = "Receiving..."));
                        try
                        {
                            using (var stream = ns)
                            {
                                byte[] buffer = new byte[1024];
                                int read;
                                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    var pos = ms.Position;
                                    ms.Position = ms.Length;
                                    ms.Write(buffer, 0, read);
                                    ms.Position = pos;
                                }
                            }
                        }
                        catch (Exception) { }
                        label6.Invoke(new Action(() => label6.Text = "Done!"));
                    }).Start();

                    while (ms.Length < 65536 * 10)
                        Thread.Sleep(1000);

                    ms.Position = 0;
                    trackBar1.Invoke(new Action(() => trackBar1.Enabled = true));
                    rd = new Mp3FileReader(ms);
                    sound = new WaveOutEvent();
                    sound.Init(rd);
                    trackBar1.Invoke(new Action(() => trackBar1.Maximum = (int)rd.TotalTime.TotalSeconds));
                    label3.Invoke(new Action(() => label3.Text = rd.TotalTime.Minutes.ToString() + ":" + rd.TotalTime.Seconds.ToString()));
                    cover.Invoke(new Action(() => cover.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\stream.png")));
                    sound.Play();
                    while (sound.PlaybackState == PlaybackState.Playing || sound.PlaybackState == PlaybackState.Paused)
                        Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException) { }
            catch (NullReferenceException) { }
            catch (Exception)
            {
                MessageBox.Show("File is corrupt or missed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            pauseplay();
        }

        private void pauseplay()
        {
            if (sound != null)
                if (sound.PlaybackState == PlaybackState.Playing)
                    sound.Pause();
                else if (sound.PlaybackState == PlaybackState.Paused)
                    sound.Play();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            disposes();
        }

        private void disposes()
        {
            try
            {
                track.Text = "";
                artist.Text = "";
                year.Text = "";
                album.Text = "";
                label6.Text = "";
                cover.Image = null;
                trackBar1.Value = 0;
                label2.Text = "00:00";
                label3.Text = "00:00";
                if (sound != null)
                {
                    sound.Stop();
                    sound.Dispose();
                    sound = null;
                }
                if (rd != null)
                {
                    rd.Dispose();
                    rd = null;
                }
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
            }
            catch (Exception) { }
        }

        private void next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            if (tracks.SelectedItem != null)
            {
                disposes();
                if (random == false)
                {
                    if (!tracks.SelectedIndex.Equals(tracks.Items.Count - 1))
                        tracks.SelectedIndex = tracks.SelectedIndex + 1;
                    else
                        tracks.SelectedIndex = 0;
                }
                else
                {
                    if (i < list.Count)
                    {
                        if (force == true)
                        {
                            force = false;
                            if (list.Count == 1)
                            {
                                i++;
                                randnext();
                                create();
                                return;
                            }
                            i++;
                        }
                        tracks.SelectedIndex = list[i];
                        i++;
                    }
                    else
                    {
                        randnext();
                    }
                }
                create();
            }
        }

        private void randnext()
        {
            if (list.Count >= tracks.Items.Count)
            {
                list.Clear();
                i = 0;
            }
            Random rand = new Random();
            int temp = rand.Next(tracks.Items.Count);
            while (list.Contains(temp))
                temp = rand.Next(tracks.Items.Count);
            list.Add(temp);
            i++;
            tracks.SelectedIndex = temp;
        }

        private void forward_Click(object sender, EventArgs e)
        {
            if (tracks.SelectedItem != null)
            {
                disposes();
                if (random == false)
                {
                    if (tracks.SelectedIndex != 0)
                        tracks.SelectedIndex = tracks.SelectedIndex - 1;
                    else
                        tracks.SelectedIndex = tracks.Items.Count - 1;
                }
                else
                {
                    if (i > 0)
                    {
                        if (force == false)
                        {
                            force = true;
                            if (i != 1)
                                i--;  
                        }
                        i--;
                        tracks.SelectedIndex = list[i];
                    }
                }
                create();
            }
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            if (rt == false)
            {
                rt = true;
                repeat.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\repeat1.png");
            }
            else
            {
                rt = false;
                repeat.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\repeat0.png");
            }
        }

        private void shuffle_Click(object sender, EventArgs e)
        {
            if (random == false)
            {
                random = true;
                if (rd != null || reader != null)
                {
                    list.Add(tracks.SelectedIndex);
                    i++;
                }
                shuffle.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\shuffle1.png");
            }
            else
            {
                list.Clear();
                i = 0;
                random = false;
                shuffle.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\shuffle0.png");
            }
        }
        //time
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (rd != null && sound.PlaybackState == PlaybackState.Playing)
            {
                trackBar1.Value = (int)rd.CurrentTime.TotalSeconds;
                label2.Text = rd.CurrentTime.Minutes.ToString() + ":"
                    + rd.CurrentTime.Seconds.ToString();
                value();
            }
            else if (reader != null && sound.PlaybackState == PlaybackState.Playing)
            {
                trackBar1.Value = (int)reader.CurrentTime.TotalSeconds;
                label2.Text = reader.CurrentTime.Minutes.ToString() + ":"
                    + reader.CurrentTime.Seconds.ToString();
                value();
            }
            if (se == false && ports.Items != null)
                ports.Items.Clear();
        }

        private void value()
        {
            if (trackBar1.Value == trackBar1.Maximum && flag == false && rt == false)
                next();
            if (trackBar1.Value == trackBar1.Maximum && flag == true && rt == false && random == true)
                next();
            else if (trackBar1.Value == trackBar1.Maximum && (flag == true || rt == true))
            {
                create();
                if (flag == true)
                    flag = false;
            }
        }
        //trackbars
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            bar();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            trackBar1.Value = (int)(((double)e.X / (double)trackBar1.Width) * trackBar1.Maximum);
            bar();
        }

        private void bar()
        {
            if (reader != null)
            {
                if (sound.PlaybackState == PlaybackState.Playing)
                {
                    sound.Pause();
                    reader.CurrentTime = new TimeSpan(0, trackBar1.Value / 60, trackBar1.Value % 60);
                    sound.Play();
                }
                else if (sound.PlaybackState == PlaybackState.Paused)
                    reader.CurrentTime = new TimeSpan(0, trackBar1.Value / 60, trackBar1.Value % 60);
            }
            else if (rd != null)
            {
                if (sound.PlaybackState == PlaybackState.Playing)
                {
                    if (th5.IsAlive)
                    {
                        sound.Pause();
                        rd.CurrentTime = new TimeSpan(0, trackBar1.Value / 60, trackBar1.Value % 60);
                        sound.Play();
                    }
                }
                else if (sound.PlaybackState == PlaybackState.Paused)
                    if (th5.IsAlive)
                        rd.CurrentTime = new TimeSpan(0, trackBar1.Value / 60, trackBar1.Value % 60);
            }
        }

        private void volume1_Click(object sender, EventArgs e)
        {
            if (vol == false)
            {
                volm = volume.Value;
                volume.Value = 0;
                setVolume();
                vol = true;
            }
            else
            {
                volume.Value = volm;
                setVolume();
                vol = false;
            }
        }

        private void volume_Scroll(object sender, EventArgs e)
        {
            setVolume();
        }

        private void volume_MouseDown(object sender, MouseEventArgs e)
        {
            volume.Value = (int)(((double)e.X / (double)volume.Width) * volume.Maximum);
            setVolume();
        }

        private void setVolume()
        {
            label1.Text = "Volume " + volume.Value.ToString() + "%";
            if (volume.Value == 0)
            {
                volume1.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\speaker0.png");
                Size size = new Size(28, 28);
                volume1.Location = new Point(478, 98);
                volume1.Size = size;
            }
            else if (volume.Value > 0 && volume.Value <= 33)
            {
                volume1.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\speaker1.png");
                Size size = new Size(25, 25);
                volume1.Size = size;
                volume1.Location = new Point (477, 100);
            }
            else if (volume.Value > 33 && volume.Value <= 66)
            {
                volume1.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\speaker2.png");
                Size size = new Size(27, 27);
                volume1.Location = new Point(478, 98);
                volume1.Size = size;
            }
            else if (volume.Value > 66 && volume.Value <= 100)
            {
                volume1.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\speaker3.png");
                Size size = new Size(32, 32);
                volume1.Location = new Point(478, 96);
                volume1.Size = size;
            }
            if (reader != null)
                reader.Volume = (float)(volume.Value * 0.01);
            else if (rd != null)
                if (th5.IsAlive)
                    sound.Volume = (float)(volume.Value * 0.01);
            if (vol == true)
                vol = false;

        }
        //tracks
        private void tracks_DoubleClick(object sender, EventArgs e)
        {
            play();
        }

        private void tracks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                delete();
            if (e.KeyCode == Keys.Enter)
                play();
        }

        private void sort_Click(object sender, EventArgs e)
        {
            if (tracks.Items.Count > 1)
            {
                List<string> q = new List<string>();
                foreach (object o in tracks.Items)
                    q.Add(o.ToString());
                tracks.Items.Clear();
                q.Sort();
                tracks.Items.AddRange(q.ToArray());
                q.Clear();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (rd != null)
            {
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = "MP3 File (.mp3)|*.mp3";
                if (sfg.ShowDialog() != DialogResult.OK) return;
                using (FileStream fs = new FileStream(sfg.FileName, FileMode.Create, FileAccess.Write))
                    fs.Write(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Multiselect = true;
            ofg.Title = "Choose file";
            ofg.Filter = "Audio file(*.wav;*.mp3;*.m4a;*.flac;*.alac;*.wma;) |*.wav;*.mp3;*.m4a;*.flac;*.wma;";
            if (ofg.ShowDialog() != DialogResult.OK) return;
            else tracks.Items.AddRange(ofg.FileNames);
        }

        private void fodlers_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            Thread th = new Thread(new ParameterizedThreadStart(look));
            th.Start(fbd.SelectedPath);
        }

        private void add(string fbd)
        {
            try
            {
                search(fbd, "*.mp3");
                search(fbd, "*.m4a");
                search(fbd, "*.flac");
                search(fbd, "*.alac");
                search(fbd, "*.wav");
                search(fbd, "*.wma");
                foreach (string d in Directory.GetDirectories(fbd))
                    add(d);
            }
            catch (UnauthorizedAccessException) { }
        }

        private void look(object o)
        {
            string fbd = (string)o;
            if (!string.IsNullOrWhiteSpace(fbd))
                add(fbd);
        }

        private void search(string fbd, string format)
        {
            try
            {
                string[] files = Directory.GetFiles(fbd, format, SearchOption.TopDirectoryOnly);
                tracks.Invoke(new Action(() => tracks.Items.AddRange(files)));
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void delete()
        {
            int i = tracks.SelectedIndex;
            tracks.Items.Remove(tracks.SelectedItem);
            if (i != tracks.Items.Count)
                tracks.SelectedIndex = i;
            else if (tracks.Items.Count != 0)
                tracks.SelectedIndex = 0;
            if (reader != null && sound.PlaybackState == PlaybackState.Playing)
                flag = true;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (tracks.Items.Count > 0)
                tracks.Items.Clear();
        }
        //server
        private void receive_Click(object sender, EventArgs e)
        {
            if (receive == false)
            {
                if (se == true)
                {
                    endSend();
                    stream.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\receive1.png");
                    se = false;
                }
                startThread();
                pictureBox5.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\share0.png");
                receive = true;
            }
            else
            {
                stopThread();
                pictureBox5.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\share1.png");
                receive = false;
            }
        }

        private void startThread()
        {
            th1 = new Thread(sender_1);
            th1.IsBackground = true;
            th1.Start();

            if (pt == false)
            {
                th2 = new Thread(receivePort);
                th2.IsBackground = true;
                th2.Start();
                pt = true;
            }

            if (adress != null)
            {
                th3 = new Thread(Data);
                th3.IsBackground = true;
                th3.Start();
            }
        }

        private void stopThread()
        {
            if (timer != null) timer.Dispose();
            if (th1.IsAlive) th1.Abort();
            if (streams != null) streams.Stop();
            if (th2.IsAlive) th2.Abort();
            if (th3.IsAlive) th3.Abort();
            if (th4.IsAlive) th4.Abort();
            if (th5.IsAlive) th5.Abort();
        }

        private void sender_1()
        {
            try
            {
                byte[] buff = new byte[1];
                timer = new System.Timers.Timer(10);
                timer.Elapsed += (sender, eventArgs) =>
                {
                    senders.Send(buff, buff.Length, pts);
                };
                timer.Start();
            }
            catch (ObjectDisposedException) { }
            catch (Exception) { }
        }

        private void receivePort()
        {
            while (true)
                try
                {
                    adress = ASCIIEncoding.ASCII.GetString(senders.Receive(ref pts));
                    pt = true;
                    Data();
                    break;
                }
                catch (Exception) { }
        }

        private void sendData(object st)
        {
            using (TcpClient cst = (TcpClient)st)
            {
                using (NetworkStream nstream = cst.GetStream())
                    try
                    {
                        byte[] buffer = new byte[cst.ReceiveBufferSize];
                        int bytesRead = nstream.Read(buffer, 0, cst.ReceiveBufferSize);
                        string text = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        if (text.Equals("base"))
                        {
                            using (StreamWriter save = new StreamWriter("base.txt"))
                            {
                                foreach (var item in tracks.Items)
                                    if (!item.ToString().Contains("[") && !item.ToString().Contains("]"))
                                        save.WriteLine(item.ToString());
                            }
                            buffer = File.ReadAllBytes("base.txt");
                            nstream.Write(buffer, 0, buffer.Length);
                        }
                        else if (text.Contains("[") && text.Contains("]"))
                        {
                            buffer = Encoding.ASCII.GetBytes(tg.trackname(text.Substring(text.IndexOf("]") + 1)));
                            nstream.Write(buffer, 0, buffer.Length);
                            buffer = Encoding.ASCII.GetBytes(tg.artistname(text.Substring(text.IndexOf("]") + 1)));
                            nstream.Write(buffer, 0, buffer.Length);
                            buffer = Encoding.ASCII.GetBytes(tg.year(text.Substring(text.IndexOf("]") + 1)));
                            nstream.Write(buffer, 0, buffer.Length);
                            buffer = Encoding.ASCII.GetBytes(tg.albumname(text.Substring(text.IndexOf("]") + 1)));
                            nstream.Write(buffer, 0, buffer.Length);
                            using (MediaFoundationReader reader = new MediaFoundationReader(text.Substring(text.IndexOf("]") + 1)))
                                MediaFoundationEncoder.EncodeToMp3(reader, "file.mp3");
                            using (Stream stream = new FileStream("file.mp3", FileMode.Open, FileAccess.Read))
                            {
                                buffer = new byte[1024];
                                int length;
                                while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    nstream.Write(buffer, 0, length);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        cst.Close();
                    }
            }
        }

        private void Data()
        {
            streams = new TcpListener(IPAddress.Parse(adress), 1483);
            streams.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            streams.ExclusiveAddressUse = false;
            streams.Start();
            try
            {
                while (true)
                {
                    TcpClient st = streams.AcceptTcpClient();
                    Thread th = new Thread(new ParameterizedThreadStart(sendData));
                    th.Start(st);
                }
            }
            catch (ThreadAbortException)
            {
                streams.Stop();
                Thread.ResetAbort();
            }
            catch (Exception)
            {
                streams.Stop();
            }
        }
        //client
        private void stream_Click(object sender, EventArgs e)
        {
            if (se == false)
            {
                if (receive == true)
                {
                    stopThread();
                    pictureBox5.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\share1.png");
                    receive = false;
                }
                startSend();
                stream.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\receive0.png");
                se = true;
            }
            else
            {
                endSend();
                stream.Image = Image.FromFile(Environment.CurrentDirectory + @"\images\receive1.png");
                se = false;
            }
        }

        private void startSend()
        {
            point = new IPEndPoint(IPAddress.Any, 1483);
            client = new UdpClient();
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;
            th4 = new Thread(receiveMessage);
            th5 = new Thread(music);
            th4.IsBackground = th5.IsBackground = true;
            th4.Start();
        }

        private void endSend()
        {
            Thread.Sleep(100);
            if (th4.IsAlive) th4.Abort();
            if (client != null) client.Close();
        }

        private void receiveMessage()
        {
            client.Client.Bind(point);
            try
            {
                while (true)
                {
                    byte[] buff = client.Receive(ref point);
                    string adress = point.Address.ToString();
                    if (!ports.Items.Contains(adress))
                        ports.Invoke(new Action(() => ports.Items.Add(adress)));
                    if (port != point.Port)
                    {
                        port = point.Port;
                        buff = ASCIIEncoding.ASCII.GetBytes(adress);
                        client.Send(buff, buff.Length, point);
                    }
                    point = new IPEndPoint(IPAddress.Any, 1483);
                }
            }
            catch (Exception) { }
        }

        private void ports_DoubleClick(object sender, EventArgs e)
        {
            TcpClient stream = new TcpClient();
            try
            {
                stream.Connect(IPAddress.Parse(ports.SelectedItem.ToString()), 1483);
                using (NetworkStream nstream = stream.GetStream())
                {
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes("base");
                    nstream.Write(buffer, 0, buffer.Length);
                    buffer = new byte[stream.ReceiveBufferSize];
                    int bytesRead = nstream.Read(buffer, 0, stream.ReceiveBufferSize);
                    using (FileStream fs = new FileStream("rbase.txt", FileMode.Create, FileAccess.Write))
                        fs.Write(buffer, 0, bytesRead);
                    using (StreamReader load = new StreamReader("rbase.txt"))
                        while ((line = load.ReadLine()) != null)
                        {
                            string text = "[" + ports.SelectedItem.ToString() + "]" + line;
                            if (!tracks.Items.Contains(text))
                                tracks.Items.Add(text);
                        }
                }
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Choosed client is unvaliable!", "Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ports.Items.Remove(ports.SelectedItem);
                stream.Close();
            }
        }
    }
}