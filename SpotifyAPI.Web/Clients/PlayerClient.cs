using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PlayerClient : APIClient, IPlayerClient
  {
    public PlayerClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public async Task<bool> AddToQueue(PlayerAddToQueueRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Post(URLs.PlayerQueue(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public Task<QueueResponse> GetQueue(CancellationToken cancel = default)
    {
      return API.Get<QueueResponse>(URLs.PlayerQueue(), cancel);
    }

    public Task<DeviceResponse> GetAvailableDevices(CancellationToken cancel = default)
    {
      return API.Get<DeviceResponse>(URLs.PlayerDevices(), cancel);
    }

    public Task<CurrentlyPlaying> GetCurrentlyPlaying(PlayerCurrentlyPlayingRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CurrentlyPlaying>(URLs.PlayerCurrentlyPlaying(), request.BuildQueryParams(), cancel);
    }

    public Task<CurrentlyPlayingContext> GetCurrentPlayback(CancellationToken cancel = default)
    {
      return API.Get<CurrentlyPlayingContext>(URLs.Player(), cancel);
    }

    public Task<CurrentlyPlayingContext> GetCurrentPlayback(PlayerCurrentPlaybackRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CurrentlyPlayingContext>(URLs.Player(), request.BuildQueryParams(), cancel);
    }

    public Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(CancellationToken cancel = default)
    {
      return API.Get<CursorPaging<PlayHistoryItem>>(URLs.PlayerRecentlyPlayed(), cancel);
    }

    public Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(PlayerRecentlyPlayedRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CursorPaging<PlayHistoryItem>>(URLs.PlayerRecentlyPlayed(), request.BuildQueryParams(), cancel);
    }

    public async Task<bool> PausePlayback(CancellationToken cancel = default)
    {
      HttpStatusCode statusCode = await API.Put(URLs.PlayerPause(), null, null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> PausePlayback(PlayerPausePlaybackRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.PlayerPause(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> ResumePlayback(CancellationToken cancel = default)
    {
      HttpStatusCode statusCode = await API.Put(URLs.PlayerResume(), null, null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> ResumePlayback(PlayerResumePlaybackRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API
        .Put(URLs.PlayerResume(), request.BuildQueryParams(), request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SeekTo(PlayerSeekToRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.PlayerSeek(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SetRepeat(PlayerSetRepeatRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.PlayerRepeat(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SetShuffle(PlayerShuffleRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.PlayerShuffle(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SetVolume(PlayerVolumeRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.PlayerVolume(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SkipNext(CancellationToken cancel = default)
    {
      HttpStatusCode statusCode = await API.Post(URLs.PlayerNext(), null, null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SkipNext(PlayerSkipNextRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Post(URLs.PlayerNext(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SkipPrevious(CancellationToken cancel = default)
    {
      HttpStatusCode statusCode = await API.Post(URLs.PlayerPrevious(), null, null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SkipPrevious(PlayerSkipPreviousRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Post(URLs.PlayerPrevious(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> TransferPlayback(PlayerTransferPlaybackRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      HttpStatusCode statusCode = await API.Put(URLs.Player(), null, request.BuildBodyParams(), cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }
  }
}
