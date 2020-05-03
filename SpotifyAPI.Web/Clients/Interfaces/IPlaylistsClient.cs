using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPlaylistsClient
  {
    Task<SnapshotResponse> RemoveItems(string playlistId, PlaylistRemoveItemsRequest request);

    Task<SnapshotResponse> AddItems(string playlistId, PlaylistAddItemsRequest request);

    Task<Paging<PlaylistTrack<IPlaylistItem>>> GetItems(string playlistId);
    Task<Paging<PlaylistTrack<IPlaylistItem>>> GetItems(string playlistId, PlaylistGetItemsRequest request);

    Task<FullPlaylist> Create(string userId, PlaylistCreateRequest request);

    Task<bool> UploadCover(string playlistId, string base64JpgData);
    Task<List<Image>> GetCovers(string playlistId);

    Task<Paging<SimplePlaylist>> GetUsers(string userId);
    Task<Paging<SimplePlaylist>> GetUsers(string userId, PlaylistGetUsersRequest request);

    Task<FullPlaylist> Get(string playlistId);
    Task<FullPlaylist> Get(string playlistId, PlaylistGetRequest request);

    Task<bool> ReplaceItems(string playlistId, PlaylistReplaceItemsRequest request);

    Task<Paging<SimplePlaylist>> CurrentUsers();
    Task<Paging<SimplePlaylist>> CurrentUsers(PlaylistCurrentUsersRequest request);

    Task<bool> ChangeDetails(string playlistId, PlaylistChangeDetailsRequest request);

    Task<SnapshotResponse> ReorderItems(string playlistId, PlaylistReorderItemsRequest request);
  }
}
