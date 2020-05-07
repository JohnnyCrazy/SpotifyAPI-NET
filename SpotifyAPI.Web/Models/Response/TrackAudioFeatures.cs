namespace SpotifyAPI.Web
{
  public class TrackAudioFeatures
  {
    public float Acousticness { get; private set; }
    public string AnalysisUrl { get; private set; }
    public float Danceability { get; private set; }
    public int DurationMs { get; private set; }
    public float Energy { get; private set; }
    public string Id { get; private set; }
    public float Instrumentalness { get; private set; }
    public int Key { get; private set; }
    public float Liveness { get; private set; }
    public float Loudness { get; private set; }
    public int Mode { get; private set; }
    public float Speechiness { get; private set; }
    public float Tempo { get; private set; }
    public int TimeSignature { get; private set; }
    public string TrackHref { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
    public float Valence { get; private set; }
  }
}
