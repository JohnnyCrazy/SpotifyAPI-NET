using System;
namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Used when requesting a token from spotify oauth services (Authorization Code Auth)
  /// </summary>
  public class AuthorizationCodeTokenRequest
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="clientId">The Client ID of your Spotify Application (See Spotify Dev Dashboard).</param>
    /// <param name="clientSecret">The Client Secret of your Spotify Application (See Spotify Dev Dashboard).</param>
    /// <param name="code">The code received from the spotify response.</param>
    /// <param name="redirectUri">The redirectUri which was used to initiate the authentication.</param>
    public AuthorizationCodeTokenRequest(string clientId, string clientSecret, string code, Uri redirectUri)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
      Ensure.ArgumentNotNullOrEmptyString(code, nameof(code));
      Ensure.ArgumentNotNull(redirectUri, nameof(redirectUri));

      ClientId = clientId;
      ClientSecret = clientSecret;
      Code = code;
      RedirectUri = redirectUri;
    }

    /// <summary>
    /// The Client ID of your Spotify Application (See Spotify Dev Dashboard).
    /// </summary>
    /// <value></value>
    public string ClientId { get; }

    /// <summary>
    /// The Client Secret of your Spotify Application (See Spotify Dev Dashboard).
    /// </summary>
    /// <value></value>
    public string ClientSecret { get; }

    /// <summary>
    /// The code received from the spotify response.
    /// </summary>
    /// <value></value>
    public string Code { get; }

    /// <summary>
    /// The redirectUri which was used to initiate the authentication.
    /// </summary>
    /// <value></value>
    public Uri RedirectUri { get; }
  }
}

