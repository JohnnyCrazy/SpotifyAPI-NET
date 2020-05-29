using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IOAuthClient
  {
    /// <summary>
    /// Requests a new token using client_ids and client_secrets.
    /// If the token is expired, simply call the funtion again to get a new token
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<CredentialsTokenResponse> RequestToken(ClientCredentialsRequest request);

    /// <summary>
    /// Refresh an already received token via Authorization Code Auth
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthorizationCodeRefreshResponse> RequestToken(AuthorizationCodeRefreshRequest request);
    Task<AuthorizationCodeTokenResponse> RequestToken(AuthorizationCodeTokenRequest request);
  }
}
