using System.Net;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PlayerClient : APIClient, IPlayerClient
  {
    public PlayerClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public async Task<bool> AddToQueue(PlayerAddToQueueRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Post(URLs.PlayerQueue(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public Task<DeviceResponse> GetAvailableDevices()
    {
      return API.Get<DeviceResponse>(URLs.PlayerDevices());
    }

    public Task<CurrentlyPlaying> GetCurrentlyPlaying(PlayerCurrentlyPlayingRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CurrentlyPlaying>(URLs.PlayerCurrentlyPlaying(), request.BuildQueryParams());
    }

    public Task<CurrentlyPlayingContext> GetCurrentPlayback()
    {
      return API.Get<CurrentlyPlayingContext>(URLs.Player());
    }

    public Task<CurrentlyPlayingContext> GetCurrentPlayback(PlayerCurrentPlaybackRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CurrentlyPlayingContext>(URLs.Player(), request.BuildQueryParams());
    }

    public Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed()
    {
      return API.Get<CursorPaging<PlayHistoryItem>>(URLs.PlayerRecentlyPlayed());
    }

    public Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(PlayerRecentlyPlayedRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CursorPaging<PlayHistoryItem>>(URLs.PlayerRecentlyPlayed(), request.BuildQueryParams());
    }

    public async Task<bool> PausePlayback()
    {
      var statusCode = await API.Put(URLs.PlayerPause(), null, null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> PausePlayback(PlayerPausePlaybackRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlayerPause(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> ResumePlayback()
    {
      var statusCode = await API.Put(URLs.PlayerResume(), null, null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> ResumePlayback(PlayerResumePlaybackRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.PlayerResume(), request.BuildQueryParams(), request.BuildBodyParams())
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SeekTo(PlayerSeekToRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlayerSeek(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SetRepeat(PlayerSetRepeatRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlayerRepeat(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SetShuffle(PlayerShuffleRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlayerShuffle(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SetVolume(PlayerVolumeRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlayerVolume(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SkipNext()
    {
      var statusCode = await API.Post(URLs.PlayerNext(), null, null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SkipNext(PlayerSkipNextRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Post(URLs.PlayerNext(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SkipPrevious()
    {
      var statusCode = await API.Post(URLs.PlayerPrevious(), null, null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> SkipPrevious(PlayerSkipPreviousRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Post(URLs.PlayerPrevious(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> TransferPlayback(PlayerTransferPlaybackRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.Player(), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }
  }
}
