using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more albums from the Spotify catalog.
  /// </summary>
  public interface IAlbumsClient
  {
    /// <summary>
    /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-albums
    /// </remarks>
    /// <returns></returns>
    Task<AlbumsResponse> GetSeveral(AlbumsRequest request);

    /// <summary>
    /// Get Spotify catalog information for a single album.
    /// </summary>
    /// <param name="albumId">The Spotify ID of the album.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-album
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAlbum> Get(string albumId);

    /// <summary>
    /// Get Spotify catalog information for a single album.
    /// </summary>
    /// <param name="albumId">The Spotify ID of the album.</param>
    /// <param name="request">The request-model which contains required and optional parameters</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-album
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullAlbum> Get(string albumId, AlbumRequest request);

    /// <summary>
    /// Get Spotify catalog information about an album’s tracks.
    /// Optional parameters can be used to limit the number of tracks returned.
    /// </summary>
    /// <param name="albumId">The Spotify ID of the album.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-albums-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleTrack>> GetTracks(string albumId);

    /// <summary>
    /// Get Spotify catalog information about an album’s tracks.
    /// Optional parameters can be used to limit the number of tracks returned.
    /// </summary>
    /// <param name="albumId">The Spotify ID of the album.</param>
    /// <param name="request">The request-model which contains required and optional parameters</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-albums-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleTrack>> GetTracks(string albumId, AlbumTracksRequest request);
  }
}
