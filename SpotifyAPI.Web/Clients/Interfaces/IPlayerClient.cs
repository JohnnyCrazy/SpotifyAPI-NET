using System.Net;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPlayerClient
  {
    /// <summary>
    /// Skips to next track in the user’s queue.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-next-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipNext();

    /// <summary>
    /// Skips to next track in the user’s queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-next-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipNext(PlayerSkipNextRequest request);

    /// <summary>
    /// Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-set-repeat-mode-on-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetRepeat(PlayerSetRepeatRequest request);

    /// <summary>
    /// Transfer playback to a new device and determine if it should start playing.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-transfer-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> TransferPlayback(PlayerTransferPlaybackRequest request);

    /// <summary>
    /// Get the object currently being played on the user’s Spotify account.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-the-users-currently-playing-track
    /// </remarks>
    /// <returns></returns>
    Task<CurrentlyPlaying> GetCurrentlyPlaying(PlayerCurrentlyPlayingRequest request);

    /// <summary>
    /// Get information about the user’s current playback state, including track or episode, progress, and active device.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-information-about-the-users-current-playback
    /// </remarks>
    /// <returns></returns>
    Task<CurrentlyPlayingContext> GetCurrentPlayback();

    /// <summary>
    /// Get information about the user’s current playback state, including track or episode, progress, and active device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-information-about-the-users-current-playback
    /// </remarks>
    /// <returns></returns>
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
