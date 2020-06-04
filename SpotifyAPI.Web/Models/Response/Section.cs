namespace SpotifyAPI.Web
{
  public class Section
  {
    public float Start { get; set; }
    public float Duration { get; set; }
    public float Confidence { get; set; }
    public float Loudness { get; set; }
    public float Tempo { get; set; }
    public float TempoConfidence { get; set; }
    public int Key { get; set; }
    public float KeyConfidence { get; set; }
    public int Mode { get; set; }
    public float ModeConfidence { get; set; }
    public int TimeSignature { get; set; }
    public float TimeSignatureConfidence { get; set; }
  }
}

