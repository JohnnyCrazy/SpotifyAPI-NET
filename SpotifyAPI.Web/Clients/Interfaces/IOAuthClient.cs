using System.Threading;
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
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow
    /// </remarks>
    /// <returns></returns>
    Task<ClientCredentialsTokenResponse> RequestToken(ClientCredentialsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Refresh an already received token via Authorization Code Auth
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeRefreshResponse> RequestToken(AuthorizationCodeRefreshRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Reequest an initial token via Authorization Code Auth
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeTokenResponse> RequestToken(AuthorizationCodeTokenRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Swaps out a received code with a access token using a remote server
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeTokenResponse> RequestToken(TokenSwapTokenRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Gets a refreshed access token using an already received refresh token using a remote server
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/
    /// </remarks>
    /// <returns></returns>
    Task<AuthorizationCodeRefreshResponse> RequestToken(TokenSwapRefreshRequest request, CancellationToken cancel = default);
  }
}
