using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class EpisodesClient : APIClient, IEpisodesClient
  {
    public EpisodesClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullEpisode> Get(string episodeId)
    {
      Ensure.ArgumentNotNullOrEmptyString(episodeId, nameof(episodeId));

      return API.Get<FullEpisode>(URLs.Episode(episodeId));
    }

    public Task<FullEpisode> Get(string episodeId, EpisodeRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(episodeId, nameof(episodeId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullEpisode>(URLs.Episode(episodeId), request.BuildQueryParams());
    }

    public Task<EpisodesResponse> GetSeveral(EpisodesRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<EpisodesResponse>(URLs.Episodes(), request.BuildQueryParams());
    }
  }
}
