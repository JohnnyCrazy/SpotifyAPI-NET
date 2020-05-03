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

    public Task<Paging<PlaylistTrack<IPlaylistItem>>> GetItems(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      return API.Get<Paging<PlaylistTrack<IPlaylistItem>>>(URLs.PlaylistTracks(playlistId));
    }

    public Task<Paging<PlaylistTrack<IPlaylistItem>>> GetItems(string playlistId, PlaylistGetItemsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<PlaylistTrack<IPlaylistItem>>>(URLs.PlaylistTracks(playlistId), request.BuildQueryParams());
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

      var response = await API.PutRaw(URLs.PlaylistImages(playlistId), null, base64Jpg);
      return response == HttpStatusCode.Accepted;
    }

    public Task<List<Image>> GetCovers(string playlistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(playlistId, nameof(playlistId));

      return API.Get<List<Image>>(URLs.PlaylistImages(playlistId));
    }
  }
}
