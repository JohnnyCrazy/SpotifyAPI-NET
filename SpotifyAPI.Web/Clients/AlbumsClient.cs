using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class AlbumsClient : APIClient, IAlbumsClient
  {
    public AlbumsClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullAlbum> Get(string albumId)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));

      return API.Get<FullAlbum>(URLs.Album(albumId));
    }

    public Task<FullAlbum> Get(string albumId, AlbumRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullAlbum>(URLs.Album(albumId), request.BuildQueryParams());
    }

    public Task<AlbumsResponse> GetSeveral(AlbumsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<AlbumsResponse>(URLs.Albums(), request.BuildQueryParams());
    }

    public Task<Paging<SimpleTrack>> GetTracks(string albumId)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));

      return API.Get<Paging<SimpleTrack>>(URLs.AlbumTracks(albumId));
    }

    public Task<Paging<SimpleTrack>> GetTracks(string albumId, AlbumTracksRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleTrack>>(URLs.AlbumTracks(albumId), request.BuildQueryParams());
    }
  }
}
