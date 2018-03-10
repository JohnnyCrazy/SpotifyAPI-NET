using System;
using System.Net.Http;

namespace SpotifyAPI.Local
{
    internal class ExtendedWebClient : HttpClient
    {
#if NET461
        public ExtendedWebClient() : base()
        {
            Timeout = new TimeSpan(0, 0, 2);
            DefaultRequestHeaders.Add("Origin", "https://embed.spotify.com");
            DefaultRequestHeaders.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
        }
#else
        private static readonly WinHttpHandler HttpHandler = new WinHttpHandler
        {
            ServerCertificateValidationCallback = (message, certificate2, arg3, arg4) => true
        };

        public ExtendedWebClient() : base(HttpHandler, false)
        {
            Timeout = new TimeSpan(0, 0, 2);
            DefaultRequestHeaders.Add("Origin", "https://embed.spotify.com");
            DefaultRequestHeaders.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
        }
#endif
    }
}