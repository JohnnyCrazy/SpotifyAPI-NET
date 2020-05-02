using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IShowsClient
  {
    Task<FullShow> Get(string showId);
    Task<FullShow> Get(string showId, ShowRequest request);

    Task<ShowsResponse> GetSeveral(ShowsRequest request);

    Task<Paging<SimpleEpisode>> GetEpisodes(string showId);
    Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request);
  }
}
