using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace AudioPlayer
{
    public partial class MainForm : Form
    {
        private readonly string downloadFolderPath = "Downloads";
        private readonly WindowsMediaPlayer mediaPlayer;
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        private readonly YoutubeClient youtubeClient;
        private readonly Timer durationTimer;
        private bool randomPlayEnabled = false;
        private bool autoPlayEnabled = false;
        private string selectedFilePath;
        private bool isDragging = false;
        private Point startPoint;
        private ContextMenuStrip contextMenuStrip;
        private int currentTrackIndex = 0;
        private readonly Config config;

        public MainForm()
        {
            config = ConfigManager.LoadConfig();
            EnsureWebView2Installed();

            InitializeComponent();
            Button btnSearch = new Button() { Text = "Search YouTube", Location = new Point(10, 10) };
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);
            InitializeDownloadFolder();
            mediaPlayer = new WindowsMediaPlayer();
            youtubeClient = new YoutubeClient();
            durationTimer = new Timer { Interval = 1000 };
            durationTimer.Tick += DurationTimer_Tick;
            InitializeContextMenuStrip();

            mediaPlayer.PlayStateChange += MediaPlayer_PlayStateChange;
            trackBarVolume.ValueChanged += TrackBarVolume_ValueChanged;
            trackBarVolume.Value = 100;
        }

        private async void EnsureWebView2Installed()
        {
            if (!config.IsWebView2Installed && !IsWebView2Installed())
            {
                string webView2InstallerUrl = "https://go.microsoft.com/fwlink/p/?LinkId=2124703"; // Official WebView2 installer URL
                string tempInstallerPath = Path.Combine(Path.GetTempPath(), "MicrosoftEdgeWebView2Setup.exe");

                try
                {
                    DownloadFile(webView2InstallerUrl, tempInstallerPath);
                    await Task.Run(() => InstallWebView2(tempInstallerPath));
                    File.Delete(tempInstallerPath);

                    config.IsWebView2Installed = true;
                    ConfigManager.SaveConfig(config);
                }
                catch { }
            }
        }

        private bool IsWebView2Installed()
        {
            string webview2Key = @"SOFTWARE\Microsoft\EdgeUpdate\ClientState\{F660DE05-C2CB-44DA-BF35-A18A6DC1BEAC}";
            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(webview2Key))
            {
                return key != null;
            }
        }

        private void DownloadFile(string url, string destinationPath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, destinationPath);
            }
        }

        private void InstallWebView2(string installerPath)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = installerPath,
                Arguments = "/silent /install",
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas" // Run as administrator
            };

            using (var process = Process.Start(startInfo))
            {
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                }
            }
        }

        private void InitializeContextMenuStrip()
        {
            contextMenuStrip = new ContextMenuStrip();
            var randomPlayMenuItem = new ToolStripMenuItem("Random play")
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
                CheckOnClick = true
            };
            randomPlayMenuItem.Click += RandomPlayItem_Click;
            randomPlayMenuItem.CheckedChanged += RandomPlayMenuItem_CheckedChanged;
            contextMenuStrip.Items.Add(randomPlayMenuItem);
            ContextMenuStrip = contextMenuStrip;

            var autoPlayItem = new ToolStripMenuItem("Auto play")
            {
                BackColor = Color.Black,
                ForeColor = Color.White
            };
            autoPlayItem.Click += AutoPlayItem_Click;
            autoPlayItem.CheckedChanged += AutoPlayMenuItem_CheckedChanged;
            contextMenuStrip.Items.Add(randomPlayMenuItem);
            contextMenuStrip.Items.Add(autoPlayItem);

            ContextMenuStrip = contextMenuStrip;
        }
        private  readonly List<string> shuffledTracks = new List<string>();

        private void ShuffleTracks()
        {
            shuffledTracks.Clear(); // Clear any previous shuffled tracks
            shuffledTracks.AddRange(listBoxDownloads.Items.Cast<string>().Select(item => Path.Combine(downloadFolderPath, item)).ToList());

            Random rng = new Random();
            int n = shuffledTracks.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                // Swap elements
                (shuffledTracks[k], shuffledTracks[n]) = (shuffledTracks[n], shuffledTracks[k]);
            }
        }
        private void RandomPlayItem_Click(object sender, EventArgs e)
        {
            if (listBoxDownloads.Items.Count > 0)
            {
                currentTrackIndex = 0; // Start from the first track
                ShuffleTracks(); // Shuffle the track order
            }
        }

        private void AutoPlayItem_Click(object sender, EventArgs e)
        {
            if (listBoxDownloads.Items.Count > 0)
            {
                currentTrackIndex = 0; // Start from the first track
                PlayNextTrack(); // Play the first track
            }
        }


        private void RandomPlayMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                randomPlayEnabled = menuItem.Checked;
            }
        }

        private void AutoPlayMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                autoPlayEnabled = menuItem.Checked;
            }
        }

        private void MediaPlayer_PlayStateChange(int newState)
        {
            if ((WMPPlayState)newState == WMPPlayState.wmppsStopped && randomPlayEnabled)
            {
                PlayNextTrack();
            }
        }

        private void PlayNextTrack()
        {
            if (shuffledTracks.Count > 0)
            {
                // Play the current track from the shuffled list
                string filePath = shuffledTracks[currentTrackIndex];
                PlayMusic(filePath); // Play the current track

                // Move to the next track
                currentTrackIndex++;
                if (currentTrackIndex >= shuffledTracks.Count)
                {
                    // Reset index if we've reached the end of the list
                    currentTrackIndex = 0; // Or you can stop playback or handle accordingly
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            durationTimer.Stop();
            durationTimer.Dispose();
            mediaPlayer.controls.stop();
            waveOut?.Stop();
            audioFileReader?.Dispose();
            waveOut?.Dispose();
            base.OnFormClosing(e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        private void InitializeDownloadFolder()
        {
            if (!Directory.Exists(downloadFolderPath))
            {
                Directory.CreateDirectory(downloadFolderPath);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName;
        }

        private void RefreshListBox()
        {
            listBoxDownloads.Items.Clear();
            string[] files = Directory.GetFiles(downloadFolderPath);
            foreach (string file in files)
            {
                listBoxDownloads.Items.Add(Path.GetFileName(file));
            }
        }

        private void ListBoxDownloads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDownloads.SelectedIndex != -1)
            {
                selectedFilePath = Path.Combine(downloadFolderPath, listBoxDownloads.SelectedItem.ToString());
            }
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (!string.IsNullOrEmpty(url))
            {
                await DownloadYoutubeVideoAsync(url);
            }
            else
            {
                MessageBox.Show("Please enter a valid YouTube URL.");
            }
        }
        private bool IsSupportedFormat(string filePath)
        {
            string[] supportedFormats = { ".mp3", ".mp4", ".wma", ".wav", ".flac", ".aac", ".m4a" };
            return supportedFormats.Contains(Path.GetExtension(filePath).ToLower());
        }
        private void PlayMusic(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    if (IsSupportedFormat(filePath))
                    {
                        if (mediaPlayer.URL == filePath)
                        {
                            mediaPlayer.controls.play();
                        }
                        else
                        {
                            mediaPlayer.URL = filePath;
                            mediaPlayer.controls.play();
                        }
                        durationTimer.Start();
                    }
                    else
                    {
                        PlayWithNAudio(filePath);
                    }
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing the file: {ex.Message}");
            }
        }
        private void PlayWithNAudio(string filePath)
        {
            try
            {
                waveOut?.Dispose();
                audioFileReader?.Dispose();

                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader(filePath);
                waveOut.Init(audioFileReader);
                waveOut.Play();
                waveOut.PlaybackStopped += OnPlaybackStopped;
                durationTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"NAudio playback failed: {ex.Message}");
            }
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (randomPlayEnabled)
            {
                PlayNextTrack();
            }
            if (autoPlayEnabled)
            {
                PlayNextTrack();
            }
        }
        private void ProgressBar_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.currentMedia != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                double ratio = (double)me.X / progressBar.Width;
                double newPosition = mediaPlayer.currentMedia.duration * ratio;
                mediaPlayer.controls.currentPosition = newPosition;
            }
            else if (audioFileReader != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                double ratio = (double)me.X / progressBar.Width;
                double newPosition = audioFileReader.TotalTime.TotalSeconds * ratio;
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(newPosition);
            }
        }
        private void BtnFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(downloadFolderPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", downloadFolderPath);
            }
            else
            {
                MessageBox.Show("Download folder not found.");
            }
        }
        private async Task DownloadYoutubeVideoAsync(string url)
        {
            try
            {
                var video = await youtubeClient.Videos.GetAsync(url);
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (streamInfo != null)
                {
                    string sanitizedTitle = SanitizeFileName(video.Title);
                    string filePath = Path.Combine(downloadFolderPath, $"{sanitizedTitle}.{streamInfo.Container}");
                    await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, filePath);

                    MessageBox.Show("Download complete!");
                    RefreshListBox();
                }
                else
                {
                    MessageBox.Show("No suitable stream found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void DurationTimer_Tick(object sender, EventArgs e)
        {

            // Vérification du mediaPlayer
            if (mediaPlayer?.currentMedia != null)
            {
                double duration = mediaPlayer.currentMedia.duration;
                double currentPosition = mediaPlayer.controls.currentPosition;

                UpdateDuration(duration, currentPosition);
                UpdatePanelTimeline(duration, currentPosition);
            }
            // Vérification du audioFileReader
            else if (audioFileReader != null)
            {
                double totalDuration = audioFileReader.TotalTime.TotalSeconds;
                double currentPosition = audioFileReader.CurrentTime.TotalSeconds;

                UpdateDuration(totalDuration, currentPosition);
                UpdatePanelTimeline(totalDuration, currentPosition);
            }

        }
        private void UpdateDuration(double totalDuration, double currentPosition)
        {
            double remainingTime = totalDuration - currentPosition;
            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);
            this.Invoke((MethodInvoker)delegate
            {
                lblDuration.Text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
                if (totalDuration > 0)
                {
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;
                    int progressValue = (int)((currentPosition / totalDuration) * 100);
                    progressBar.Value = Math.Min(Math.Max(progressValue, progressBar.Minimum), progressBar.Maximum);
                }
            });
        }
        private void UpdatePanelTimeline(double totalDuration, double currentPosition)
        {
            if (totalDuration > 0)
            {
                // Assuming panelTimeline is within a container like progressBar or some parent container
                double ratio = currentPosition / totalDuration;
                int newXPosition = (int)(ratio * (progressBar.Width - panelTimeline.Width)); // Adjust the width so the panel doesn't go out of bounds
                panelTimeline.Left = Math.Max(Math.Min(newXPosition, progressBar.Width - panelTimeline.Width), 0); // Make sure the panel doesn't exceed the bounds
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }
        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void BtnPlayAndPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (mediaPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    mediaPlayer.controls.pause();
                    durationTimer.Stop();
                }
                else if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                    durationTimer.Stop();
                }
                else
                {
                    PlayMusic(selectedFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void TrackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            int volume = trackBarVolume.Value;
            mediaPlayer.settings.volume = volume;
            if (waveOut != null)
            {
                waveOut.Volume = volume / 100f;
            }
        }
        private void BtnVolume_Click(object sender, EventArgs e)
        {
            bool isVisible = !trackBarVolume.Visible;
            trackBarVolume.Visible = isVisible;
            panelVolume.Visible = isVisible;
        }
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            PlayPreviousTrack();
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            PlayNextTrack();
        }
        private void PlayPreviousTrack()
        {
            if (listBoxDownloads.Items.Count > 1)
            {
                currentTrackIndex = (currentTrackIndex - 1 + listBoxDownloads.Items.Count) % listBoxDownloads.Items.Count;
                listBoxDownloads.SelectedIndex = currentTrackIndex;
                PlayMusic(Path.Combine(downloadFolderPath, listBoxDownloads.SelectedItem.ToString()));
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(listBoxDownloads, downloadFolderPath);
            searchForm.Show();
        }
        private void BtnNews_Click(object sender, EventArgs e)
        {
            panelNews.Visible = !panelNews.Visible;
        }
        private void BtnExit2NewsForm_Click(object sender, EventArgs e)
        {
            panelNews.Visible = !panelNews.Visible;
        }
    }
}
