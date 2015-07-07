using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Local.Models
{
    public class SpotifyResource
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("uri")]
        public String Uri { get; set; }
        [JsonProperty("location")]
        public TrackResourceLocation Location { get; set; }
    }
}
