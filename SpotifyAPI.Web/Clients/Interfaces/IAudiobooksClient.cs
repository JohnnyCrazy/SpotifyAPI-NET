using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more audiobooks from the Spotify catalog.
  /// </summary>
  public interface IAudiobooksClient
  {
    /// <summary>
    /// Get Spotify catalog information for a single audiobook. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="audiobookId">The Spotify ID for the audiobook.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-multiple-audiobooks
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAudiobook> Get(string audiobookId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single audiobook. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="audiobookId">The Spotify ID for the audiobook.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-multiple-audiobooks
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAudiobook> Get(string audiobookId, AudiobookRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for several audiobooks identified by their Spotify IDs. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-multiple-audiobooks
    /// </remarks>
    /// <returns></returns>
    [System.Obsolete("This endpoint (GET /audiobooks) has been removed.")]
    Task<AudiobooksResponse> GetSeveral(AudiobooksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an audiobook's chapters. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="audiobookId">The Spotify ID for the audiobook.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-audiobook-chapters
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleAudiobookChapter>> GetChapters(string audiobookId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an audiobook's chapters. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="audiobookId">The Spotify ID for the audiobook.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-audiobook-chapters
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleAudiobookChapter>> GetChapters(string audiobookId, AudiobookChaptersRequest request, CancellationToken cancel = default);
  }
}
