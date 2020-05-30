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

    /// <summary>
    /// Seeks to the given position in the user’s currently playing track.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-seek-to-position-in-currently-playing-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SeekTo(PlayerSeekToRequest request);

    /// <summary>
    /// Skips to previous track in the user’s queue.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-previous-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipPrevious();

    /// <summary>
    /// Skips to previous track in the user’s queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-previous-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipPrevious(PlayerSkipPreviousRequest request);

    /// <summary>
    /// Start a new context or resume current playback on the user’s active device.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-start-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> ResumePlayback();

    /// <summary>
    /// Start a new context or resume current playback on the user’s active device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-start-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> ResumePlayback(PlayerResumePlaybackRequest request);

    /// <summary>
    /// Pause playback on the user’s account.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-pause-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> PausePlayback();

    /// <summary>
    /// Pause playback on the user’s account.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-pause-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> PausePlayback(PlayerPausePlaybackRequest request);

    /// <summary>
    /// Set the volume for the user’s current playback device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-set-volume-for-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetVolume(PlayerVolumeRequest request);

    /// <summary>
    /// Get tracks from the current user’s recently played tracks. Note: Currently doesn’t support podcast episodes.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recently-played
    /// </remarks>
    /// <returns></returns>
    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed();

    /// <summary>
    /// Get tracks from the current user’s recently played tracks. Note: Currently doesn’t support podcast episodes.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recently-played
    /// </remarks>
    /// <returns></returns>
    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(PlayerRecentlyPlayedRequest request);

    /// <summary>
    /// Get information about a user’s available devices.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-users-available-devices
    /// </remarks>
    /// <returns></returns>
    Task<DeviceResponse> GetAvailableDevices();

    /// <summary>
    /// Toggle shuffle on or off for user’s playback.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-toggle-shuffle-for-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetShuffle(PlayerShuffleRequest request);

    /// <summary>
    /// Add an item to the end of the user’s current playback queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-add-to-queue
    /// </remarks>
    /// <returns></returns>
    Task<bool> AddToQueue(PlayerAddToQueueRequest request);
  }
}
