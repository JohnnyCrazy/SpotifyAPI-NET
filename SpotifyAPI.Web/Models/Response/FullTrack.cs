using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class FullTrack : IPlayableItem
  {
    public SimpleAlbum Album { get; private set; }
    public List<SimpleArtist> Artists { get; private set; }
    public List<string> AvailableMarkets { get; private set; }
    public int DiscNumber { get; private set; }
    public int DurationMs { get; private set; }
    public bool Explicit { get; private set; }
    public Dictionary<string, string> ExternalIds { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public bool IsPlayable { get; private set; }
    public LinkedTrack LinkedFrom { get; private set; }
    public Dictionary<string, string> Restrictions { get; private set; }
    public string Name { get; private set; }
    public int Popularity { get; private set; }
    public string PreviewUrl { get; private set; }
    public int TrackNumber { get; private set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; private set; }
    public string Uri { get; private set; }
    public bool IsLocal { get; private set; }
  }
}
