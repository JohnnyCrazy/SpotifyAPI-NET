using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for getting playlists and new album releases featured on Spotify’s Browse tab.
  /// </summary>
  public interface IBrowseClient
  {
    /// <summary>
    /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-categories
    /// </remarks>
    /// <returns></returns>
    Task<CategoriesResponse> GetCategories();

    /// <summary>
    /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-categories
    /// </remarks>
    /// <returns></returns>
    Task<CategoriesResponse> GetCategories(CategoriesRequest request);

    /// <summary>
    /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-category
    /// </remarks>
    /// <returns></returns>
    Task<Category> GetCategory(string categoryId);

    /// <summary>
    /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-category
    /// </remarks>
    /// <returns></returns>
    Task<Category> GetCategory(string categoryId, CategoryRequest request);

    /// <summary>
    /// Get a list of Spotify playlists tagged with a particular category.
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-categories-playlists
    /// </remarks>
    /// <returns></returns>
    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId);

    /// <summary>
    /// Get a list of Spotify playlists tagged with a particular category.
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-categories-playlists
    /// </remarks>
    /// <returns></returns>
    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoriesPlaylistsRequest request);

    /// <summary>
    /// Recommendations are generated based on the available information for a given seed entity and matched against
    /// similar artists and tracks. If there is sufficient information about the provided seeds,
    /// a list of tracks will be returned together with pool size details.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recommendations
    /// </remarks>
    /// <returns></returns>
    Task<RecommendationsResponse> GetRecommendations(RecommendationsRequest request);

    /// <summary>
    /// Retrieve a list of available genres seed parameter values for recommendations.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recommendation-genres
    /// </remarks>
    /// <returns></returns>
    Task<RecommendationGenresResponse> GetRecommendationGenres();

    /// <summary>
    /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-new-releases
    /// </remarks>
    /// <returns></returns>
    Task<NewReleasesResponse> GetNewReleases();

    /// <summary>
    /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-new-releases
    /// </remarks>
    /// <returns></returns>
    Task<NewReleasesResponse> GetNewReleases(NewReleasesRequest request);

    /// <summary>
    /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s ‘Browse’ tab).
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-featured-playlists
    /// </remarks>
    /// <returns></returns>
    Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists();

    /// <summary>
    /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s ‘Browse’ tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-featured-playlists
    /// </remarks>
    /// <returns></returns>
    Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(FeaturedPlaylistsRequest request);
  }
}
