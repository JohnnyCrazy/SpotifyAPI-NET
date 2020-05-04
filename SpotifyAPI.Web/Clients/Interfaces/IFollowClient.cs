using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IFollowClient
  {
    Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request);

    Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request);

    Task<bool> Follow(FollowRequest request);

    Task<bool> FollowPlaylist(string playlistId);
    Task<bool> FollowPlaylist(string playlistId, FollowPlaylistRequest request);

    Task<FollowedArtistsResponse> OfCurrentUser();
    Task<FollowedArtistsResponse> OfCurrentUser(FollowOfCurrentUserRequest request);

    Task<bool> Unfollow(UnfollowRequest request);

    Task<bool> UnfollowPlaylist(string playlistId);
  }
}
