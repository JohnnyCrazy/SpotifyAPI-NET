namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Used when requesting a refreshed token from spotify oauth services (Authorization Code Auth)
  /// </summary>
  public class AuthorizationCodeRefreshRequest
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="clientId">The Client ID of your Spotify Application (See Spotify Dev Dashboard)</param>
    /// <param name="clientSecret">The Client Secret of your Spotify Application (See Spotify Dev Dashboard)</param>
    /// <param name="refreshToken">The refresh token received from an earlier authorization code grant</param>
    public AuthorizationCodeRefreshRequest(string clientId, string clientSecret, string refreshToken)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
      Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

      ClientId = clientId;
      ClientSecret = clientSecret;
      RefreshToken = refreshToken;
    }

    /// <summary>
    /// The refresh token received from an earlier authorization code grant
    /// </summary>
    /// <value></value>
    public string RefreshToken { get; }

    /// <summary>
    /// The Client ID of your Spotify Application (See Spotify Dev Dashboard)
    /// </summary>
    /// <value></value>
    public string ClientId { get; }

    /// <summary>
    /// The Client Secret of your Spotify Application (See Spotify Dev Dashboard)
    /// </summary>
    /// <value></value>
    public string ClientSecret { get; }
  }
}

