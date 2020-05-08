using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPersonalizationClient
  {
    Task<Paging<FullTrack>> GetTopTracks();
    Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request);

    Task<Paging<FullArtist>> GetTopArtists();
    Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request);
  }
}
