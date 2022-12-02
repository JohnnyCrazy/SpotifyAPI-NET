using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more artists from the Spotify catalog.
  /// </summary>
  public interface IArtistsClient
  {
    /// <summary>
    /// Get Spotify catalog information for several artists based on their Spotify IDs.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-artists
    /// </remarks>
    /// <param name="request">The request-model which contains required and optional parameters</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <returns></returns>
    Task<ArtistsResponse> GetSeveral(ArtistsRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single artist identified by their unique Spotify ID.
    /// </summary>
    /// <param name="artistId">The Spotify ID of the artist.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artist
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullArtist> Get(string artistId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single artist identified by their unique Spotify ID.
    /// </summary>
    /// <param name="artistId">The Spotify ID of the artist.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artist
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullArtist> Get(string artistId, ArtistRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an artist’s albums.
    /// Optional parameters can be specified in the query string to filter and sort the response.
    /// </summary>
    /// <param name="artistId">The Spotify ID for the artist.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artists-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleAlbum>> GetAlbums(string artistId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about an artist’s albums.
    /// Optional parameters can be specified in the query string to filter and sort the response.
    /// </summary>
    /// <param name="artistId">The Spotify ID for the artist.</param>
    /// <param name="request">The request-model which contains required and optional parameters</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artists-albums
    /// </remarks>
    /// <returns></returns>
    Task<Paging<SimpleAlbum>> GetAlbums(string artistId, ArtistsAlbumsRequest request, CancellationToken cancel = default);


    /// <summary>
    /// Get Spotify catalog information about an artist’s top tracks by country.
    /// </summary>
    /// <param name="artistId">The Spotify ID for the artist</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artists-top-tracks
    /// </remarks>
    /// <returns></returns>
    Task<ArtistsTopTracksResponse> GetTopTracks(string artistId, ArtistsTopTracksRequest request, CancellationToken cancel = default);


    /// <summary>
    /// Get Spotify catalog information about artists similar to a given artist.
    /// Similarity is based on analysis of the Spotify community’s listening history.
    /// </summary>
    /// <param name="artistId">The Spotify ID for the artist</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artists-related-artists
    /// </remarks>
    /// <returns></returns>
    Task<ArtistsRelatedArtistsResponse> GetRelatedArtists(string artistId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information about artists similar to a given artist.
    /// Similarity is based on analysis of the Spotify community’s listening history.
    /// </summary>
    /// <param name="artistId">The Spotify ID for the artist</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artists-related-artists
    /// </remarks>
    /// <returns></returns>
    Task<ArtistsRelatedArtistsResponse> GetRelatedArtists(string artistId, ArtistsRelatedArtistsRequest request, CancellationToken cancel = default);
  }
}
