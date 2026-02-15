using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more shows from the Spotify catalog.
  /// </summary>
  public interface IShowsClient
  {
    /// <summary>
    /// Get Spotify catalog information for a single show identified by its unique Spotify ID.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-show
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single show identified by its unique Spotify ID.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-show
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId, ShowRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for several shows based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-shows
    /// </remarks>
    /// <returns></returns>
    [System.Obsolete("This endpoint (GET /shows) has been removed.")]
    Task<ShowsResponse> GetSeveral(ShowsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an show’s episodes.
    /// Optional parameters can be used to limit the number of episodes returned.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-shows-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an show’s episodes.
    /// Optional parameters can be used to limit the number of episodes returned.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-shows-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request, CancellationToken cancel = default);
  }
}
