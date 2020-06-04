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
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-episode
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId);

    /// <summary>
    /// Get Spotify catalog information for a single episode identified by its unique Spotify ID.
    /// </summary>
    /// <param name="episodeId">The Spotify ID for the episode.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-episode
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId, EpisodeRequest request);

    /// <summary>
    /// Get Spotify catalog information for several episodes based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-episodes
    /// </remarks>
    /// <returns></returns>
    Task<EpisodesResponse> GetSeveral(EpisodesRequest request);
  }
}
