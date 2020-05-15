using System;
namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Used when requesting a token from spotify oauth services (Authorization Code Auth)
  /// </summary>
  public class AuthorizationCodeTokenRequest
  {
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

    public string ClientId { get; }
    public string ClientSecret { get; }
    public string Code { get; }
    public Uri RedirectUri { get; }
  }
}
