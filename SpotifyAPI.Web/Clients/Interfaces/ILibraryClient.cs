using System.Collections.Generic;
using System.Threading;
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
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-albums-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveAlbums(LibraryRemoveAlbumsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Remove one or more tracks from the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-tracks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveTracks(LibraryRemoveTracksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Delete one or more shows from current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-shows-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveShows(LibraryRemoveShowsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Delete one or more episodes from current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#endpoint-remove-episodes-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveEpisodes(LibraryRemoveEpisodesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Remove one or more audiobooks from the Spotify user's library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/remove-audiobooks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> RemoveAudiobooks(LibraryRemoveAudiobooksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Save one or more tracks to the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-tracks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveTracks(LibrarySaveTracksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Save one or more albums to the current user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-albums-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveAlbums(LibrarySaveAlbumsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Save one or more shows to current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-save-shows-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveShows(LibrarySaveShowsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Save one or more episodes to current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#endpoint-save-episodes-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveEpisodes(LibrarySaveEpisodesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Save one or more audiobooks to the current Spotify user's library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/save-audiobooks-user
    /// </remarks>
    /// <returns></returns>
    Task<bool> SaveAudiobooks(LibrarySaveAudiobooksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check if one or more tracks is already saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckTracks(LibraryCheckTracksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check if one or more albums is already saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckAlbums(LibraryCheckAlbumsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check if one or more shows is already saved in the current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-check-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckShows(LibraryCheckShowsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check if one or more episodes is already saved in the current Spotify user’s library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#endpoint-check-users-saved-episodes
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckEpisodes(LibraryCheckEpisodesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Check if one or more audiobooks are already saved in the current Spotify user's library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/check-users-saved-audiobooks
    /// </remarks>
    /// <returns></returns>
    Task<List<bool>> CheckAudiobooks(LibraryCheckAudiobooksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedTrack>> GetTracks(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedTrack>> GetTracks(LibraryTracksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of the albums saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedAlbum>> GetAlbums(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of the albums saved in the current Spotify user’s ‘Your Music’ library.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedAlbum>> GetAlbums(LibraryAlbumsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of shows saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedShow>> GetShows(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of shows saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-saved-shows
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedShow>> GetShows(LibraryShowsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of episodes saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    ///  https://developer.spotify.com/documentation/web-api/reference/#endpoint-get-users-saved-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedEpisodes>> GetEpisodes(CancellationToken cancel = default);

    /// <summary>
    /// Get a list of episodes saved in the current Spotify user’s library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/#endpoint-get-users-saved-episodes
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SavedEpisodes>> GetEpisodes(LibraryEpisodesRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a list of the audiobooks saved in the current Spotify user's 'Your Music' library.
    /// Optional parameters can be used to limit the number of shows returned.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/get-users-saved-audiobooks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleAudiobook>> GetAudiobooks(LibraryAudiobooksRequest request, CancellationToken cancel = default);
  }
}
