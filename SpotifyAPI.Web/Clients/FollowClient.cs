using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class FollowClient : APIClient, IFollowClient
  {
    public FollowClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.CurrentUserFollowerContains(), request.BuildQueryParams());
    }

    public Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.PlaylistFollowersContains(playlistId), request.BuildQueryParams());
    }

    public async Task<bool> Follow(FollowRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams())
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public async Task<bool> FollowPlaylist(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      var statusCode = await API
        .Put(URLs.PlaylistFollowers(playlistId), null, null)
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public async Task<bool> FollowPlaylist(string playlistId, FollowPlaylistRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.PlaylistFollowers(playlistId), null, request.BuildBodyParams())
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public Task<FollowedArtistsResponse> OfCurrentUser()
    {
      var request = new FollowOfCurrentUserRequest();

      return OfCurrentUser(request);
    }

    public Task<FollowedArtistsResponse> OfCurrentUser(FollowOfCurrentUserRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FollowedArtistsResponse>(URLs.CurrentUserFollower(), request.BuildQueryParams());
    }

    public async Task<bool> Unfollow(UnfollowRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Delete(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams())
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> UnfollowPlaylist(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      var statusCode = await API
        .Delete(URLs.PlaylistFollowers(playlistId), null, null)
        .ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }
  }
}
