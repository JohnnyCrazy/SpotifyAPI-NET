﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Local.Models;
using System.Diagnostics;

namespace SpotifyAPI.Local
{
    public class SpotifyLocalAPI : IDisposable
    {
        private const byte VkMediaNextTrack = 0xb0;
        private const byte VkMediaPrevTrack = 0xb1;
        private const int KeyeventfExtendedkey = 0x1;
        private const int KeyeventfKeyup = 0x2;

        private readonly RemoteHandler _rh;
        private StatusResponse _eventStatusResponse;
        private Timer _eventTimer;

        private bool _listenForEvents;

        public SpotifyLocalAPI(int timerIntervall = 50)
        {
            _rh = new RemoteHandler();
            AttachTimer(timerIntervall);
        }

        public int Intervall { get; set; }

        public bool ListenForEvents
        {
            get { return _listenForEvents; }
            set
            {
                _listenForEvents = value;
                _eventTimer.Change(value ? 0 : Timeout.Infinite, value ? Intervall : Timeout.Infinite);
            }
        }

        public void Dispose()
        {
            _eventTimer?.Change(Timeout.Infinite, Timeout.Infinite);
            _eventTimer?.Dispose();
        }

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public event EventHandler<TrackChangeEventArgs> OnTrackChange;

        public event EventHandler<PlayStateEventArgs> OnPlayStateChange;

        public event EventHandler<VolumeChangeEventArgs> OnVolumeChange;

        public event EventHandler<TrackTimeChangeEventArgs> OnTrackTimeChange;

        private void AttachTimer(int intervall)
        {
            _eventTimer = new Timer(ElapsedTick, null, ListenForEvents ? 0 : Timeout.Infinite,
                ListenForEvents ? intervall : Timeout.Infinite);
        }

        private async void ElapsedTick(object sender)
        {
            if (_eventStatusResponse == null)
            {
                _eventStatusResponse = await GetStatus();
                return;
            }
            StatusResponse newStatusResponse = await GetStatus();
            if (newStatusResponse == null)
                return;
            if (!newStatusResponse.Running && (newStatusResponse.Track == null))
                return;
            if ((newStatusResponse.Track != null) && (_eventStatusResponse.Track != null))
                if (newStatusResponse.Track.TrackResource?.Uri != _eventStatusResponse.Track.TrackResource?.Uri)
                    OnTrackChange?.Invoke(this, new TrackChangeEventArgs
                    {
                        OldTrack = _eventStatusResponse.Track,
                        NewTrack = newStatusResponse.Track
                    });
            if (newStatusResponse.Playing != _eventStatusResponse.Playing)
                OnPlayStateChange?.Invoke(this, new PlayStateEventArgs
                {
                    Playing = newStatusResponse.Playing
                });
            if (newStatusResponse.Volume != _eventStatusResponse.Volume)
                OnVolumeChange?.Invoke(this, new VolumeChangeEventArgs
                {
                    OldVolume = _eventStatusResponse.Volume,
                    NewVolume = newStatusResponse.Volume
                });
            if (newStatusResponse.PlayingPosition != _eventStatusResponse.PlayingPosition)
                OnTrackTimeChange?.Invoke(this, new TrackTimeChangeEventArgs
                {
                    TrackTime = newStatusResponse.PlayingPosition
                });
            _eventStatusResponse = newStatusResponse;
        }

        /// <summary>
        ///     Connects with Spotify. Needs to be called before all other SpotifyAPI functions
        /// </summary>
        /// <returns>Returns true, if it was successful, false if not</returns>
        public Task<bool> Connect()
        {
            return _rh.Init();
        }

        /// <summary>
        ///     Update and returns the new StatusResponse from the Spotify-Player
        /// </summary>
        /// <returns>An up-to-date StatusResponse</returns>
        public Task<StatusResponse> GetStatus()
        {
            return _rh.GetNewStatus();
        }

        /// <summary>
        ///     Pause function
        /// </summary>
        public async Task Pause()
        {
            await _rh.SendPauseRequest();
        }

        /// <summary>
        ///     Play function
        /// </summary>
        public async Task Play()
        {
            await _rh.SendPlayRequest();
        }

        /// <summary>
        ///     Simulates a KeyPress
        /// </summary>
        /// <param name="keyCode">The keycode for the represented Key</param>
        internal void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey, 0);
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }

        /// <summary>
        ///     Plays a Spotify URI within an optional context.
        /// </summary>
        /// <param name="uri">The Spotify URI</param>
        /// <param name="context">The context in which to play the specified <paramref name="uri" />. </param>
        /// <remarks>
        ///     Contexts are basically a queue in spotify. a song can be played within a context, meaning that hitting next /
        ///     previous would lead to another song. Contexts are leveraged by widgets as described in the "Multiple tracks player"
        ///     section of the following documentation page:
        ///     https://developer.spotify.com/technologies/widgets/spotify-play-button/
        /// </remarks>
        public async Task PlayURL(string uri, string context = "")
        {
            await _rh.SendPlayRequest(uri, context);
        }

        /// <summary>
        ///     Adds a Spotify URI to the Queue
        /// </summary>
        /// <param name="uri">The Spotify URI</param>
        [Obsolete("This method doesn't work with the current spotify version.")]
        public async Task AddToQueue(string uri)
        {
            await _rh.SendQueueRequest(uri);
        }

        /// <summary>
        ///     Skips the current song (Using keypress simulation)
        /// </summary>
        public void Skip()
        {
            PressKey(VkMediaNextTrack);
        }

        /// <summary>
        ///     Emulates the "Previous" Key (Using keypress simulation)
        /// </summary>
        public void Previous()
        {
            PressKey(VkMediaPrevTrack);
        }

#if NET461

        /// <summary>
        ///     Checks if Spotify is running
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static bool IsSpotifyRunning()
        {
            return Process.GetProcessesByName("spotify").Length >= 1;
        }

        /// <summary>
        ///     Checks if Spotify's WebHelper is running (Needed for API Calls)
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static bool IsSpotifyWebHelperRunning()
        {
            return Process.GetProcessesByName("spotifywebhelper").Length >= 1;
        }

        /// <summary>
        ///     Runs Spotify
        /// </summary>
        public static void RunSpotify()
        {
            if (!IsSpotifyRunning() && File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotify.exe")))
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotify.exe"));
        }

        /// <summary>
        ///     Runs Spotify's WebHelper
        /// </summary>
        public static void RunSpotifyWebHelper()
        {
            if (!IsSpotifyWebHelperRunning() && File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\data\spotifywebhelper.exe")))
            {
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\data\spotifywebhelper.exe"));
            }
            else if (!IsSpotifyWebHelperRunning() && File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotifywebhelper.exe")))
            {
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotifywebhelper.exe"));
            }
        }

                /// <summary>
        ///     Mutes Spotify (Requires Windows 7 or newer)
        /// </summary>
        public void Mute()
        {
            //Windows < Windows Vista Check
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            //Windows Vista Check
            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor == 0)
                    throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            VolumeMixerControl.MuteSpotify(true);
        }

        /// <summary>
        ///     Unmutes Spotify (Requires Windows 7 or newer)
        /// </summary>
        public void UnMute()
        {
            //Windows < Windows Vista Check
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            //Windows Vista Check
            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor == 0)
                    throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            VolumeMixerControl.MuteSpotify(false);
        }

        /// <summary>
        ///     Checks whether Spotify is muted in the Volume Mixer control (required Windows 7 or newer)
        /// </summary>
        /// <returns>Null if an error occured, otherwise the muted state</returns>
        public bool IsSpotifyMuted()
        {
            //Windows < Windows Vista Check
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            //Windows Vista Check
            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor == 0)
                    throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            return VolumeMixerControl.IsSpotifyMuted();
        }

        /// <summary>
        ///     Sets the Volume Mixer volume (requires Windows 7 or newer)
        /// </summary>
        /// <param name="volume">A value between 0 and 100</param>
        public void SetSpotifyVolume(float volume = 100)
        {
            //Windows < Windows Vista Check
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            //Windows Vista Check
            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor == 0)
                    throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            if (volume < 0 || volume > 100)
                throw new ArgumentOutOfRangeException(nameof(volume));
            VolumeMixerControl.SetSpotifyVolume(volume);
        }

        /// <summary>
        ///     Return the Volume Mixer volume of Spotify (requires Windows 7 or newer)
        /// </summary>
        /// <returns>Null if an error occured, otherwise a float between 0 and 100</returns>
        public float GetSpotifyVolume()
        {
            //Windows < Windows Vista Check
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            //Windows Vista Check
            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor == 0)
                    throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            return VolumeMixerControl.GetSpotifyVolume();
        }

#endif
    }
}