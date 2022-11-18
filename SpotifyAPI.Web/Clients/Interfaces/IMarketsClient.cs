using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Markets Endpoints
  /// </summary>
  public interface IMarketsClient
  {
    /// <summary>
    /// Get the list of markets where Spotify is available.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#/operations/get-available-markets
    /// </remarks>
    /// <returns></returns>
    Task<AvailableMarketsResponse> AvailableMarkets(CancellationToken cancel = default);
  }
}
