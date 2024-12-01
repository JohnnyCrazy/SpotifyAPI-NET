using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Player Endpoints.
  /// These endpoints are in beta.
  /// While we encourage you to build with them, a situation may arise
  /// where we need to disable some or all of the functionality and/or change how
  /// they work without prior notice. Please report any issues via our developer community forum.
  /// </summary>
  public interface IPlayerClient
  {
    /// <summary>
    /// Skips to next track in the user’s queue.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-next-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipNext(CancellationToken cancel = default);

    /// <summary>
    /// Skips to next track in the user’s queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-next-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipNext(PlayerSkipNextRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-set-repeat-mode-on-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetRepeat(PlayerSetRepeatRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Transfer playback to a new device and determine if it should start playing.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-transfer-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> TransferPlayback(PlayerTransferPlaybackRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get the object currently being played on the user’s Spotify account.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-the-users-currently-playing-track
    /// </remarks>
    /// <returns></returns>
    Task<CurrentlyPlaying> GetCurrentlyPlaying(PlayerCurrentlyPlayingRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get information about the user’s current playback state, including track or episode, progress, and active device.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-information-about-the-users-current-playback
    /// </remarks>
    /// <returns></returns>
    Task<CurrentlyPlayingContext> GetCurrentPlayback(CancellationToken cancel = default);

    /// <summary>
    /// Get information about the user’s current playback state, including track or episode, progress, and active device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-information-about-the-users-current-playback
    /// </remarks>
    /// <returns></returns>
    Task<CurrentlyPlayingContext> GetCurrentPlayback(PlayerCurrentPlaybackRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Seeks to the given position in the user’s currently playing track.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-seek-to-position-in-currently-playing-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SeekTo(PlayerSeekToRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Skips to previous track in the user’s queue.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-previous-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipPrevious(CancellationToken cancel = default);

    /// <summary>
    /// Skips to previous track in the user’s queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-skip-users-playback-to-previous-track
    /// </remarks>
    /// <returns></returns>
    Task<bool> SkipPrevious(PlayerSkipPreviousRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Start a new context or resume current playback on the user’s active device.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-start-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> ResumePlayback(CancellationToken cancel = default);

    /// <summary>
    /// Start a new context or resume current playback on the user’s active device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-start-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> ResumePlayback(PlayerResumePlaybackRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Pause playback on the user’s account.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-pause-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> PausePlayback(CancellationToken cancel = default);

    /// <summary>
    /// Pause playback on the user’s account.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-pause-a-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> PausePlayback(PlayerPausePlaybackRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Set the volume for the user’s current playback device.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-set-volume-for-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetVolume(PlayerVolumeRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get tracks from the current user’s recently played tracks. Note: Currently doesn’t support podcast episodes.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recently-played
    /// </remarks>
    /// <returns></returns>
    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(CancellationToken cancel = default);

    /// <summary>
    /// Get tracks from the current user’s recently played tracks. Note: Currently doesn’t support podcast episodes.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recently-played
    /// </remarks>
    /// <returns></returns>
    Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed(PlayerRecentlyPlayedRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get information about a user’s available devices.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-users-available-devices
    /// </remarks>
    /// <returns></returns>
    Task<DeviceResponse> GetAvailableDevices(CancellationToken cancel = default);

    /// <summary>
    /// Toggle shuffle on or off for user’s playback.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-toggle-shuffle-for-users-playback
    /// </remarks>
    /// <returns></returns>
    Task<bool> SetShuffle(PlayerShuffleRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Add an item to the end of the user’s current playback queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-add-to-queue
    /// </remarks>
    /// <returns></returns>
    Task<bool> AddToQueue(PlayerAddToQueueRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get the list of objects that make up the user's queue.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#/operations/get-queue
    /// </remarks>
    /// <returns></returns>
    Task<QueueResponse> GetQueue(CancellationToken cancel = default);

    /// <summary>
    /// Get the list of objects that make up the user's queue.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#/operations/get-queue
    /// </remarks>
    /// <returns></returns>
    Task<QueueResponse> GetQueue(PlayerGetQueueRequest request, CancellationToken cancel = default);
  }
}
