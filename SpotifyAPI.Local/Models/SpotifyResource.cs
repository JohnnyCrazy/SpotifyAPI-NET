using Newtonsoft.Json;
using System;

namespace SpotifyAPI.Local.Models
{
    public class SpotifyResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("location")]
        public TrackResourceLocation Location { get; set; }

        public SpotifyUri ParseUri()
        {
            return SpotifyUri.Parse(Uri);
        }
    }
}