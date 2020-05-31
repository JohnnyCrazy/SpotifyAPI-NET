using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about the user’s listening habits.
  /// </summary>
  public interface IPersonalizationClient
  {
    /// <summary>
    /// Get the current user’s top tracks based on calculated affinity.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullTrack>> GetTopTracks();

    /// <summary>
    /// Get the current user’s top tracks based on calculated affinity.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request);

    /// <summary>
    /// Get the current user’s top artists based on calculated affinity.
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullArtist>> GetTopArtists();

    /// <summary>
    /// Get the current user’s top artists based on calculated affinity.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request);
  }
}
