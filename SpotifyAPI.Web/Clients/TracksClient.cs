using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class TracksClient : APIClient, ITracksClient
  {
    public TracksClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<FullTrack> Get(string trackId)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<FullTrack>(URLs.Track(trackId));
    }

    public Task<FullTrack> Get(string trackId, TrackRequest request)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<FullTrack>(URLs.Track(trackId), request.BuildQueryParams());
    }

    public Task<TrackAudioAnalysis> GetAudioAnalysis(string trackId)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<TrackAudioAnalysis>(URLs.AudioAnalysis(trackId));
    }

    public Task<TrackAudioFeatures> GetAudioFeatures(string trackId)
    {
      Ensure.ArgumentNotNullOrEmptyString(trackId, nameof(trackId));

      return API.Get<TrackAudioFeatures>(URLs.AudioFeatures(trackId));
    }

    public Task<TracksResponse> GetSeveral(TracksRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<TracksResponse>(URLs.Tracks(), request.BuildQueryParams());
    }

    public Task<TracksAudioFeaturesResponse> GetSeveralAudioFeatures(TracksAudioFeaturesRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<TracksAudioFeaturesResponse>(URLs.AudioFeatures(), request.BuildQueryParams());
    }
  }
}
