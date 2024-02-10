namespace SpotifyAPI.Web
{
  public class TrackMeta
  {
    public float AnalysisTime { get; set; }
    public string AnalyzerVersion { get; set; } = default!;
    public string DetailedStatus { get; set; } = default!;
    public string InputProcess { get; set; } = default!;
    public string Platform { get; set; } = default!;
    public int StatusCode { get; set; } = default!;
    public long Timestamp { get; set; }
  }
}
