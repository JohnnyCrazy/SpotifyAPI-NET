namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Used when requesting a refreshed token from spotify oauth services (Authorization Code Auth)
  /// </summary>
  public class AuthorizationCodeRefreshRequest
  {
    public AuthorizationCodeRefreshRequest(string clientId, string clientSecret, string refreshToken)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
      Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

      ClientId = clientId;
      ClientSecret = clientSecret;
      RefreshToken = refreshToken;
    }

    public string RefreshToken { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }
  }
}

