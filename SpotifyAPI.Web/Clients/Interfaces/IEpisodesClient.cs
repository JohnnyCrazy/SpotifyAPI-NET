using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more episodes from the Spotify catalog.
  /// </summary>
  public interface IEpisodesClient
  {
    /// <summary>
    /// Get Spotify catalog information for a single episode identified by its unique Spotify ID.
    /// </summary>
    /// <param name="episodeId">The Spotify ID for the episode.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-episode
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single episode identified by its unique Spotify ID.
    /// </summary>
    /// <param name="episodeId">The Spotify ID for the episode.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-episode
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId, EpisodeRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for several episodes based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-episodes
    /// </remarks>
    /// <returns></returns>
    [System.Obsolete("This endpoint (GET /episodes) has been removed.")]
    Task<EpisodesResponse> GetSeveral(EpisodesRequest request, CancellationToken cancel = default);
  }
}
