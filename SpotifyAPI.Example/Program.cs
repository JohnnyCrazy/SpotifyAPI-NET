using SpotifyAPI.Web;
using System;
using System.Threading.Tasks;

namespace SpotifyAPI.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start();
            Console.ReadLine();
        }

        public static async Task Start()
        {
            Console.WriteLine("Starting...");
            SpotifyWebAPI spotify = new SpotifyWebAPI();
            var track = await spotify.GetTrack("asdasd6hlAgsvXoIWJrcVD7qYp4N");
            var track2 = await spotify.GetTrack("4kG3iPdJ13SNOoCnhdlpx7");

            Console.WriteLine($"Server: {track.Header("Server")}");


            Console.WriteLine(track.Name);
            Console.WriteLine(track2.Name);
            Console.WriteLine("Finished");
        }
    }
}
