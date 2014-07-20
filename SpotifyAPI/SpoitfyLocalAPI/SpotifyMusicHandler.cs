using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace SpotifyAPI.SpotifyLocalAPI
{
    public class SpotifyMusicHandler
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("nircmd.dll")]
        private static extern bool DoNirCmd(String NirCmdStr);

        RemoteHandler rh;
        StatusResponse sr;

        //Constants for the Keyboard Event (NextTrack + PreviousTrack)
        const byte VK_MEDIA_NEXT_TRACK = 0xb0;
        const byte VK_MEDIA_PREV_TRACK = 0xb1;
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        public SpotifyMusicHandler()
        {
            rh = RemoteHandler.GetInstance();
        }
        /// <summary>
        /// Simulates a KeyPress
        /// </summary>
        /// <param name="keyCode">The keycode for the represented Key</param>
        void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        /// <summary>
        /// Checks if a song is playing
        /// </summary>
        /// <returns>True if a song is playing, false if not</returns>
        public Boolean IsPlaying()
        {
            return sr.playing;
        }
        /// <summary>
        /// Returns the current Volume
        /// </summary>
        /// <returns>A value between 0 and 1</returns>
        public double GetVolume()
        {
            return sr.volume;
        }
        /// <summary>
        /// Plays a Spotify URI
        /// </summary>
        /// <param name="uri">The Spotify URI. Can be checked with <seealso cref="SpotifyLocalAPIClass.IsValidSpotifyURI"/></param>
        public void PlayURL(String uri)
        {
            rh.SendPlayRequest(uri);
        }
        /// <summary>
        /// Checks if the current "Track" is an Advert
        /// </summary>
        /// <returns>True if it's an Advert, false if not</returns>
        public Boolean IsAdRunning()
        {
            return !sr.next_enabled && !sr.prev_enabled;
        }
        /// <summary>
        /// Returns the current Track object
        /// </summary>
        /// <returns>Returns the current track object</returns>
        public Track GetCurrentTrack()
        {
            return sr.track;
        }
        /// <summary>
        /// Skips the current song (Using keypress simulation)
        /// </summary>
        public void Skip()
        {
            PressKey(VK_MEDIA_NEXT_TRACK);
        }
        /// <summary>
        /// Emulates the "Previous" Key (Using keypress simulation)
        /// </summary>
        public void Previous()
        {
            PressKey(VK_MEDIA_PREV_TRACK);
        }
        /// <summary>
        /// Returns the current track postion
        /// </summary>
        /// <returns>A double between 0 and ∞</returns>
        public double GetTrackPosition()
        {
            return sr.playing_position;
        }
        /// <summary>
        /// Mutes Spotify (Requires nircmd.dll)
        /// </summary>
        public void Mute()
        {
            if(File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 1");
        }
        /// <summary>
        /// Unmutes Spotify (Requires nircmd.dll)
        /// </summary>
        public void UnMute()
        {
            if (File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 0");
        }
        /// <summary>
        /// Pause function
        /// </summary>
        public void Pause()
        {
            rh.SendPauseRequest();
        }
        /// <summary>
        /// Play function
        /// </summary>
        public void Play()
        {
            rh.SendPlayRequest();
        }
        /// <summary>
        /// Returns all Informations gathered by the JSON Request
        /// </summary>
        /// <returns>A StatusResponse object</returns>
        public StatusResponse GetStatusResponse()
        {
            return sr;
        }
        //Used internaly
        internal void Update(StatusResponse sr)
        {
            this.sr = sr;
        }
    }
}
