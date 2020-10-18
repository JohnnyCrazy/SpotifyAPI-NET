using System;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  /// <summary>
  ///   This Authenticator requests new credentials token on demand and stores them into memory.
  ///   It is unable to query user specifc details.
  /// </summary>
  public class AuthorizationCodeAuthenticator : IAuthenticator
  {
    /// <summary>
    ///   Initiate a new instance. The token will be refreshed once it expires.
    ///   The initialToken will be updated with the new values on refresh!
    /// </summary>
    public AuthorizationCodeAuthenticator(string clientId, string clientSecret, AuthorizationCodeTokenResponse initialToken)
    {
      Ensure.ArgumentNotNull(clientId, nameof(clientId));
      Ensure.ArgumentNotNull(clientSecret, nameof(clientSecret));
      Ensure.ArgumentNotNull(initialToken, nameof(initialToken));

      InitialToken = initialToken;
      ClientId = clientId;
      ClientSecret = clientSecret;
    }

    /// <summary>
    /// This event is called once a new refreshed token was acquired
    /// </summary>
    public event EventHandler<AuthorizationCodeTokenResponse>? TokenRefreshed;


    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientId { get; }

    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientSecret { get; }

    /// <summary>
    ///   The inital token passed to the authenticator. Fields will be updated on refresh.
    /// </summary>
    /// <value></value>
    public AuthorizationCodeTokenResponse InitialToken { get; }

    public async Task Apply(IRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      if (InitialToken.IsExpired)
      {
        var tokenRequest = new AuthorizationCodeRefreshRequest(ClientId, ClientSecret, InitialToken.RefreshToken);
        var refreshedToken = await OAuthClient.RequestToken(tokenRequest, apiConnector).ConfigureAwait(false);

        InitialToken.AccessToken = refreshedToken.AccessToken;
        InitialToken.CreatedAt = refreshedToken.CreatedAt;
        InitialToken.ExpiresIn = refreshedToken.ExpiresIn;
        InitialToken.Scope = refreshedToken.Scope;
        InitialToken.TokenType = refreshedToken.TokenType;

        TokenRefreshed?.Invoke(this, InitialToken);
      }

      request.Headers["Authorization"] = $"{InitialToken.TokenType} {InitialToken.AccessToken}";
    }
  }
}
