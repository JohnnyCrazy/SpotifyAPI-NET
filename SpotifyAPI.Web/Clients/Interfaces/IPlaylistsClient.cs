using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPlaylistsClient
  {
    Task<SnapshotResponse> RemoveItems(string playlistId, PlaylistRemoveItemsRequest request);
  }
}
