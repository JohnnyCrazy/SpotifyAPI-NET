using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class AnalysisSegment
    {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("loudness_start")]
        public double LoudnessStart { get; set; }

        [JsonProperty("loudness_max_time")]
        public double LoudnessMaxTime { get; set; }

        [JsonProperty("loudness_max")]
        public double LoudnessMax { get; set; }

        [JsonProperty("loudness_end")]
        public double LoudnessEnd { get; set; }

        [JsonProperty("pitches")]
        public List<double> Pitches { get; set; }

        [JsonProperty("timbre")]
        public List<double> Timbre { get; set; }
    }
}
