using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class SimpleTrack
  {
    public List<SimpleArtist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public int DiscNumber { get; set; }
    public int DurationMs { get; set; }
    public bool Explicit { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public bool IsPlayable { get; set; }
    public LinkedTrack LinkedFrom { get; set; }
    public string Name { get; set; }
    public string PreviewUrl { get; set; }
    public int TrackNumber { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; set; }
    public string Uri { get; set; }
  }
}
