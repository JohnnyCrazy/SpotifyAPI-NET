using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for managing the artists, users, and playlists that a Spotify user follows.
  /// </summary>
  public interface IFollowClient
  {
    /// <summary>
    /// Check to see if the current user is following one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-current-user-follows
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check to see if one or more Spotify users are following a specified playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID of the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-if-user-follows-playlist
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Add the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-artists-users
    /// </remarks>
    /// <returns></returns>
    Task<bool> Follow(FollowRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Add the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">
    /// The Spotify ID of the playlist.
    /// Any playlist can be followed, regardless of its public/private status,
    /// as long as you know its playlist ID.
    /// </param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-playlist
    /// </remarks>
    /// <returns></returns>
    Task<bool> FollowPlaylist(string playlistId, CancellationToken cancel = default);

    /// <summary>
    /// Add the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">
    /// The Spotify ID of the playlist.
    /// Any playlist can be followed, regardless of its public/private status,
    /// as long as you know its playlist ID.
    /// </param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-playlist
    /// </remarks>
    /// <returns></returns>
    Task<bool> FollowPlaylist(string playlistId, FollowPlaylistRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get the current user’s followed artists.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-followed
    /// </remarks>
    /// <returns></returns>
    Task<FollowedArtistsResponse> OfCurrentUser(CancellationToken cancel = default);

    /// <summary>
    /// Get the current user’s followed artists.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-followed
    /// </remarks>
    /// <returns></returns>
    Task<FollowedArtistsResponse> OfCurrentUser(FollowOfCurrentUserRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Remove the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-unfollow-artists-users
    /// </remarks>
    /// <returns></returns>
    Task<bool> Unfollow(UnfollowRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Remove the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <returns></returns>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-unfollow-playlist
    /// </remarks>
    Task<bool> UnfollowPlaylist(string playlistId, CancellationToken cancel = default);
  }
}
