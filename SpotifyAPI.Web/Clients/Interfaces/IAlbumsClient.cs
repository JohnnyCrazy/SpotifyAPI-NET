using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IAlbumsClient
  {
    Task<AlbumsResponse> GetSeveral(AlbumsRequest request);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAlbum> Get(string albumId);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAlbum> Get(string albumId, AlbumRequest request);

    Task<Paging<SimpleTrack>> GetTracks(string albumId);
    Task<Paging<SimpleTrack>> GetTracks(string albumId, AlbumTracksRequest request);
  }
}
