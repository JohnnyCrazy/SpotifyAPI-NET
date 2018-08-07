using Newtonsoft.Json;
using System;

namespace SpotifyAPI.Local.Models
{
    public class TrackResourceLocation
    {
        [JsonProperty("og")]
        public string Og { get; set; }
    }
}