using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Segment
  {
    public float Start { get; private set; }
    public float Duration { get; private set; }
    public float Confidence { get; private set; }
    public float LoudnessStart { get; private set; }
    public float LoudnessMax { get; private set; }
    public float LoudnessMaxTime { get; private set; }
    public float LoudnessEnd { get; private set; }
    public List<float> Pitches { get; private set; }
    public List<float> Timbre { get; private set; }
  }
}
