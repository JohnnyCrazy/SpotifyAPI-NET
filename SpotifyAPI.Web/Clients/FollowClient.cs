using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class FollowClient : APIClient, IFollowClient
  {
    public FollowClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<List<bool>> CheckCurrentUser(FollowCheckCurrentUserRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.CurrentUserFollowerContains(), request.BuildQueryParams(), cancel);
    }

    public Task<List<bool>> CheckPlaylist(string playlistId, FollowCheckPlaylistRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(URLs.PlaylistFollowersContains(playlistId), request.BuildQueryParams(), cancel);
    }

    public async Task<bool> Follow(FollowRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Put(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> FollowPlaylist(string playlistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      var statusCode = await API
        .Put(URLs.PlaylistFollowers(playlistId), null, null, cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

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

    public async Task<bool> Unfollow(UnfollowRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API
        .Delete(URLs.CurrentUserFollower(), request.BuildQueryParams(), request.BuildBodyParams(), cancel)
        .ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

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
