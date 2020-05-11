using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IEpisodesClient
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullEpisode> Get(string episodeId, EpisodeRequest request);

    Task<EpisodesResponse> GetSeveral(EpisodesRequest request);
  }
}
