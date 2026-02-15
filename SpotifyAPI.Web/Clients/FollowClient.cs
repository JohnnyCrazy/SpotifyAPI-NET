using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class FollowClient : APIClient, IFollowClient
  {
    public FollowClient(IAPIConnector apiConnector) : base(apiConnector) { }

    [System.Obsolete("This endpoint (GET /me/following/contains) has been removed. Use GET /me/library/contains instead.")]
    public Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.CurrentUserFollowerContains(), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (GET /playlists/{id}/followers/contains) has been removed. Use GET /me/library/contains instead.")]
    public Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.PlaylistFollowersContains(playlistId), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (PUT /me/following) has been removed. Use PUT /me/library instead.")]
    public async Task<bool> Follow(FollowRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    [System.Obsolete("This endpoint (PUT /playlists/{id}/followers) has been removed. Use PUT /me/library instead.")]
    public async Task<bool> FollowPlaylist(string playlistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      var statusCode = await API
        .Put(URLs.PlaylistFollowers(playlistId), null, null, cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    [System.Obsolete("This endpoint (PUT /playlists/{id}/followers) has been removed. Use PUT /me/library instead.")]
    public async Task<bool> FollowPlaylist(string playlistId, FollowPlaylistRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.PlaylistFollowers(playlistId), null, request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public Task<FollowedArtistsResponse> OfCurrentUser(CancellationToken cancel = default)
    {
      var request = new FollowOfCurrentUserRequest();

      return OfCurrentUser(request, cancel);
    }

    public Task<FollowedArtistsResponse> OfCurrentUser(FollowOfCurrentUserRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FollowedArtistsResponse>(URLs.CurrentUserFollower(), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (DELETE /me/following) has been removed. Use DELETE /me/library instead.")]
    public async Task<bool> Unfollow(UnfollowRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Delete(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    [System.Obsolete("This endpoint (DELETE /playlists/{id}/followers) has been removed. Use DELETE /me/library instead.")]
    public async Task<bool> UnfollowPlaylist(string playlistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      var statusCode = await API
        .Delete(URLs.PlaylistFollowers(playlistId), null, null, cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }
  }
}
