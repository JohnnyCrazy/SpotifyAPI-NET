using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about,
  /// and managing, tracks that the current user has saved in their “Your Music” library.
  /// </summary>
  public interface ILibraryClient
  {
    /// <summary>
    /// Remove one or more albums from the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-albums-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveAlbums(LibraryRemoveAlbumsRequest request);

    /// <summary>
    /// Remove one or more tracks from the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-tracks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveTracks(LibraryRemoveTracksRequest request);

    /// <summary>
    /// Delete one or more shows from current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-shows-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveShows(LibraryRemoveShowsRequest request);

    /// <summary>
    /// Save one or more tracks to the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-tracks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveTracks(LibrarySaveTracksRequest request);

    /// <summary>
    /// Save one or more albums to the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-albums-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveAlbums(LibrarySaveAlbumsRequest request);

    /// <summary>
    /// Save one or more shows to current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-shows-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveShows(LibrarySaveShowsRequest request);

    /// <summary>
    /// Check if one or more tracks is already saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckTracks(LibraryCheckTracksRequest request);

    /// <summary>
    /// Check if one or more albums is already saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckAlbums(LibraryCheckAlbumsRequest request);

    /// <summary>
    /// Check if one or more shows is already saved in the current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckShows(LibraryCheckShowsRequest request);

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedTrack>> GetTracks();

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedTrack>> GetTracks(LibraryTracksRequest request);

    /// <summary>
    /// Get a list of the albums saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedAlbum>> GetAlbums();

    /// <summary>
    /// Get a list of the albums saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedAlbum>> GetAlbums(LibraryAlbumsRequest request);

    /// <summary>
    /// Get a list of shows saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedShow>> GetShows();

    /// <summary>
    /// Get a list of shows saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedShow>> GetShows(LibraryShowsRequest request);
  }
}
