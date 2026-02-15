using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more chapters from the Spotify catalog.
  /// </summary>
  public interface IChaptersClient
  {
    /// <summary>
    /// Get Spotify catalog information for a single audiobook chapter. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="chapterId">The Spotify ID for the chapter.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-a-chapter
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAudiobookChapter> Get(string chapterId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single audiobook chapter. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="chapterId">The Spotify ID for the chapter.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-a-chapter
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAudiobookChapter> Get(string chapterId, ChapterRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for several audiobook chapters identified by their Spotify IDs. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-several-chapters
    /// </remarks>
    /// <returns></returns>
    [System.Obsolete("This endpoint (GET /chapters) has been removed.")]
    Task<ChaptersResponse> GetSeveral(ChaptersRequest request, CancellationToken cancel = default);
  }
}
