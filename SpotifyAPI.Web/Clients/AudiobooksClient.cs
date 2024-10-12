using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class AudiobooksClient : APIClient, IAudiobooksClient
  {
    public AudiobooksClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullAudiobook> Get(string audiobookId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(audiobookId, nameof(audiobookId));

      return API.Get<FullAudiobook>(URLs.Audiobook(audiobookId), cancel);
    }

    public Task<FullAudiobook> Get(string audiobookId, AudiobookRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(audiobookId, nameof(audiobookId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullAudiobook>(URLs.Audiobook(audiobookId), request.BuildQueryParams(), cancel);
    }

    public Task<AudiobooksResponse> GetSeveral(AudiobooksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<AudiobooksResponse>(URLs.Audiobooks(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SimpleAudiobookChapter>> GetChapters(string audiobookId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(audiobookId, nameof(audiobookId));

      return API.Get<Paging<SimpleAudiobookChapter>>(URLs.AudiobookChapters(audiobookId), cancel);
    }

    public Task<Paging<SimpleAudiobookChapter>> GetChapters(string audiobookId, AudiobookChaptersRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(audiobookId, nameof(audiobookId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleAudiobookChapter>>(URLs.AudiobookChapters(audiobookId), request.BuildQueryParams(), cancel);
    }
  }
}
