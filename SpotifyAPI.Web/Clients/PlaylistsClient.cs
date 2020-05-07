using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PlaylistsClient : APIClient, IPlaylistsClient
  {
    public PlaylistsClient(IAPIConnector connector) : base(connector) { }

    public Task<SnapshotResponse> RemoveItems(string playlistId, PlaylistRemoveItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Delete<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams());
    }

    public Task<SnapshotResponse> AddItems(string playlistId, PlaylistAddItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Post<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams());
    }

    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      var request = new PlaylistGetItemsRequest();

      return API.Get<Paging<PlaylistTrack<IPlayableItem>>>(URLs.PlaylistTracks(playlistId), request.BuildQueryParams());
    }

    public Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId, PlaylistGetItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<PlaylistTrack<IPlayableItem>>>(URLs.PlaylistTracks(playlistId), request.BuildQueryParams());
    }

    public Task<FullPlaylist> Create(string userId, PlaylistCreateRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Post<FullPlaylist>(URLs.UserPlaylists(userId), null, request.BuildBodyParams());
    }

    public async Task<bool> UploadCover(string playlistId, string base64Jpg)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNullOrEmptyString(base64Jpg, nameof(base64Jpg));

      var statusCode = await API.PutRaw(URLs.PlaylistImages(playlistId), null, base64Jpg).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Accepted;
    }

    public Task<List<Image>> GetCovers(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      return API.Get<List<Image>>(URLs.PlaylistImages(playlistId));
    }

    public Task<Paging<SimplePlaylist>> GetUsers(string userId)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<Paging<SimplePlaylist>>(URLs.UserPlaylists(userId));
    }

    public Task<Paging<SimplePlaylist>> GetUsers(string userId, PlaylistGetUsersRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimplePlaylist>>(URLs.UserPlaylists(userId), request.BuildQueryParams());
    }

    public Task<FullPlaylist> Get(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      var request = new PlaylistGetRequest(); // We need some defaults

      return API.Get<FullPlaylist>(URLs.Playlist(playlistId), request.BuildQueryParams());
    }

    public Task<FullPlaylist> Get(string playlistId, PlaylistGetRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullPlaylist>(URLs.Playlist(playlistId), request.BuildQueryParams());
    }

    public async Task<bool> ReplaceItems(string playlistId, PlaylistReplaceItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Created;
    }

    public Task<Paging<SimplePlaylist>> CurrentUsers()
    {
      return API.Get<Paging<SimplePlaylist>>(URLs.CurrentUserPlaylists());
    }

    public Task<Paging<SimplePlaylist>> CurrentUsers(PlaylistCurrentUsersRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimplePlaylist>>(URLs.CurrentUserPlaylists(), request.BuildQueryParams());
    }

    public async Task<bool> ChangeDetails(string playlistId, PlaylistChangeDetailsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(URLs.Playlist(playlistId), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public Task<SnapshotResponse> ReorderItems(string playlistId, PlaylistReorderItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Put<SnapshotResponse>(URLs.PlaylistTracks(playlistId), null, request.BuildBodyParams());
    }
  }
}
