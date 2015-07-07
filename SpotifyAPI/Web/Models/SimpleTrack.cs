using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SimpleTrack : BasicModel
    {
        [JsonProperty("artist")]
        public SimpleArtist Artist { get; set; }
        [JsonProperty("available_markets")]
        public List<String> AvailableMarkets { get; set; }
        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }
        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }
        [JsonProperty("explicit")]
        public Boolean Explicit { get; set; }
        [JsonProperty("external_urls")]
        public Dictionary<String, String> ExternUrls { get; set; }
        [JsonProperty("href")]
        public String Href { get; set; }
        [JsonProperty("id")]
        public String Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("preview_url")]
        public String PreviewUrl { get; set; }
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("uri")]
        public String Uri { get; set; }
    }
}
