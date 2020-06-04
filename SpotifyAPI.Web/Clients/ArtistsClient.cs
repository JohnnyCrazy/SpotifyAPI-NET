using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class ArtistsClient : APIClient, IArtistsClient
  {
    public ArtistsClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullArtist> Get(string artistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<FullArtist>(URLs.Artist(artistId));
    }

    public Task<Paging<SimpleAlbum>> GetAlbums(string artistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<Paging<SimpleAlbum>>(URLs.ArtistAlbums(artistId));
    }

    public Task<Paging<SimpleAlbum>> GetAlbums(string artistId, ArtistsAlbumsRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleAlbum>>(URLs.ArtistAlbums(artistId), request.BuildQueryParams());
    }

    public Task<ArtistsRelatedArtistsResponse> GetRelatedArtists(string artistId)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

      return API.Get<ArtistsRelatedArtistsResponse>(URLs.ArtistRelatedArtists(artistId));
    }

    public Task<ArtistsResponse> GetSeveral(ArtistsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ArtistsResponse>(URLs.Artists(), request.BuildQueryParams());
    }

    public Task<ArtistsTopTracksResponse> GetTopTracks(string artistId, ArtistsTopTracksRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ArtistsTopTracksResponse>(URLs.ArtistTopTracks(artistId), request.BuildQueryParams());
    }
  }
}
