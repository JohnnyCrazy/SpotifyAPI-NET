using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SpotifyAPI.SpotifyLocalAPI
{
    class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            webRequest.Timeout = Timeout;
            return webRequest;
        }
    }
}
