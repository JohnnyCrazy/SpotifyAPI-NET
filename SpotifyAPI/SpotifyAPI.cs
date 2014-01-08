using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Management;
using System.Diagnostics;
using System.Drawing;

namespace SpotifyAPIv1
{
    public class SpotifyAPI
    {
        MusicHandler mh;
        RemoteHandler rh;
        EventHandler eh;
        public SpotifyAPI()
        {
            rh = RemoteHandler.GetInstance();
            mh = new MusicHandler();
            eh = new EventHandler(this, mh);
        }

        public void Connect()
        {
            rh.Init();
        }
        public MusicHandler GetMusicHandler()
        {
            return mh;
        }
        public EventHandler GetEventHandler()
        {
            return eh;
        }
        public Boolean IsSpotifyRunning(Boolean runIt)
        {
            if (Process.GetProcessesByName("SpotifyWebHelper").Length < 1)
            {
                if (runIt)
                {
                    System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Data\\SpotifyWebHelper.exe");
                    return IsSpotifyRunning(false);
                }
                else
                    return false;
            }
            else
                return true;
        }
        public void Update()
        {
            mh.Update(rh.Update());
        }
    }
}
