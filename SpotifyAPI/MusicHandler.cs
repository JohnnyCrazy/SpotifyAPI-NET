using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpotifyAPIv1
{
    public class MusicHandler
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        RemoteHandler rh;
        StatusResponse sr;
        const byte VK_MEDIA_NEXT_TRACK = 0xb0;
        const byte VK_MEDIA_PREV_TRACK = 0xb1;

        public MusicHandler()
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
