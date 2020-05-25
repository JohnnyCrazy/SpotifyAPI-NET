using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  /// <summary>
  ///   This Authenticator requests new credentials token on demand and stores them into memory.
  ///   It is unable to query user specifc details.
  /// </summary>
  public class CredentialsAuthenticator : IAuthenticator
  {
    private CredentialsTokenResponse? _token;

    /// <summary>
    ///   Initiate a new instance. The first token will be fetched when the first API call occurs
    /// </summary>
    /// <param name="clientId">
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </param>
    /// <param name="clientSecret">
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </param>
    public CredentialsAuthenticator(string clientId, string clientSecret)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));

      ClientId = clientId;
      ClientSecret = clientSecret;
    }

    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientId { get; }

    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientSecret { get; }

    public async Task Apply(IRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      if (_token == null || _token.IsExpired)
      {
        var tokenRequest = new ClientCredentialsRequest(ClientId, ClientSecret);
        _token = await OAuthClient.RequestToken(tokenRequest, apiConnector).ConfigureAwait(false);
      }

      request.Headers["Authorization"] = $"{_token.TokenType} {_token.AccessToken}";
    }
  }
}
