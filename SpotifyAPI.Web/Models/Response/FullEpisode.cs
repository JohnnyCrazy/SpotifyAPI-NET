using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class FullEpisode : IPlayableItem
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

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; set; }
    public string Uri { get; set; }
  }
}
