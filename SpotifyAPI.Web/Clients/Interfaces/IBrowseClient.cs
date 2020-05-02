using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IBrowseClient
  {
    Task<CategoriesResponse> GetCategories();
    Task<CategoriesResponse> GetCategories(CategoriesRequest request);

    Task<Category> GetCategory(string categoryId);
    Task<Category> GetCategory(string categoryId, CategoryRequest request);

    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId);
    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoriesPlaylistsRequest request);

    Task<RecommendationsResponse> GetRecommendations(RecommendationsRequest request);
    Task<RecommendationGenresResponse> GetRecommendationGenres();

    Task<NewReleasesResponse> GetNewReleases();
    Task<NewReleasesResponse> GetNewReleases(NewReleasesRequest request);
  }
}
