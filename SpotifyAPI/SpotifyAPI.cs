using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SpotifyAPIv1
{
    public class SpotifyAPI
    {
        SpotifyMusicHandler mh;
        RemoteHandler rh;
        SpotifyEventHandler eh;
        public SpotifyAPI()
        {
            rh = RemoteHandler.GetInstance();
            mh = new SpotifyMusicHandler();
            eh = new SpotifyEventHandler(this, mh);
        }

        public void Connect()
        {
            rh.Init();
        }
        public SpotifyMusicHandler GetMusicHandler()
        {
            return mh;
        }
        public SpotifyEventHandler GetEventHandler()
        {
            return eh;
        }
        public static Boolean IsSpotifyRunning()
        {
            if (Process.GetProcessesByName("spotify").Length < 1)
                return false;
            return true;
        }
        public static Boolean IsSpotifyWebHelperRunning()
        {
            if (Process.GetProcessesByName("SpotifyWebHelper").Length < 1)
                return false;
            return true;
        }
        public void RunSpotify()
        {
            if(!IsSpotifyRunning())
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\spotify.exe");
        }
        public void RunSpotifyWebHelper()
        {
            if (!IsSpotifyWebHelperRunning())
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Data\\SpotifyWebHelper.exe");
        }
        public static Boolean IsValidSpotifyURL(String url)
        {
            String[] types = new String[] { "track","album","local","artist"};
            String[] split = url.Split(':');
            if (split.Length < 3)
                return false;
            return split[0] == "spotify" && Array.IndexOf(types, split[1]) > -1 && split[2].Length == 22;
        }
        public void Update()
        {
            if (!SpotifyAPI.IsSpotifyWebHelperRunning())
                return;
            mh.Update(rh.Update());
        }
    }
}
