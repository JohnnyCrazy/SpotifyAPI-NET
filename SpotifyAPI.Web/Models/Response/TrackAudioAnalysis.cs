using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TrackAudioAnalysis
  {
    public List<TimeInterval> Bars { get; private set; }
    public List<TimeInterval> Beats { get; private set; }
    public List<Section> Sections { get; private set; }
    public List<Segment> Segments { get; private set; }
    public List<TimeInterval> Tatums { get; private set; }
  }
}
