namespace SpotifyAPI.Web
{
  public class Section
  {
    public float Start { get; private set; }
    public float Duration { get; private set; }
    public float Confidence { get; private set; }
    public float Loudness { get; private set; }
    public float Tempo { get; private set; }
    public float TempoConfidence { get; private set; }
    public int Key { get; private set; }
    public float KeyConfidence { get; private set; }
    public int Mode { get; private set; }
    public float ModeConfidence { get; private set; }
    public int TimeSignature { get; private set; }
    public float TimeSignatureConfidence { get; private set; }
  }
}
