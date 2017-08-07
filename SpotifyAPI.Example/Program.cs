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

        public static void Main(string[] args)
        {
            var statusResult = Start();
            statusResult.ContinueWith(task =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(task.Result));
            });
            Console.ReadLine();
        }

        public static async Task<StatusResponse> Start()
        {
            Console.WriteLine("Starting...");
            _spotify = new SpotifyLocalAPI();

            while (!await _spotify.Connect())
            {
                Console.WriteLine("Trying to connect...");
                await _spotify.Connect();
            }

            return await _spotify.GetStatus(); // never pass the while.... 
        }
    }
}
