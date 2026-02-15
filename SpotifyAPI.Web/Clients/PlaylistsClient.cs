using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PlaylistsClient : APIClient, IPlaylistsClient
  {
    public PlaylistsClient(IAPIConnector connector) : base(connector) { }

    [System.Obsolete("This endpoint (DELETE /playlists/{id}/tracks) has been removed. Use RemovePlaylistItems instead, which uses the new DELETE /playlists/{id}/items endpoint.")]
    public Task<SnapshotResponse> RemoveItems(string playlistId, PlaylistRemoveItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Delete<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams(), cancel);
    }

    [System.Obsolete("This endpoint (POST /playlists/{id}/tracks) has been removed. Use AddPlaylistItems instead, which uses the new POST /playlists/{id}/items endpoint.")]
    public Task<SnapshotResponse> AddItems(string playlistId, PlaylistAddItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Post<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams(), cancel);
    }

    [System.Obsolete("This endpoint (GET /playlists/{id}/tracks) has been removed. Use GetPlaylistItems instead, which uses the new GET /playlists/{id}/items endpoint.")]
    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId, CancellationToken cancel = default)
    {
      var request = new PlaylistGetItemsRequest();

      return GetItems(playlistId, request, cancel);
    }

    [System.Obsolete("This endpoint (GET /playlists/{id}/tracks) has been removed. Use GetPlaylistItems instead, which uses the new GET /playlists/{id}/items endpoint.")]
    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId, PlaylistGetItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<PlaylistTrack<IPlayableItem>>>(URLs.PlaylistTracks(playlistId), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (POST /users/{user_id}/playlists) has been removed. Use POST /me/playlists instead.")]
    public Task<FullPlaylist> Create(string userId, PlaylistCreateRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Post<FullPlaylist>(URLs.UserPlaylists(userId), null, request.BuildBodyParams(), cancel);
    }

    public async Task<bool> UploadCover(string playlistId, string base64JpgData, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNullOrEmptyString(base64JpgData, nameof(base64JpgData));

      var statusCode = await API.PutRaw(URLs.PlaylistImages(playlistId), null, base64JpgData, cancel).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Accepted;
    }

    public Task<List<Image>> GetCovers(string playlistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      return API.Get<List<Image>>(URLs.PlaylistImages(playlistId), cancel);
    }

    [System.Obsolete("This endpoint (GET /users/{id}/playlists) has been removed.")]
    public Task<Paging<FullPlaylist>> GetUsers(string userId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<Paging<FullPlaylist>>(URLs.UserPlaylists(userId), cancel);
    }

    [System.Obsolete("This endpoint (GET /users/{id}/playlists) has been removed.")]
    public Task<Paging<FullPlaylist>> GetUsers(string userId, PlaylistGetUsersRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullPlaylist>>(URLs.UserPlaylists(userId), request.BuildQueryParams(), cancel);
    }

    public Task<FullPlaylist> Get(string playlistId, CancellationToken cancel = default)
    {
      var request = new PlaylistGetRequest(); // We need some defaults

      return Get(playlistId, request, cancel);
    }

    public Task<FullPlaylist> Get(string playlistId, PlaylistGetRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullPlaylist>(URLs.Playlist(playlistId), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (PUT /playlists/{playlist_id}/tracks) has been removed. Use UpdatePlaylistItems instead, which uses the new PUT /playlists/{id}/items endpoint.")]
    public Task<SnapshotResponse> ReplaceItems(string playlistId, PlaylistReplaceItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Put<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams(), cancel);
    }

    public Task<Paging<FullPlaylist>> CurrentUsers(CancellationToken cancel = default)
    {
      return API.Get<Paging<FullPlaylist>>(URLs.CurrentUserPlaylists(), cancel);
    }

    public Task<Paging<FullPlaylist>> CurrentUsers(PlaylistCurrentUsersRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullPlaylist>>(URLs.CurrentUserPlaylists(), request.BuildQueryParams(), cancel);
    }

    public async Task<bool> ChangeDetails(string playlistId, PlaylistChangeDetailsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.Playlist(playlistId), null, request.BuildBodyParams(), cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    [System.Obsolete("This endpoint (PUT /playlists/{playlist_id}/tracks) has been removed. Use UpdatePlaylistItems instead, which uses the new PUT /playlists/{id}/items endpoint.")]
    public Task<SnapshotResponse> ReorderItems(string playlistId, PlaylistReorderItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Put<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams(), cancel);
    }

    public Task<SnapshotResponse> AddPlaylistItems(string playlistId, PlaylistAddItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Post<SnapshotResponse>(URLs.PlaylistItems(playlistId), null, request.BuildBodyParams(), cancel);
    }

    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetPlaylistItems(string playlistId, CancellationToken cancel = default)
    {
      var request = new PlaylistGetItemsRequest();

      return GetPlaylistItems(playlistId, request, cancel);
    }

    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetPlaylistItems(string playlistId, PlaylistGetItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<PlaylistTrack<IPlayableItem>>>(URLs.PlaylistItems(playlistId), request.BuildQueryParams(), cancel);
    }

    public Task<SnapshotResponse> RemovePlaylistItems(string playlistId, PlaylistRemoveItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Delete<SnapshotResponse>(URLs.PlaylistItems(playlistId), null, request.BuildBodyParams(), cancel);
    }

    public Task<SnapshotResponse> UpdatePlaylistItems(string playlistId, PlaylistReorderItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Put<SnapshotResponse>(URLs.PlaylistItems(playlistId), null, request.BuildBodyParams(), cancel);
    }
  }
}
