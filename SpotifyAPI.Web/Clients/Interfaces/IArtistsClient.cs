using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IArtistsClient
  {
    Task<ArtistsResponse> GetSeveral(ArtistsRequest request);

    Task<FullArtist> Get(string artistId);

    Task<Paging<SimpleAlbum>> GetAlbums(string artistId);
    Task<Paging<SimpleAlbum>> GetAlbums(string artistId, ArtistsAlbumsRequest request);

    Task<ArtistsTopTracksResponse> GetTopTracks(string artistId, ArtistsTopTracksRequest request);

    Task<ArtistsRelatedArtistsResponse> GetRelatedArtists(string artistId);
  }
}
