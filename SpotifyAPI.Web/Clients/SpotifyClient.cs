using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SpotifyClient : ISpotifyClient
  {
    private IAPIConnector _apiConnector;

    public SpotifyClient(string token, string tokenType = "Bearer") :
      this(new TokenHeaderAuthenticator(token, tokenType))
    { }

    public SpotifyClient(IAuthenticator authenticator) :
      this(new APIConnector(SpotifyUrls.API_V1, authenticator))
    { }

    public SpotifyClient(IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      _apiConnector = apiConnector;
      UserProfile = new UserProfileClient(_apiConnector);
      Browse = new BrowseClient(_apiConnector);
    }

    public IUserProfileClient UserProfile { get; }

    public IBrowseClient Browse { get; }
  }
}
