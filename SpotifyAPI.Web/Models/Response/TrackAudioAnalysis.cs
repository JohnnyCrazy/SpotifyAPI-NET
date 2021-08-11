using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TrackAudioAnalysis
  {
    public List<TimeInterval> Bars { get; set; } = default!;
    public List<TimeInterval> Beats { get; set; } = default!;
    public List<Section> Sections { get; set; } = default!;
    public List<Segment> Segments { get; set; } = default!;
    public List<TimeInterval> Tatums { get; set; } = default!;
    public TrackAudio Track { get; set; } = default!;
    public TrackMeta Meta { get; set; } = default!;
  }
}

