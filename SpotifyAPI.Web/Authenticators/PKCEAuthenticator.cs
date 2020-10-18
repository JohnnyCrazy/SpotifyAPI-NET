using System;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  /// <summary>
  ///   This Authenticator requests new credentials token on demand and stores them into memory.
  ///   It is unable to query user specifc details.
  /// </summary>
  public class PKCEAuthenticator : IAuthenticator
  {
    /// <summary>
    ///   Initiate a new instance. The token will be refreshed once it expires.
    ///   The initialToken will be updated with the new values on refresh!
    /// </summary>
    public PKCEAuthenticator(string clientId, PKCETokenResponse initialToken)
    {
      Ensure.ArgumentNotNull(clientId, nameof(clientId));
      Ensure.ArgumentNotNull(initialToken, nameof(initialToken));

      InitialToken = initialToken;
      ClientId = clientId;
    }

    /// <summary>
    /// This event is called once a new refreshed token was acquired
    /// </summary>
    public event EventHandler<PKCETokenResponse>? TokenRefreshed;


    /// <summary>
    ///   The ClientID, defined in a spotify application in your Spotify Developer Dashboard
    /// </summary>
    public string ClientId { get; }

    /// <summary>
    ///   The initial token passed to the authenticator. Fields will be updated on refresh.
    /// </summary>
    /// <value></value>
    public PKCETokenResponse InitialToken { get; }

    public async Task Apply(IRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      if (InitialToken.IsExpired)
      {
        var tokenRequest = new PKCETokenRefreshRequest(ClientId, InitialToken.RefreshToken);
        var refreshedToken = await OAuthClient.RequestToken(tokenRequest, apiConnector).ConfigureAwait(false);

        InitialToken.AccessToken = refreshedToken.AccessToken;
        InitialToken.CreatedAt = refreshedToken.CreatedAt;
        InitialToken.ExpiresIn = refreshedToken.ExpiresIn;
        InitialToken.Scope = refreshedToken.Scope;
        InitialToken.TokenType = refreshedToken.TokenType;
        InitialToken.RefreshToken = refreshedToken.RefreshToken;

        TokenRefreshed?.Invoke(this, InitialToken);
      }

      request.Headers["Authorization"] = $"{InitialToken.TokenType} {InitialToken.AccessToken}";
    }
  }
}
