using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class AnalysisSection
    {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("loudness")]
        public double Loudness { get; set; }

        [JsonProperty("tempo")]
        public double Tempo { get; set; }

        [JsonProperty("tempo_confidence")]
        public double TempoConfidence { get; set; }

        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("key_confidence")]
        public double KeyConfidence { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("mode_confidence")]
        public double ModeConfidence { get; set; }

        [JsonProperty("time_signature")]
        public int TimeSignature { get; set; }

        [JsonProperty("time_signature_confidence")]
        public double TimeSignatureConfidence { get; set; }
    }
}
