using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class ArtistsClient : APIClient, IArtistsClient
  {
    public ArtistsClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullArtist> Get(string artistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<FullArtist>(URLs.Artist(artistId), cancel);
    }

    public Task<Paging<SimpleAlbum>> GetAlbums(string artistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<Paging<SimpleAlbum>>(URLs.ArtistAlbums(artistId), cancel);
    }

    public Task<Paging<SimpleAlbum>> GetAlbums(string artistId, ArtistsAlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleAlbum>>(URLs.ArtistAlbums(artistId), request.BuildQueryParams(), cancel);
    }

    public Task<ArtistsRelatedArtistsResponse> GetRelatedArtists(string artistId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<ArtistsRelatedArtistsResponse>(URLs.ArtistRelatedArtists(artistId), cancel);
    }

    public Task<ArtistsResponse> GetSeveral(ArtistsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ArtistsResponse>(URLs.Artists(), request.BuildQueryParams(), cancel);
    }

    public Task<ArtistsTopTracksResponse> GetTopTracks(string artistId, ArtistsTopTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ArtistsTopTracksResponse>(URLs.ArtistTopTracks(artistId), request.BuildQueryParams(), cancel);
    }
  }
}
