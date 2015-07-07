using System;

namespace SpotifyAPI.Local.Models
{
    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    class Cfid
    {
        public Error Error { get; set; }
        public String Token { get; set; }
        public String Version { get; set; }
        public String ClientVersion { get; set; }
        public Boolean Running { get; set; }
    }

    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    class Error
    {
        public String Type { get; set; }
        public String Message { get; set; }
    }
}
