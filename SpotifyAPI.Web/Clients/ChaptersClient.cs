using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class ChaptersClient : APIClient, IChaptersClient
  {
    public ChaptersClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullAudiobookChapter> Get(string chapterId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(chapterId, nameof(chapterId));

      return API.Get<FullAudiobookChapter>(URLs.Chapter(chapterId), cancel);
    }

    public Task<FullAudiobookChapter> Get(string chapterId, ChapterRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(chapterId, nameof(chapterId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullAudiobookChapter>(URLs.Chapter(chapterId), request.BuildQueryParams(), cancel);
    }

    public Task<ChaptersResponse> GetSeveral(ChaptersRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ChaptersResponse>(URLs.Chapters(), request.BuildQueryParams(), cancel);
    }
  }
}
