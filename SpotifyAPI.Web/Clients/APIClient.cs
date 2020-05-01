using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public abstract class APIClient
  {
    public APIClient(IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      API = apiConnector;
    }

    public IAPIConnector API { get; set; }
  }
}
