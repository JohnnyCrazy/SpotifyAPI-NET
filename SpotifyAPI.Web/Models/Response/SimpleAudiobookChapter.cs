using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class SimpleAudiobookChapter
  {
    public string? AudioPreviewUrl { get; set; }
    public List<string> AvailableMarkets { get; set; } = default!;
    public int ChapterNumber { get; set; }
    public string Description { get; set; } = default!;
    public string HtmlDescription { get; set; } = default!;
    public int DurationMs { get; set; } = default!;
    public bool Explicit { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public bool IsPlayable { get; set; } = default!;
    public List<string> Languages { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ReleaseDate { get; set; } = default!;
    public string ReleaseDatePrecision { get; set; } = default!;
    public ResumePoint ResumePoint { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
    public Dictionary<string, string> Restrictions { get; set; } = default!;
  }
}

