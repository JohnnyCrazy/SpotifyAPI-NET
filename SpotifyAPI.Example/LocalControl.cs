using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace SpotifyAPI.Example
{
    public partial class LocalControl : UserControl
    {
        private readonly SpotifyLocalAPI _spotify;
        private Track _currentTrack;

        public LocalControl()
        {
            InitializeComponent();

            _spotify = new SpotifyLocalAPI();
            _spotify.OnPlayStateChange += _spotify_OnPlayStateChange;
            _spotify.OnTrackChange += _spotify_OnTrackChange;
            _spotify.OnTrackTimeChange += _spotify_OnTrackTimeChange;
            _spotify.OnVolumeChange += _spotify_OnVolumeChange;
            _spotify.SynchronizingObject = this;

            artistLinkLabel.Click += (sender, args) => Process.Start(artistLinkLabel.Tag.ToString());
            albumLinkLabel.Click += (sender, args) => Process.Start(albumLinkLabel.Tag.ToString());
            titleLinkLabel.Click += (sender, args) => Process.Start(titleLinkLabel.Tag.ToString());
        }

        public void Connect()
        {
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                MessageBox.Show(@"Spotify isn't running!");
                return;
            }
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                MessageBox.Show(@"SpotifyWebHelper isn't running!");
                return;
            }

            bool successful = _spotify.Connect();
            if (successful)
            {
                connectBtn.Text = @"Connection to Spotify successful";
                connectBtn.Enabled = false;
                UpdateInfos();
                _spotify.ListenForEvents = true;
            }
            else
            {
                DialogResult res = MessageBox.Show(@"Couldn't connect to the spotify client. Retry?", @"Spotify", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    Connect();
            }
        }

        public void UpdateInfos()
        {
            StatusResponse status = _spotify.GetStatus();
            if (status == null)
                return;

            //Basic Spotify Infos
            UpdatePlayingStatus(status.Playing);
            clientVersionLabel.Text = status.ClientVersion;
            versionLabel.Text = status.Version.ToString();
            repeatShuffleLabel.Text = status.Repeat + @" and " + status.Shuffle;

            if (status.Track != null) //Update track infos
                UpdateTrack(status.Track);
        }

        public async void UpdateTrack(Track track)
        {
            _currentTrack = track;

            advertLabel.Text = track.IsAd() ? "ADVERT" : "";
            timeProgressBar.Maximum = track.Length;

            if (track.IsAd())
                return; //Don't process further, maybe null values

            titleLinkLabel.Text = track.TrackResource.Name;
            titleLinkLabel.Tag = track.TrackResource.Uri;

            artistLinkLabel.Text = track.ArtistResource.Name;
            artistLinkLabel.Tag = track.ArtistResource.Uri;

            albumLinkLabel.Text = track.AlbumResource.Name;
            albumLinkLabel.Tag = track.AlbumResource.Uri;

            bigAlbumPicture.Image = await track.GetAlbumArtAsync(AlbumArtSize.Size640);
            smallAlbumPicture.Image = await track.GetAlbumArtAsync(AlbumArtSize.Size160);
        }

        public void UpdatePlayingStatus(bool playing)
        {
            isPlayingLabel.Text = playing.ToString();
        }

        private void _spotify_OnVolumeChange(VolumeChangeEventArgs e)
        {
            volumeLabel.Text = (e.NewVolume * 100).ToString(CultureInfo.InvariantCulture);
        }

        private void _spotify_OnTrackTimeChange(TrackTimeChangeEventArgs e)
        {
            timeLabel.Text = $"{FormatTime(e.TrackTime)}/{FormatTime(_currentTrack.Length)}";
            timeProgressBar.Value = (int)e.TrackTime;
        }

        private void _spotify_OnTrackChange(TrackChangeEventArgs e)
        {
            UpdateTrack(e.NewTrack);
        }

        private void _spotify_OnPlayStateChange(PlayStateEventArgs e)
        {
            UpdatePlayingStatus(e.Playing);
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void playUrlBtn_Click(object sender, EventArgs e)
        {
            _spotify.PlayURL(playTextBox.Text, contextTextBox.Text);
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            _spotify.Play();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            _spotify.Pause();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            _spotify.Previous();
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            _spotify.Skip();
        }

        private static String FormatTime(double sec)
        {
            TimeSpan span = TimeSpan.FromSeconds(sec);
            String secs = span.Seconds.ToString(), mins = span.Minutes.ToString();
            if (secs.Length < 2)
                secs = "0" + secs;
            return mins + ":" + secs;
        }
    }
}