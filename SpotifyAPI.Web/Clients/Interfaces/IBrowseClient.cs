using System.Threading;
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
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-categories
    /// </remarks>
    /// <returns></returns>
    Task<CategoriesResponse> GetCategories(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-categories
    /// </remarks>
    /// <returns></returns>
    Task<CategoriesResponse> GetCategories(CategoriesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-category
    /// </remarks>
    /// <returns></returns>
    Task<Category> GetCategory(string categoryId, CancellationToken cancel = default);

    /// <summary>
    /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-category
    /// </remarks>
    /// <returns></returns>
    Task<Category> GetCategory(string categoryId, CategoryRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of Spotify playlists tagged with a particular category.
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-categories-playlists
    /// </remarks>
    /// <returns></returns>
    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of Spotify playlists tagged with a particular category.
    /// </summary>
    /// <param name="categoryId">The Spotify category ID for the category.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-categories-playlists
    /// </remarks>
    /// <returns></returns>
    Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoriesPlaylistsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Recommendations are generated based on the available information for a given seed entity and matched against
    /// similar artists and tracks. If there is sufficient information about the provided seeds,
    /// a list of tracks will be returned together with pool size details.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recommendations
    /// </remarks>
    /// <returns></returns>
    Task<RecommendationsResponse> GetRecommendations(RecommendationsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Retrieve a list of available genres seed parameter values for recommendations.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-recommendation-genres
    /// </remarks>
    /// <returns></returns>
    Task<RecommendationGenresResponse> GetRecommendationGenres(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-new-releases
    /// </remarks>
    /// <returns></returns>
    Task<NewReleasesResponse> GetNewReleases(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-new-releases
    /// </remarks>
    /// <returns></returns>
    Task<NewReleasesResponse> GetNewReleases(NewReleasesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s ‘Browse’ tab).
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-featured-playlists
    /// </remarks>
    /// <returns></returns>
    Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s ‘Browse’ tab).
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-featured-playlists
    /// </remarks>
    /// <returns></returns>
    Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(FeaturedPlaylistsRequest request, CancellationToken cancel = default);
  }
}
