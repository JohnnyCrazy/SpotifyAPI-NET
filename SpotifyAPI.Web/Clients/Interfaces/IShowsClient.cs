using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IShowsClient
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId);
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullShow> Get(string showId, ShowRequest request);

    Task<ShowsResponse> GetSeveral(ShowsRequest request);

    Task<Paging<SimpleEpisode>> GetEpisodes(string showId);
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request);
  }
}
