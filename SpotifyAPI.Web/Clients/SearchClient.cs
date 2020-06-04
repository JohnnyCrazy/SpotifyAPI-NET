using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class SearchClient : APIClient, ISearchClient
  {
    public SearchClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<SearchResponse> Item(SearchRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<SearchResponse>(URLs.Search(), request.BuildQueryParams());
    }
  }
}
