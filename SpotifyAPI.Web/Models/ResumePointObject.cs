using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class ResumePointObject : BasicModel
    {
        [JsonProperty("fully_played")]
        public bool FullyPlayed { get; set; }

        [JsonProperty("resume_position_ms")]
        public int ResumePositionMs { get; set; }
    }
}