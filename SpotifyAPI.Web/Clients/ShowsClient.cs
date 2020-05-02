using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class ShowsClient : APIClient, IShowsClient
  {
    public ShowsClient(IAPIConnector connector) : base(connector) { }

    public Task<FullShow> Get(string showId)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));

      return API.Get<FullShow>(URLs.Show(showId));
    }

    public Task<FullShow> Get(string showId, ShowRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullShow>(URLs.Show(showId), request.BuildQueryParams());
    }

    public Task<ShowsResponse> GetSeveral(ShowsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<ShowsResponse>(URLs.Shows(), request.BuildQueryParams());
    }

    public Task<Paging<SimpleEpisode>> GetEpisodes(string showId)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));

      return API.Get<Paging<SimpleEpisode>>(URLs.ShowEpisodes(showId));
    }

    public Task<Paging<SimpleEpisode>> GetEpisodes(string showId, ShowEpisodesRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(showId, nameof(showId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleEpisode>>(URLs.ShowEpisodes(showId), request.BuildQueryParams());
    }
  }
}
