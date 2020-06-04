using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Search Endpoints
  /// </summary>
  public interface ISearchClient
  {
    /// <summary>
    /// Get Spotify Catalog information about albums, artists, playlists,
    /// tracks, shows or episodes that match a keyword string.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-search
    /// </remarks>
    /// <returns></returns>
    Task<SearchResponse> Item(SearchRequest request);
  }
}
