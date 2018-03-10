using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;

namespace SpotifyAPI.Example
{
    public class Program
    {
        private static SpotifyLocalAPI _spotify;

        public static async Task Main(string[] args)
        {
            var statusResult = await Start();
            if (statusResult == null) return;

            Console.WriteLine(JsonConvert.SerializeObject(statusResult));
            Console.ReadLine();
        }

        public static async Task<StatusResponse> Start()
        {
            Console.WriteLine("Starting...");
            _spotify = new SpotifyLocalAPI();

            Console.WriteLine("Trying to connect...");
            while (!await _spotify.Connect())
            {
                Console.WriteLine("Failed to connect. Retry? (y/[n])");
                var key = Console.ReadLine()?.ToLowerInvariant();
                if (key == "y")
                {
                    Console.WriteLine("Trying to connect...");
                    continue;
                }
                return null;
            }

            return await _spotify.GetStatus();
        }
    }
}
