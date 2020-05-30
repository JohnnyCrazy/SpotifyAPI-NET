using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IPlaylistsClient
  {
    /// <summary>
    /// Remove one or more items from a user’s playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-remove-tracks-playlist
    /// </remarks>
    /// <returns></returns>
    Task<SnapshotResponse> RemoveItems(string playlistId, PlaylistRemoveItemsRequest request);

    /// <summary>
    /// Add one or more items to a user’s playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-add-tracks-to-playlist
    /// </remarks>
    /// <returns></returns>
    Task<SnapshotResponse> AddItems(string playlistId, PlaylistAddItemsRequest request);

    /// <summary>
    /// Get full details of the items of a playlist owned by a Spotify user.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-playlists-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId);

    /// <summary>
    /// Get full details of the items of a playlist owned by a Spotify user.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-playlists-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<PlaylistTrack<IPlayableItem>>> GetItems(string playlistId, PlaylistGetItemsRequest request);

    /// <summary>
    /// Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)
    /// </summary>
    /// <param name="userId">The user’s Spotify user ID.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-create-playlist
    /// </remarks>
    /// <returns></returns>
    Task<FullPlaylist> Create(string userId, PlaylistCreateRequest request);

    /// <summary>
    /// Replace the image used to represent a specific playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="base64JpgData">Base64 encoded JPEG image data, maximum payload size is 256 KB.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-upload-custom-playlist-cover
    /// </remarks>
    /// <returns></returns>
    Task<bool> UploadCover(string playlistId, string base64JpgData);

    /// <summary>
    /// Get the current image associated with a specific playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-playlist-cover
    /// </remarks>
    /// <returns></returns>
    Task<List<Image>> GetCovers(string playlistId);

    /// <summary>
    /// Get a list of the playlists owned or followed by a Spotify user.
    /// </summary>
    /// <param name="userId">The user’s Spotify user ID.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-list-users-playlists
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimplePlaylist>> GetUsers(string userId);

    /// <summary>
    /// Get a list of the playlists owned or followed by a Spotify user.
    /// </summary>
    /// <param name="userId">The user’s Spotify user ID.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-list-users-playlists
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimplePlaylist>> GetUsers(string userId, PlaylistGetUsersRequest request);

    /// <summary>
    /// Get a playlist owned by a Spotify user.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-playlist
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullPlaylist> Get(string playlistId);

    /// <summary>
    /// Get a playlist owned by a Spotify user.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-playlist
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullPlaylist> Get(string playlistId, PlaylistGetRequest request);

    /// <summary>
    /// Replace all the items in a playlist, overwriting its existing items.
    /// This powerful request can be useful for replacing items, re-ordering existing items, or clearing the playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-replace-playlists-tracks
    /// </remarks>
    /// <returns></returns>
    Task<bool> ReplaceItems(string playlistId, PlaylistReplaceItemsRequest request);

    /// <summary>
    /// Get a list of the playlists owned or followed by the current Spotify user.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-list-of-current-users-playlists
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimplePlaylist>> CurrentUsers();

    /// <summary>
    /// Get a list of the playlists owned or followed by the current Spotify user.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-a-list-of-current-users-playlists
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimplePlaylist>> CurrentUsers(PlaylistCurrentUsersRequest request);

    /// <summary>
    /// Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-change-playlist-details
    /// </remarks>
    /// <returns></returns>
    Task<bool> ChangeDetails(string playlistId, PlaylistChangeDetailsRequest request);

    /// <summary>
    /// Reorder an item or a group of items in a playlist.
    /// </summary>
    /// <param name="playlistId">The Spotify ID for the playlist.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-reorder-playlists-tracks
    /// </remarks>
    /// <returns></returns>
    Task<SnapshotResponse> ReorderItems(string playlistId, PlaylistReorderItemsRequest request);
  }
}
