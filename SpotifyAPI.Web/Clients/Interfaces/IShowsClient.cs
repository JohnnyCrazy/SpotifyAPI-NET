using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IShowsClient
  {
    /// <summary>
    /// Get Spotify catalog information for a single show identified by its unique Spotify ID.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-show
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId);

    /// <summary>
    /// Get Spotify catalog information for a single show identified by its unique Spotify ID.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-show
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId, ShowRequest request);

    /// <summary>
    /// Get Spotify catalog information for several shows based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-shows
    /// </remarks>
    /// <returns></returns>
    Task<ShowsResponse> GetSeveral(ShowsRequest request);

    /// <summary>
    /// Get Spotify catalog information about an show’s episodes.
    /// Optional parameters can be used to limit the number of episodes returned.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-shows-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId);

    /// <summary>
    /// Get Spotify catalog information about an show’s episodes.
    /// Optional parameters can be used to limit the number of episodes returned.
    /// </summary>
    /// <param name="showId">The Spotify ID for the show.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-shows-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request);
  }
}
