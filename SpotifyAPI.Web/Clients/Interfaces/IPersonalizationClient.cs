using System.Threading;
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
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullTrack>> GetTopTracks(CancellationToken cancel = default);

    /// <summary>
    /// Get the current user’s top tracks based on calculated affinity.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get the current user’s top artists based on calculated affinity.
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullArtist>> GetTopArtists(CancellationToken cancel = default);

    /// <summary>
    /// Get the current user’s top artists based on calculated affinity.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-top-artists-and-tracks
    /// </remarks>
    /// <returns></returns>
    Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request, CancellationToken cancel = default);
  }
}
