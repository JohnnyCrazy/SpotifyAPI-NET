namespace SpotifyAPI.Web
{
  public class TrackAudioFeatures
  {
    public float Acousticness { get; set; }
    public string AnalysisUrl { get; set; } = default!;
    public float Danceability { get; set; }
    public int DurationMs { get; set; }
    public float Energy { get; set; }
    public string Id { get; set; } = default!;
    public float Instrumentalness { get; set; }
    public int Key { get; set; }
    public float Liveness { get; set; }
    public float Loudness { get; set; }
    public int Mode { get; set; }
    public float Speechiness { get; set; }
    public float Tempo { get; set; }
    public int TimeSignature { get; set; }
    public string TrackHref { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
    public float Valence { get; set; }
  }
}

