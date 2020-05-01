using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [System.Serializable]
  public class APIUnauthorizedException : APIException
  {
    public APIUnauthorizedException(IResponse response) : base(response) { }
  }
}
