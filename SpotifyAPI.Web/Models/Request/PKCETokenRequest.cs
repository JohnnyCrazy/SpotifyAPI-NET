using System;

namespace SpotifyAPI.Web
{
  public class PKCETokenRequest
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="clientId">The Client ID of your Spotify Application (See Spotify Dev Dashboard).</param>
    /// <param name="code">The code received from the spotify response.</param>
    /// <param name="redirectUri">The redirectUri which was used to initiate the authentication.</param>
    /// <param name="codeVerifier">
    /// The value of this parameter must match the value of the code_verifier
    /// that your app generated in step 1.
    /// </param>
    public PKCETokenRequest(string clientId, string code, Uri redirectUri, string codeVerifier)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(code, nameof(code));
      Ensure.ArgumentNotNullOrEmptyString(codeVerifier, nameof(codeVerifier));
      Ensure.ArgumentNotNull(redirectUri, nameof(redirectUri));

      ClientId = clientId;
      CodeVerifier = codeVerifier;
      Code = code;
      RedirectUri = redirectUri;
    }

    /// <summary>
    /// The Client ID of your Spotify Application (See Spotify Dev Dashboard).
    /// </summary>
    /// <value></value>
    public string ClientId { get; }

    /// <summary>
    /// The value of this parameter must match the value of the code_verifier
    /// that your app generated in step 1.
    /// </summary>
    /// <value></value>
    public string CodeVerifier { get; }

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
