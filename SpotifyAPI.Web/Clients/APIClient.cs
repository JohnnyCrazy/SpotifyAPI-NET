using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public abstract class APIClient
  {
    protected APIClient(IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      API = apiConnector;
    }

    protected IAPIConnector API { get; set; }
  }
}
