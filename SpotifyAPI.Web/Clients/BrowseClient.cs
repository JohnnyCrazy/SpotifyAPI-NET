using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class BrowseClient : APIClient, IBrowseClient
  {
    public BrowseClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<CategoriesResponse> GetCategories(CancellationToken cancel = default)
    {
      return API.Get<CategoriesResponse>(URLs.Categories(), cancel);
    }

    public Task<CategoriesResponse> GetCategories(CategoriesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CategoriesResponse>(URLs.Categories(), request.BuildQueryParams(), cancel);
    }

    public Task<Category> GetCategory(string categoryId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(categoryId, nameof(categoryId));

      return API.Get<Category>(URLs.Category(categoryId), cancel);
    }

    public Task<Category> GetCategory(string categoryId, CategoryRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(categoryId, nameof(categoryId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Category>(URLs.Category(categoryId), request.BuildQueryParams(), cancel);
    }

    public Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(categoryId, nameof(categoryId));

      return API.Get<CategoryPlaylistsResponse>(URLs.CategoryPlaylists(categoryId), cancel);
    }

    public Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoriesPlaylistsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(categoryId, nameof(categoryId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CategoryPlaylistsResponse>(URLs.CategoryPlaylists(categoryId), request.BuildQueryParams(), cancel);
    }

    public Task<RecommendationsResponse> GetRecommendations(RecommendationsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<RecommendationsResponse>(URLs.Recommendations(), request.BuildQueryParams(), cancel);
    }

    public Task<RecommendationGenresResponse> GetRecommendationGenres(CancellationToken cancel = default)
    {
      return API.Get<RecommendationGenresResponse>(URLs.RecommendationGenres(), cancel);
    }

    public Task<NewReleasesResponse> GetNewReleases(CancellationToken cancel = default)
    {
      return API.Get<NewReleasesResponse>(URLs.NewReleases(), cancel);
    }

    public Task<NewReleasesResponse> GetNewReleases(NewReleasesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<NewReleasesResponse>(URLs.NewReleases(), request.BuildQueryParams(), cancel);
    }

    public Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(CancellationToken cancel = default)
    {
      return API.Get<FeaturedPlaylistsResponse>(URLs.FeaturedPlaylists(), cancel);
    }

    public Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(FeaturedPlaylistsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FeaturedPlaylistsResponse>(URLs.FeaturedPlaylists(), request.BuildQueryParams(), cancel);
    }
  }
}
