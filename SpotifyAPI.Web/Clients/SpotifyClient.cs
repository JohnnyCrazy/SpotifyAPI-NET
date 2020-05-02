using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SpotifyClient : ISpotifyClient
  {
    private readonly IAPIConnector _apiConnector;

    public SpotifyClient(string token, string tokenType = "Bearer") :
      this(SpotifyClientConfig.CreateDefault(token, tokenType))
    { }

    public SpotifyClient(SpotifyClientConfig config)
    {
      Ensure.ArgumentNotNull(config, nameof(config));

      _apiConnector = config.CreateAPIConnector();
      UserProfile = new UserProfileClient(_apiConnector);
      Browse = new BrowseClient(_apiConnector);
    }

    public IUserProfileClient UserProfile { get; }

    public IBrowseClient Browse { get; }
  }
}
