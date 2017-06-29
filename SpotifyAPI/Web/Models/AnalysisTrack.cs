using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class AnalysisTrack
    {
        [JsonProperty("num_samples")]
        public int NumSamples { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("sample_md5")]
        public string SampleMD5 { get; set; }

        [JsonProperty("offset_seconds")]
        public double OffsetSeconds { get; set; }

        [JsonProperty("window_seconds")]
        public double WindowSeconds { get; set; }

        [JsonProperty("analysis_sample_rate")]
        public int AnalysisSampleRate { get; set; }

        [JsonProperty("analysis_channels")]
        public int AnalysisChannels { get; set; }

        [JsonProperty("end_of_fade_in")]
        public double EndOfFadeIn { get; set; }

        [JsonProperty("start_of_fade_out")]
        public double StartOfFadeOut { get; set; }

        [JsonProperty("loudness")]
        public double Loudness { get; set; }

        [JsonProperty("tempo")]
        public double Tempo { get; set; }

        [JsonProperty("tempo_confidence")]
        public double TempoConfidence { get; set; }

        [JsonProperty("time_signature")]
        public double TimeSignature { get; set; }

        [JsonProperty("time_signature_confidence")]
        public double TimeSignatureConfidence { get; set; }

        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("key_confidence")]
        public double KeyConfidence { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("mode_confidence")]
        public double ModeConfidence { get; set; }

        [JsonProperty("codestring")]
        public string Codestring { get; set; }

        [JsonProperty("code_version")]
        public double CodeVersion { get; set; }

        [JsonProperty("echoprintstring")]
        public string Echoprintstring { get; set; }

        [JsonProperty("echoprint_version")]
        public double EchoprintVersion { get; set; }

        [JsonProperty("synchstring")]
        public string Synchstring { get; set; }

        [JsonProperty("synch_version")]
        public double SynchVersion { get; set; }

        [JsonProperty("rhythmstring")]
        public string Rhythmstring { get; set; }

        [JsonProperty("rhythm_version")]
        public double RhythmVersion { get; set; }

    }
}
