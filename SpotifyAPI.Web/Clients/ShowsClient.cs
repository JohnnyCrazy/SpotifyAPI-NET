using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class ShowsClient : APIClient, IShowsClient
  {
    public ShowsClient(IAPIConnector connector) : base(connector) { }

    public Task<FullShow> Get(string showId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));

      return API.Get<FullShow>(URLs.Show(showId), cancel);
    }

    public Task<FullShow> Get(string showId, ShowRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullShow>(URLs.Show(showId), request.BuildQueryParams(), cancel);
    }

    public Task<ShowsResponse> GetSeveral(ShowsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ShowsResponse>(URLs.Shows(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SimpleEpisode>> GetEpisodes(string showId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));

      return API.Get<Paging<SimpleEpisode>>(URLs.ShowEpisodes(showId), cancel);
    }

    public Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleEpisode>>(URLs.ShowEpisodes(showId), request.BuildQueryParams(), cancel);
    }
  }
}
