using System;
using System.Net;

namespace SpotifyAPI.Local
{
    internal class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }

        public ExtendedWebClient()
        {
            Timeout = 2000;
            Headers.Add("Origin", "https://embed.spotify.com");
            Headers.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            if (webRequest != null)
                webRequest.Timeout = Timeout;
            return webRequest;
        }
    }
}