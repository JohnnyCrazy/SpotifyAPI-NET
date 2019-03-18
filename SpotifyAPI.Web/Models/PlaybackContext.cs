using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class PlaybackContext : BasicModel
    {
        [JsonProperty("device")]
        public Device Device { get; set; }

        [JsonProperty("repeat_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RepeatState RepeatState { get; set; }

        [JsonProperty("shuffle_state")]
        public bool ShuffleState { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("progress_ms")]
        public int ProgressMs { get; set; }

        [JsonProperty("is_playing")]
        public bool IsPlaying { get; set; }

        [JsonProperty("item")]
        public FullTrack Item { get; set; }

        [JsonProperty("currently_playing_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackType CurrentlyPlayingType { get; set; }
    }
}