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
        static SpotifyAPI test;
        static void Main(string[] args)
        {
            test = new SpotifyAPI();
            test.Connect();
            Console.WriteLine("Connected...");
            test.Update();
            Console.WriteLine("Updating first time...");
            test.GetEventHandler().OnTrackNameChange += new SpotifyAPIv1.EventHandler.NameChangeEventHandler(namechange);
            test.GetEventHandler().OnPlayStateChange += new SpotifyAPIv1.EventHandler.PlayStateEventHandler(playstate);
            test.GetEventHandler().OnVolumeChange += new SpotifyAPIv1.EventHandler.VolumeChangeEventHandler(volumechange);
            test.GetEventHandler().ListenForEvents(true);
            Console.ReadLine();
        }
        public static void namechange(NameChangeEventArgs e)
        {
            Console.WriteLine("Old Name: " + e.old_track.GetName());
            Console.WriteLine("New Name: " + e.new_track.GetName());
            //API.API_AddChatMessage(0xFFFFFF, "{2ecc71}" + e.new_track.GetName() + " {FFFFFF}[by]{2ecc71} " + e.new_track.GetArtist() + " {8e44ad}[" + e.new_track.GetAlbum() + "]");
        }
        public static void playstate(PlayStateEventArgs e)
        {
            Console.WriteLine("PlayState: " + e.playing);
        }
        public static void volumechange(VolumeChangeEventArgs e)
        {
            Console.WriteLine("New Volume: " + e.new_volume);
        }
    }
}
