using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class FullTrack : IPlayableItem
  {
    public SimpleAlbum Album { get; set; } = default!;
    public List<SimpleArtist> Artists { get; set; } = default!;
    [System.Obsolete("Field 'available_markets' has been removed.")]
    public List<string> AvailableMarkets { get; set; } = default!;
    public int DiscNumber { get; set; }
    [JsonConverter(typeof(DoubleToIntConverter))]
    public int DurationMs { get; set; }
    public bool Explicit { get; set; }
    [System.Obsolete("Field 'external_ids' has been removed.")]
    public Dictionary<string, string> ExternalIds { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public bool IsPlayable { get; set; }
    [System.Obsolete("Field 'linked_from' has been removed.")]
    public LinkedTrack LinkedFrom { get; set; } = default!;
    public Dictionary<string, string> Restrictions { get; set; } = default!;
    public string Name { get; set; } = default!;
    [System.Obsolete("Field 'popularity' has been removed.")]
    public int Popularity { get; set; }
    public string PreviewUrl { get; set; } = default!;
    public int TrackNumber { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; set; }
    public string Uri { get; set; } = default!;
    public bool IsLocal { get; set; }
  }
}

