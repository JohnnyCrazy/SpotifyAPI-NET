using SpotifyAPI.Web;
using System;
using System.Threading.Tasks;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;

namespace SpotifyAPI.Example
{
    public class Program
    {
        private static SpotifyLocalAPI _spotify;

        public static void Main(string[] args)
        {
            Start();
            Console.ReadLine();
        }

        public static async Task Start()
        {
            Console.WriteLine("Starting...");
            _spotify = new SpotifyLocalAPI();

            while (!await _spotify.Connect())
            {
                await _spotify.Connect();
            }
            StatusResponse status = await _spotify.GetStatus(); // never pass the while.... 
            Console.WriteLine(status.Track.TrackResource.Name);
        }
    }
}
