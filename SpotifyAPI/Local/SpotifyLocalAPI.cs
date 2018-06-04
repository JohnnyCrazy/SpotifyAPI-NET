using SpotifyAPI.Local.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;

namespace SpotifyAPI.Local
{
    public class SpotifyLocalAPI : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private bool _listenForEvents;

        public bool ListenForEvents
        {
            get
            {
                return _listenForEvents;
            }
            set
            {
                _listenForEvents = value;
                _eventTimer.Enabled = value;
            }
        }

        private ISynchronizeInvoke _synchronizingObject;

        public ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                return _synchronizingObject;
            }
            set
            {
                _synchronizingObject = value;
                _eventTimer.SynchronizingObject = value;
            }
        }

        private const int WindowsSevenMajorVersion = 6;
        private const int WindowsSevenMinorVersion = 1;
        private const int KeyeventfExtendedkey = 0x1;
        private const int KeyeventfKeyup = 0x2;

        private readonly RemoteHandler _rh;
        private Timer _eventTimer;
        private StatusResponse _eventStatusResponse;
        private Track _eventStatusTrack;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private const uint WM_APPCOMMAND = 0x0319;
        private const long cmdNextTrack = 0x000B0000L;
        private const long cmdPreviousTrack = 0x000C0000L;

        Process proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

        private IntPtr spotifyHWnd = proc.MainWindowHandle;

        public event EventHandler<TrackChangeEventArgs> OnTrackChange;

        public event EventHandler<PlayStateEventArgs> OnPlayStateChange;

        public event EventHandler<VolumeChangeEventArgs> OnVolumeChange;

        public event EventHandler<TrackTimeChangeEventArgs> OnTrackTimeChange;

        public SpotifyLocalAPI(int timerIntervall = 50)
        {
            _rh = new RemoteHandler(new SpotifyLocalAPIConfig());
            AttachTimer(timerIntervall);
        }

        public SpotifyLocalAPI(SpotifyLocalAPIConfig config)
        {
            _rh = new RemoteHandler(config);
            AttachTimer(config.TimerInterval);
        }

        private void AttachTimer(int intervall)
        {
            _eventTimer = new Timer
            {
                Interval = intervall,
                AutoReset = false,
                Enabled = false
            };
            _eventTimer.Elapsed += ElapsedTick;
        }

        private void ElapsedTick(object sender, ElapsedEventArgs e)
        {
            if (_eventStatusResponse == null)
            {
                _eventStatusResponse = GetStatus();
                _eventTimer.Start();
                return;
            }
            StatusResponse newStatusResponse = GetStatus();
            if (newStatusResponse == null)
            {
                _eventTimer.Start();
                return;
            }
            if (!newStatusResponse.Running && newStatusResponse.Track == null)
            {
                _eventTimer.Start();
                return;
            }
            if (newStatusResponse.Track != null && _eventStatusTrack != null)
            {
                if (newStatusResponse.Track.TrackResource?.Uri != _eventStatusTrack.TrackResource?.Uri ||
                    newStatusResponse.Track.IsOtherTrackType() && newStatusResponse.Track.Length != _eventStatusTrack.Length)
                {
                    OnTrackChange?.Invoke(this, new TrackChangeEventArgs()
                    {
                        OldTrack = _eventStatusTrack,
                        NewTrack = newStatusResponse.Track
                    });
                }
            }
            if (newStatusResponse.Playing != _eventStatusResponse.Playing)
            {
                OnPlayStateChange?.Invoke(this, new PlayStateEventArgs()
                {
                    Playing = newStatusResponse.Playing
                });
            }
            if (newStatusResponse.Volume != _eventStatusResponse.Volume)
            {
                OnVolumeChange?.Invoke(this, new VolumeChangeEventArgs()
                {
                    OldVolume = _eventStatusResponse.Volume,
                    NewVolume = newStatusResponse.Volume
                });
            }
            if (newStatusResponse.PlayingPosition != _eventStatusResponse.PlayingPosition)
            {
                OnTrackTimeChange?.Invoke(this, new TrackTimeChangeEventArgs()
                {
                    TrackTime = newStatusResponse.PlayingPosition
                });
            }
            _eventStatusResponse = newStatusResponse;
            if (newStatusResponse.Track != null)
            {
                _eventStatusTrack = newStatusResponse.Track;
            }
            _eventTimer.Start();
        }

        private bool IsOSCompatible(int minMajor, int minMinor)
        {
            return Environment.OSVersion.Version.Major > minMajor || (Environment.OSVersion.Version.Major == minMajor && Environment.OSVersion.Version.Minor >= minMinor);
        }
        /// <summary>
        /// Connects with Spotify. Needs to be called before all other SpotifyAPI functions
        /// </summary>
        /// <returns>Returns true, if it was successful, false if not</returns>
        public Boolean Connect()
        {
            return _rh.Init();
        }

        /// <summary>
        /// Update and returns the new StatusResponse from the Spotify-Player
        /// </summary>
        /// <returns>An up-to-date StatusResponse</returns>
        public StatusResponse GetStatus()
        {
            return _rh.GetNewStatus();
        }

        /// <summary>
        /// Mutes Spotify (Requires Windows 7 or newer)
        /// </summary>
        public void Mute()
        {
            if(!IsOSCompatible(WindowsSevenMajorVersion, WindowsSevenMinorVersion))
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            VolumeMixerControl.MuteSpotify(true);
        }

        /// <summary>
        /// Unmutes Spotify (Requires Windows 7 or newer)
        /// </summary>
        public void UnMute()
        {
            if (!IsOSCompatible(WindowsSevenMajorVersion, WindowsSevenMinorVersion))
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            VolumeMixerControl.MuteSpotify(false);
        }

        /// <summary>
        /// Checks whether Spotify is muted in the Volume Mixer control (required Windows 7 or newer)
        /// </summary>
        /// <returns>Null if an error occured, otherwise the muted state</returns>
        public bool IsSpotifyMuted()
        {
            if (!IsOSCompatible(WindowsSevenMajorVersion, WindowsSevenMinorVersion))
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            return VolumeMixerControl.IsSpotifyMuted();
        }

        /// <summary>
        ///  Sets the Volume Mixer volume (requires Windows 7 or newer)
        /// </summary>
        /// <param name="volume">A value between 0 and 100</param>
        public void SetSpotifyVolume(float volume = 100)
        {
            if (!IsOSCompatible(WindowsSevenMajorVersion, WindowsSevenMinorVersion))
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            if (volume < 0 || volume > 100)
                throw new ArgumentOutOfRangeException(nameof(volume));
            VolumeMixerControl.SetSpotifyVolume(volume);
        }

        /// <summary>
        /// Return the Volume Mixer volume of Spotify (requires Windows 7 or newer)
        /// </summary>
        /// <returns>Null if an error occured, otherwise a float between 0 and 100</returns>
        public float GetSpotifyVolume()
        {
            if (!IsOSCompatible(WindowsSevenMajorVersion, WindowsSevenMinorVersion))
                throw new NotSupportedException("This feature is only available on Windows 7 or newer");
            return VolumeMixerControl.GetSpotifyVolume();
        }

        /// <summary>
        /// Pause function
        /// </summary>
        public async Task Pause()
        {
            await _rh.SendPauseRequest();
        }

        /// <summary>
        /// Play function
        /// </summary>
        public async Task Play()
        {
            await _rh.SendPlayRequest();
        }

        /// <summary>
        /// Simulates a KeyPress
        /// </summary>
        /// <param name="keyCode">The keycode for the represented Key</param>
        internal void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey, 0);
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }

        /// <summary>
        /// Plays a Spotify URI within an optional context.
        /// </summary>
        /// <param name="uri">The Spotify URI</param>
        /// <param name="context">The context in which to play the specified <paramref name="uri"/>. </param>
        /// <remarks>
        /// Contexts are basically a queue in spotify. a song can be played within a context, meaning that hitting next / previous would lead to another song. Contexts are leveraged by widgets as described in the "Multiple tracks player" section of the following documentation page: https://developer.spotify.com/technologies/widgets/spotify-play-button/
        /// </remarks>
        public async Task PlayURL(string uri, string context = "")
        {
            await _rh.SendPlayRequest(uri, context);
        }

        /// <summary>
        /// Adds a Spotify URI to the Queue
        /// </summary>
        /// <param name="uri">The Spotify URI</param>
        [Obsolete("This method doesn't work with the current spotify version.")]
        public async Task AddToQueue(string uri)
        {
            await _rh.SendQueueRequest(uri);
        }


        /// <summary>
        /// Skips the current song (Using Post Message)
        /// </summary>
        public void Skip()
        {
            PostMessage(spotifyHWnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)cmdNextTrack);
        }

        /// <summary>
        /// Emulates the "Previous" Key (Using Post Message)
        /// </summary>
        public void Previous()
        {
            PostMessage(spotifyHWnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)cmdPreviousTrack);
        }

        /// <summary>
        /// Checks if Spotify is running
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static Boolean IsSpotifyRunning()
        {
            return Process.GetProcessesByName("spotify").Length >= 1;
        }

        /// <summary>
        /// Checks if Spotify's WebHelper is running (Needed for API Calls)
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static Boolean IsSpotifyWebHelperRunning()
        {
            return Process.GetProcessesByName("spotifywebhelper").Length >= 1;
        }

        /// <summary>
        /// Determines whether [spotify is installed].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [spotify is installed]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSpotifyInstalled()
        {
            bool isInstalled = false;

            // Checks if UWP Spotify is installed.
            string uwpSpotifyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\SpotifyAB.SpotifyMusic_zpdnekdrzrea0");

            isInstalled = Directory.Exists(uwpSpotifyPath);

            // If UWP Spotify is not installed, try look for desktop version
            if (!isInstalled)
            {
                string desktopSpotifyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Spotify\Spotify.exe");
                isInstalled = File.Exists(desktopSpotifyPath);
            }

            return isInstalled;
        }

        /// <summary>
        /// Runs Spotify
        /// </summary>
        public static void RunSpotify()
        {
            if (!IsSpotifyRunning() && File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotify.exe")))
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"spotify\spotify.exe"));
        }

        /// <summary>
        /// Runs Spotify's WebHelper
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

        public void Dispose()
        {
            if (_eventTimer == null)
                return;
            _eventTimer.Enabled = false;
            _eventTimer.Elapsed -= ElapsedTick;
        }
    }
}