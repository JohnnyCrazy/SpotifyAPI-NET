using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace SpotifyAPIv1
{
    public class SpotifyMusicHandler
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("nircmd.dll")]
        public static extern bool DoNirCmd(String NirCmdStr);

        RemoteHandler rh;
        StatusResponse sr;
        const byte VK_MEDIA_NEXT_TRACK = 0xb0;
        const byte VK_MEDIA_PREV_TRACK = 0xb1;

        public SpotifyMusicHandler()
        {
            rh = RemoteHandler.GetInstance();
        }
        void PressKey(byte keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        public Boolean IsPlaying()
        {
            return sr.playing;
        }
        public double GetVolume()
        {
            return sr.volume;
        }
        public void PlayURL(String url)
        {
            rh.SendPlayRequest(url);
        }
        public Boolean IsAdRunning()
        {
            return !sr.next_enabled && !sr.prev_enabled;
        }
        public Track GetCurrentTrack()
        {
            return sr.track;
        }
        public void Skip()
        {
            PressKey(VK_MEDIA_NEXT_TRACK);
        }
        public double GetTrackPosition()
        {
            return sr.playing_position;
        }
        public void Mute()
        {
            if(File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 1");
        }
        public void UnMute()
        {
            if (File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 0");
        }
        public void Previous()
        {
            PressKey(VK_MEDIA_PREV_TRACK);
        }
        public void Pause()
        {
            rh.SendPauseRequest();
            
        }
        public void Play()
        {
            rh.SendPlayRequest();
        }
        public StatusResponse GetStatusResponse()
        {
            return sr;
        }

        internal void Update(StatusResponse sr)
        {
            this.sr = sr;
        }
    }
}
