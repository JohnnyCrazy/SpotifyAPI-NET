using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// Endpoints for retrieving information about one or more tracks from the Spotify catalog.
  /// </summary>
  public interface ITracksClient
  {
    /// <summary>
    /// Get Spotify catalog information for multiple tracks based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-several-tracks
    /// </remarks>
    /// <returns></returns>
    Task<TracksResponse> GetSeveral(TracksRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get a detailed audio analysis for a single track identified by its unique Spotify ID.
    /// </summary>
    /// <param name="trackId">The Spotify ID for the track.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-audio-analysis
    /// </remarks>
    /// <returns></returns>
    Task<TrackAudioAnalysis> GetAudioAnalysis(string trackId, CancellationToken cancel = default);

    /// <summary>
    /// Get audio feature information for a single track identified by its unique Spotify ID.
    /// </summary>
    /// <param name="trackId">The Spotify ID for the track.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-audio-features
    /// </remarks>
    /// <returns></returns>
    Task<TrackAudioFeatures> GetAudioFeatures(string trackId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single track identified by its unique Spotify ID.
    /// </summary>
    /// <param name="trackId">The Spotify ID for the track.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-track
    /// </remarks>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullTrack> Get(string trackId, CancellationToken cancel = default);

    /// <summary>
    /// Get Spotify catalog information for a single track identified by its unique Spotify ID.
    /// </summary>
    /// <param name="trackId">The Spotify ID for the track.</param>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullTrack> Get(string trackId, TrackRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Get audio features for multiple tracks based on their Spotify IDs.
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-several-audio-features
    /// </remarks>
    /// <returns></returns>
    Task<TracksAudioFeaturesResponse> GetSeveralAudioFeatures(TracksAudioFeaturesRequest request, CancellationToken cancel = default);

    /// <summary>
    ///  
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    Task<TrackRecommendationResponse> GetRecommendationTracks(TrackRecommendationsRequest request, CancellationToken cancel = default);
  }
}
