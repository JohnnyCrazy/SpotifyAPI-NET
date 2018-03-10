using System.Net.Http.Headers;

namespace SpotifyAPI.Web.Models
{
    public class ResponseInfo
    {
        public HttpResponseHeaders Headers { get; set; }

        public static readonly ResponseInfo Empty = new ResponseInfo();
    }
}