using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class TracksClient : APIClient, ITracksClient
  {
    public TracksClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullTrack> Get(string trackId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<FullTrack>(URLs.Track(trackId), cancel);
    }

    public Task<FullTrack> Get(string trackId, TrackRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullTrack>(URLs.Track(trackId), request.BuildQueryParams(), cancel);
    }

    public Task<TrackAudioAnalysis> GetAudioAnalysis(string trackId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<TrackAudioAnalysis>(URLs.AudioAnalysis(trackId), cancel);
    }

    public Task<TrackAudioFeatures> GetAudioFeatures(string trackId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<TrackAudioFeatures>(URLs.AudioFeatures(trackId), cancel);
    }

    [System.Obsolete("This endpoint (GET /tracks) has been removed.")]
    public Task<TracksResponse> GetSeveral(TracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<TracksResponse>(URLs.Tracks(), request.BuildQueryParams(), cancel);
    }

    public Task<TracksAudioFeaturesResponse> GetSeveralAudioFeatures(TracksAudioFeaturesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<TracksAudioFeaturesResponse>(URLs.AudioFeatures(), request.BuildQueryParams(), cancel);
    }
  }
}
