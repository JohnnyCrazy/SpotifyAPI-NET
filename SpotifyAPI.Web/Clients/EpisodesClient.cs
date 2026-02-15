using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class EpisodesClient : APIClient, IEpisodesClient
  {
    public EpisodesClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullEpisode> Get(string episodeId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(episodeId, nameof(episodeId));

      return API.Get<FullEpisode>(URLs.Episode(episodeId), cancel);
    }

    public Task<FullEpisode> Get(string episodeId, EpisodeRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(episodeId, nameof(episodeId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullEpisode>(URLs.Episode(episodeId), request.BuildQueryParams(), cancel);
    }

    [System.Obsolete("This endpoint (GET /episodes) has been removed.")]
    public Task<EpisodesResponse> GetSeveral(EpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<EpisodesResponse>(URLs.Episodes(), request.BuildQueryParams(), cancel);
    }
  }
}
