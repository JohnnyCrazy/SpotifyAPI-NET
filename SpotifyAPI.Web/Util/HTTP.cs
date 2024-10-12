using System.Net;

namespace SpotifyAPI.Web
{
  internal static class HTTPUtil
  {
    public static bool StatusCodeIsSuccess(HttpStatusCode statusCode)
    {
      return ((int)statusCode >= 200) && ((int)statusCode <= 299);
    }
  }
}
