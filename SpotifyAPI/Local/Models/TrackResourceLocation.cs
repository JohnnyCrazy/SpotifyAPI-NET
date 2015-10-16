using Newtonsoft.Json;
using System;

namespace SpotifyAPI.Local.Models
{
    public class TrackResourceLocation
    {
        [JsonProperty("og")]
        public String Og { get; set; }
    }
}