using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// An OAuth Client, which allows to get inital and updated tokens from the Spotify Service
  /// </summary>
  public interface IOAuthClient
  {
    /// <summary>
    /// Requests a new token using client_ids and client_secrets.
    /// If the token is expired, simply call the funtion again to get a new token
    /// </summary>
    /// <param name="request"></param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow
    /// </remarks>
    /// <returns></returns>
    Task<CredentialsTokenResponse> RequestToken(ClientCredentialsRequest request);

    /// <summary>
    /// Refresh an already received token via Authorization Code Auth
    /// </summary>
    /// <param name="request"></param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeRefreshResponse> RequestToken(AuthorizationCodeRefreshRequest request);

    /// <summary>
    /// Reequest an initial token via Authorization Code Auth
    /// </summary>
    /// <param name="request"></param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeTokenResponse> RequestToken(AuthorizationCodeTokenRequest request);
  }
}
