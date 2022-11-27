using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class AlbumsClient : APIClient, IAlbumsClient
  {
    public AlbumsClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullAlbum> Get(string albumId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));

      return API.Get<FullAlbum>(URLs.Album(albumId), cancel);
    }

    public Task<FullAlbum> Get(string albumId, AlbumRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullAlbum>(URLs.Album(albumId), request.BuildQueryParams(), cancel);
    }

    public Task<AlbumsResponse> GetSeveral(AlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<AlbumsResponse>(URLs.Albums(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SimpleTrack>> GetTracks(string albumId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));

      return API.Get<Paging<SimpleTrack>>(URLs.AlbumTracks(albumId), cancel);
    }

    public Task<Paging<SimpleTrack>> GetTracks(string albumId, AlbumTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(albumId, nameof(albumId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleTrack>>(URLs.AlbumTracks(albumId), request.BuildQueryParams(), cancel);
    }
  }
}
