using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  /// <summary>
  ///   This Authenticator requests new credentials token on demand and stores them into memory.
  ///   It is unable to query user specifc details.
  /// </summary>
  public class ClientCredentialsAuthenticator : IAuthenticator
  {
    /// <summary>
    /// Initiate a new instance. The initial token will be fetched when the first API call occurs.
    /// </summary>
    /// <param name="clientId">
    /// The ClientID, defined in a spotify application in your Spotify Developer Dashboard.
    /// </param>
    /// <param name="clientSecret">
    /// The ClientSecret, defined in a spotify application in your Spotify Developer Dashboard.
    /// </param>
    public ClientCredentialsAuthenticator(string clientId, string clientSecret) : this(clientId, clientSecret, null) { }

    /// <summary>
    /// Initiate a new instance. The initial token is provided and will be used if not expired
    /// </summary>
    /// <param name="clientId">
    /// The ClientID, defined in a spotify application in your Spotify Developer Dashboard.
    /// </param>
    /// <param name="clientSecret">
    /// The ClientSecret, defined in a spotify application in your Spotify Developer Dashboard.
    /// </param>
    /// <param name="token">
    /// An optional inital token received earlier.
    /// </param>
    public ClientCredentialsAuthenticator(string clientId, string clientSecret, ClientCredentialsTokenResponse? token)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));

      ClientId = clientId;
      ClientSecret = clientSecret;
      Token = token;
    }

    public ClientCredentialsTokenResponse? Token { get; private set; }

    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientId { get; }

    /// <summary>
    ///   The Client secret, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientSecret { get; }

    public async Task Apply(IRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      if (Token == null || Token.IsExpired)
      {
        var tokenRequest = new ClientCredentialsRequest(ClientId, ClientSecret);
        Token = await OAuthClient.RequestToken(tokenRequest, apiConnector).ConfigureAwait(false);
      }

      request.Headers["Authorization"] = $"{Token.TokenType} {Token.AccessToken}";
    }
  }
}
