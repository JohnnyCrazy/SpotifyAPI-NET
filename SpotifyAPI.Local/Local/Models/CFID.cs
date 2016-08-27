using System;

namespace SpotifyAPI.Local.Models
{
    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    internal class Cfid
    {
        public Error Error { get; set; }
        public string Token { get; set; }
        public string Version { get; set; }
        public string ClientVersion { get; set; }
        public Boolean Running { get; set; }
    }

    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    internal class Error
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}