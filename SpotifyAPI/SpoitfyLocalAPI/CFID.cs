using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotifyAPI.SpotifyLocalAPI
{
    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    class CFID
    {
        public Error error { get; set; }
        public String token { get; set; }
        public String version { get; set; }
        public String client_version { get; set; }
        public Boolean running { get; set; }
    }
    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    class Error
    {
        public String type { get; set; }
        public String message { get; set; }
    }
}
