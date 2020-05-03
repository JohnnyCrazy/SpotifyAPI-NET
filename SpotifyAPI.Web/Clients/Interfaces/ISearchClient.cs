using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface ISearchClient
  {
    Task<SearchResponse> Item(SearchRequest request);
  }
}
