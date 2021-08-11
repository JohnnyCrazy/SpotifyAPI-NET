namespace SpotifyAPI.Web
{
  public class TrackAudio
  {
    public float Duration { get; set; }
    public string SampleMd5 { get; set; } = default!;
    public int OffsetSeconds { get; set; }
    public int WindowSeconds { get; set; }
    public int AnalysisSampleRate { get; set; }
    public int AnalysisChannels { get; set; }
    public float EndOfFadeIn { get; set; }
    public float StartOfFadeOut { get; set; }
    public float Loudness { get; set; }
    public float Tempo { get; set; }
    public float TempConfidence { get; set; }
    public int TimeSignature { get; set; }
    public float TimeSignatureConfidence { get; set; }
    public int Key { get; set; }
    public float KeyConfidence { get; set; }
    public int Mode { get; set; }
    public float ModeConfidence { get; set; }
    public string Codestring { get; set; } = default!;
    public float CodeVersion { get; set; }
    public string Echoprintstring { get; set; } = default!;
    public float EchoprintVersion { get; set; }
    public string Synchstring { get; set; } = default!;
    public float SynchVersion { get; set; }
    public string Rhythmstring { get; set; } = default!;
    public float RhythmVersion { get; set; }
  }
}
