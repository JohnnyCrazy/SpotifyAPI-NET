using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IFollowClient
  {
    /// <summary>
    /// Check to see if the current user is following one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-current-user-follows
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request);

    /// <summary>
    /// Check to see if one or more Spotify users are following a specified playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID of the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-if-user-follows-playlist
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request);

    /// <summary>
    /// Add the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-artists-users
    /// </remarks>
    /// <returns></returns>
    Task<bool> Follow(FollowRequest request);

    /// <summary>
    /// Add the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">
    /// The Spotify ID of the playlist.
    /// Any playlist can be followed, regardless of its public/private status,
    /// as long as you know its playlist ID.
    /// </param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-playlist
    /// </remarks>
    /// <returns></returns>
    Task<bool> FollowPlaylist(string playlistId);

    /// <summary>
    /// Add the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">
    /// The Spotify ID of the playlist.
    /// Any playlist can be followed, regardless of its public/private status,
    /// as long as you know its playlist ID.
    /// </param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-follow-playlist
    /// </remarks>
    /// <returns></returns>
    Task<bool> FollowPlaylist(string playlistId, FollowPlaylistRequest request);

    /// <summary>
    /// Get the current user’s followed artists.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-followed
    /// </remarks>
    /// <returns></returns>
    Task<FollowedArtistsResponse> OfCurrentUser();

    /// <summary>
    /// Get the current user’s followed artists.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-followed
    /// </remarks>
    /// <returns></returns>
    Task<FollowedArtistsResponse> OfCurrentUser(FollowOfCurrentUserRequest request);

    /// <summary>
    /// Remove the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-unfollow-artists-users
    /// </remarks>
    /// <returns></returns>
    Task<bool> Unfollow(UnfollowRequest request);

    /// <summary>
    /// Remove the current user as a follower of a playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
    /// <returns></returns>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-unfollow-playlist
    /// </remarks>
    Task<bool> UnfollowPlaylist(string playlistId);
  }
}
