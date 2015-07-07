using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Local.Models
{
    public class TrackResourceLocation
    {
        [JsonProperty("og")]
        public String Og { get; set; }
    }
}