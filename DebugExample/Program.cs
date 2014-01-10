using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPIv1;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace DebugExample
{
    class Program
    {
        static SpotifyAPI spotify;
        static int title;
        static int artist;
        static int album;
        static int time;
        static void Main(string[] args)
        {
            API.API_DestroyAllVisual();
            int boxid = API.API_BoxCreate(620, 150, 140, 60, 0xB6000000,true);
            API.API_BoxSetBorderColor(boxid, 0xFFFF7700);

            
            spotify = new SpotifyAPI();
            spotify.Connect();
            log("Connected...");
            spotify.Update();
            log("Updating first time...");
            spotify.GetEventHandler().OnTrackChange += new SpotifyAPIv1.EventHandler.TrackChangeEventHandler(namechange);
            spotify.GetEventHandler().OnPlayStateChange += new SpotifyAPIv1.EventHandler.PlayStateEventHandler(playstate);
            spotify.GetEventHandler().OnVolumeChange += new SpotifyAPIv1.EventHandler.VolumeChangeEventHandler(volumechange);
            spotify.GetEventHandler().OnTrackTimeChange += new SpotifyAPIv1.EventHandler.TrackTimeChangeEventHandler(timechange);
            spotify.GetEventHandler().ListenForEvents(true);

            title = API.API_TextCreate("Arial", 19, true, false, 620, 150, 0xFFFFFFFF, spotify.GetMusicHandler().GetCurrentTrack().GetName(), true);
            artist = API.API_TextCreate("Arial", 19, true, false, 620, 160, 0xFFFFFFFF, "von: " + spotify.GetMusicHandler().GetCurrentTrack().GetArtist(), true);
            album = API.API_TextCreate("Arial", 19, true, false, 620, 170, 0xFFFFFFFF, "Album: " + spotify.GetMusicHandler().GetCurrentTrack().GetAlbum(), true);
            Console.WriteLine(spotify.GetMusicHandler().GetTrackPosition());
            time = API.API_TextCreate("Arial", 19, false, false, 620, 180, 0xFFFFFFFF, "Time: " + timede(spotify.GetMusicHandler().GetTrackPosition()), true);

            String input = "";
            while((input = Console.ReadLine()) != "q")
            {
                if (input == "pause")
                    spotify.GetMusicHandler().Pause();
                if (input == "play")
                    spotify.GetMusicHandler().Play();
                if (input == "skip")
                    spotify.GetMusicHandler().Skip();
                if (input == "prev")
                    spotify.GetMusicHandler().Previous();
            }
            API.API_DestroyAllVisual();
        }
        private static String timede(double sec)
        {
            String test = "{0}:{1}";
            TimeSpan span = TimeSpan.FromSeconds(sec);
            return String.Format(test, span.Minutes, span.Seconds);
        }
        private static void timechange(TrackTimeChangeEventArgs e)
        {
            log(e.track_time.ToString());
            API.API_TextSetString(time, "Time: " + timede(spotify.GetMusicHandler().GetTrackPosition()));
        }
        public static void namechange(TrackChangeEventArgs e)
        {
            API.API_TextSetString(title, e.new_track.GetName());
            API.API_TextSetString(artist,"Von :" + e.new_track.GetArtist());
            API.API_TextSetString(album, "Album: " + e.new_track.GetAlbum());
            log("Old Name: " + e.old_track.GetName());
            log("New Name: " + e.new_track.GetName());
        }
        public static void playstate(PlayStateEventArgs e)
        {
            log("PlayState: " + e.playing);
        }
        public static void volumechange(VolumeChangeEventArgs e)
        {
            log("New Volume: " + e.new_volume);
        }
        public static void log(String log)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "]  " + log);
        }
    }
}
