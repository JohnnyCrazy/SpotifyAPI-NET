using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
  public class SimpleTrack : BasicModel
  {
    [JsonProperty("album")]
    public SimpleAlbum Album { get; set; }

    [JsonProperty("artists")]
    public List<SimpleArtist> Artists { get; set; }

    [JsonProperty("available_markets")]
    public List<string> AvailableMarkets { get; set; }

    [JsonProperty("disc_number")]
    public int DiscNumber { get; set; }

    [JsonProperty("duration_ms")]
    public int DurationMs { get; set; }

    [JsonProperty("explicit")]
    public bool Explicit { get; set; }
       
    [JsonProperty("external_ids")]
    public Dictionary<string, string> ExternIds { get; set; }

    [JsonProperty("external_urls")]
    public Dictionary<string, string> ExternUrls { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("is_playable")]
    public bool IsPlayable { get; set; }

    [JsonProperty("linked_from")]
    public TrackLink LinkedFrom { get; set; }
        
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("popularity")]
    public int Popularity { get; set; }

    [JsonProperty("preview_url")]
    public string PreviewUrl { get; set; }

    [JsonProperty("track_number")]
    public int TrackNumber { get; set; }

    [JsonProperty("restrictions")]
    public Dictionary<string, string> Restrictions { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("uri")]
    public string Uri { get; set; }
  }
}