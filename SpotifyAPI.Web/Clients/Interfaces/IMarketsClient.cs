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
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#/operations/get-available-markets
    /// </remarks>
    /// <returns></returns>
    Task<AvailableMarketsResponse> AvailableMarkets();
  }
}
