namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Used when requesting a token from spotify oauth services (Client Credentials Auth)
  /// </summary>
  public class ClientCredentialsRequest
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="clientId">The Client ID of your Spotify Application (See Spotify Dev Dashboard)</param>
    /// <param name="clientSecret">The Client Secret of your Spotify Application (See Spotify Dev Dashboard)</param>
    public ClientCredentialsRequest(string clientId, string clientSecret)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));

      ClientId = clientId;
      ClientSecret = clientSecret;
    }

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

