using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface ITracksClient
  {
    Task<TracksResponse> GetSeveral(TracksRequest request);

    Task<TrackAudioAnalysis> GetAudioAnalysis(string trackId);
    Task<TrackAudioFeatures> GetAudioFeatures(string trackId);


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullTrack> Get(string trackId);
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<FullTrack> Get(string trackId, TrackRequest request);

    Task<TracksAudioFeaturesResponse> GetSeveralAudioFeatures(TracksAudioFeaturesRequest request);
  }
}
