namespace SpotifyAPI.Local
{
    // ReSharper disable once InconsistentNaming
    public class SpotifyLocalAPIConfig
    {
        public int TimerInterval { get; set; } = 50;

        public string HostUrl { get; set; } = "http://127.0.0.1";

        public int Port { get; set; } = 4381;

        public ProxyConfig ProxyConfig { get; set; }

        public string UserAgent { get; set; } = "Spotify (1.0.85.257.g0f8531bd)";
    }
}