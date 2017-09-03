namespace SpotifyAPI.Local
{
    // ReSharper disable once InconsistentNaming
    public class SpotifyLocalAPIConfig
    {
        public int TimerInterval { get; set; } = 50;

        public string HostUrl { get; set; } = "http://127.0.0.1";

        public int Port { get; set; } = 4381;
    }
}