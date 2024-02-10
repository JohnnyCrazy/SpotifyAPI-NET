namespace SpotifyAPI.Web
{
  public class PKCETokenRefreshRequest
  {
    /// <summary>
    /// Request model for refreshing a access token via PKCE Token
    /// </summary>
    /// <param name="clientId">The Client ID of your Spotify Application (See Spotify Dev Dashboard).</param>
    /// <param name="refreshToken">The received refresh token. Expires after one refresh</param>
    public PKCETokenRefreshRequest(string clientId, string refreshToken)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

      ClientId = clientId;
      RefreshToken = refreshToken;
    }

    /// <summary>
    /// The Client ID of your Spotify Application (See Spotify Dev Dashboard).
    /// </summary>
    /// <value></value>
    public string ClientId { get; }

    /// <summary>
    /// The received refresh token.
    /// </summary>
    /// <value></value>
    public string RefreshToken { get; }
  }
}
