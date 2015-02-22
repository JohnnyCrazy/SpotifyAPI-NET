using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SpotifyAPI.SpotifyLocalAPI
{
    public class SpotifyLocalAPIClass
    {
        SpotifyMusicHandler mh;
        RemoteHandler rh;
        SpotifyEventHandler eh;
        static bool betaMode = false;

        public SpotifyLocalAPIClass()
        {
            rh = RemoteHandler.GetInstance();
            mh = new SpotifyMusicHandler();
            eh = new SpotifyEventHandler(this, mh);
        }

        public SpotifyLocalAPIClass(bool betaMode) : this()
        {
            SpotifyLocalAPIClass.betaMode = betaMode;
        }

        /// <summary>
        /// Connects with Spotify. Needs to be called before all other SpotifyAPI functions
        /// </summary>
        /// <returns>Returns true, if it was successful, false if not</returns>
        public Boolean Connect()
        {
            return rh.Init();
        }

        /// <summary>
        /// Returns the MusicHandler
        /// </summary>
        /// <returns>Returns the MusicHandler</returns>
        public SpotifyMusicHandler GetMusicHandler()
        {
            return mh;
        }

        /// <summary>
        /// Returns the EventHanlder
        /// </summary>
        /// <returns>Returns the EventHanlder</returns>
        public SpotifyEventHandler GetEventHandler()
        {
            return eh;
        }

        /// <summary>
        /// Checks if Spotify is running
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static Boolean IsSpotifyRunning()
        {
            var procName = (betaMode) ? "spotifybeta" : "spotify";

            if (Process.GetProcessesByName(procName).Length < 1)
                return false;

            return true;
        }

        /// <summary>
        /// Checks if Spotify's WebHelper is running (Needed for API Calls)
        /// </summary>
        /// <returns>True, if it's running, false if not</returns>
        public static Boolean IsSpotifyWebHelperRunning()
        {
            var procName = (betaMode) ? "spotifybetawebhelper" : "spotifywebhelper";

            if (Process.GetProcessesByName(procName).Length < 1)
                return false;

            return true;
        }

        /// <summary>
        /// Runs Spotify
        /// </summary>
        public void RunSpotify()
        {
            var pathToExe = (betaMode) ? @"\spotifybeta\spotifybeta.exe" : @"\spotify\spotify.exe";

            if (!IsSpotifyRunning())
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + pathToExe);
        }

        /// <summary>
        /// Runs Spotify's WebHelper
        /// </summary>
        public void RunSpotifyWebHelper()
        {
            var pathToExe = (betaMode) ? @"\spotifybeta\spotifybetawebhelper.exe" : @"\spotify\data\spotifywebhelper.exe";

            if (!IsSpotifyWebHelperRunning())
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + pathToExe);
        }

        /// <summary>
        /// Checks for a valid SpotifyURL (Still not finished)
        /// </summary>
        /// <param name="url">The Spotify URI starting with "spotify:"</param>
        /// <returns>True if the URI is valid, false if not</returns>
        public static Boolean IsValidSpotifyURI(String uri)
        {
            String[] types = new String[] { "track", "album", "local", "artist" };
            String[] split = uri.Split(':');
            
            if (split.Length < 3)
                return false;
            
            return split[0] == "spotify" && Array.IndexOf(types, split[1]) > -1 && split[2].Length == 22;
        }

        /// <summary>
        /// Updates and Fetches all current information about the current track etc.
        /// </summary>
        public void Update()
        {
            if (!SpotifyLocalAPIClass.IsSpotifyWebHelperRunning() || !SpotifyLocalAPIClass.IsSpotifyRunning())
                return;

            mh.Update(rh.Update());
        }
    }
}
