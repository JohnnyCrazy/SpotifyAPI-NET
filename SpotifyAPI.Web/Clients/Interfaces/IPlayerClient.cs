using System.Net;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPlayerClient
  {
    Task<bool> SkipNext();
    Task<bool> SkipNext(PlayerSkipNextRequest request);

    Task<bool> SetRepeat(PlayerSetRepeatRequest request);

    Task<bool> TransferPlayback(PlayerTransferPlaybackRequest request);

    Task<CurrentlyPlaying> GetCurrentlyPlaying(PlayerCurrentlyPlayingRequest request);

    Task<CurrentlyPlayingContext> GetCurrentPlayback();
    Task<CurrentlyPlayingContext> GetCurrentPlayback(PlayerCurrentPlaybackRequest request);

    Task<bool> SeekTo(PlayerSeekToRequest request);

    Task<bool> SkipPrevious();
    Task<bool> SkipPrevious(PlayerSkipPreviousRequest request);

    Task<bool> ResumePlayback();
    Task<bool> ResumePlayback(PlayerResumePlaybackRequest request);

    Task<bool> PausePlayback();
    Task<bool> PausePlayback(PlayerPausePlaybackRequest request);

    Task<bool> SetVolume(PlayerVolumeRequest request);

    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed();
    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(PlayerRecentlyPlayedRequest request);

    Task<DeviceResponse> GetAvailableDevices();

    Task<bool> SetShuffle(PlayerShuffleRequest request);

    Task<bool> AddToQueue(PlayerAddToQueueRequest request);
  }
}
