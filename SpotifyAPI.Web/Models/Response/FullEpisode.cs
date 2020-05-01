using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class FullEpisode : IPlaylistElement
  {
    public string AudioPreviewUrl { get; set; }
    public string Description { get; set; }
    public int DurationMs { get; set; }
    public bool Explicit { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public bool IsExternallyHosted { get; set; }
    public bool IsPlayable { get; set; }
    public List<string> Languages { get; set; }
    public string Name { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public ResumePoint ResumePoint { get; set; }
    public SimpleShow Show { get; set; }
    public PlaylistElementType Type { get; set; }
    public string Uri { get; set; }
  }
}
