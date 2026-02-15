using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class SimpleTrack
  {
    public List<SimpleArtist> Artists { get; set; } = default!;
    [System.Obsolete("Field 'available_markets' has been removed.")]
    public List<string> AvailableMarkets { get; set; } = default!;
    public int DiscNumber { get; set; }
    public int DurationMs { get; set; }
    public bool Explicit { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public bool IsPlayable { get; set; }
    [System.Obsolete("Field 'linked_from' has been removed.")]
    public LinkedTrack LinkedFrom { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string PreviewUrl { get; set; } = default!;
    public int TrackNumber { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; set; }
    public string Uri { get; set; } = default!;
  }
}

