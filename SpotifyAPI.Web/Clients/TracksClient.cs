using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class TracksClient : APIClient, ITracksClient
  {
    public TracksClient(IAPIConnector apiConnector) : base(apiConnector) { }
  }
}
