using System.Net;

namespace SpotifyAPI.Web.Models
{
    public class ResponseInfo
    {
        public WebHeaderCollection Headers { get; set; }

        public static readonly ResponseInfo Empty = new ResponseInfo();
    }
}