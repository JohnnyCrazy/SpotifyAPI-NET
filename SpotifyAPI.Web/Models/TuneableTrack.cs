using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace SpotifyAPI.Web.Models
{
    public class TuneableTrack
    {
        [String("acousticness")]
        public float? Acousticness { get; set; }

        [String("danceability")]
        public float? Danceability { get; set; }

        [String("duration_ms")]
        public int? DurationMs { get; set; }

        [String("energy")]
        public float? Energy { get; set; }

        [String("instrumentalness")]
        public float? Instrumentalness { get; set; }

        [String("key")]
        public int? Key { get; set; }

        [String("liveness")]
        public float? Liveness { get; set; }

        [String("loudness")]
        public float? Loudness { get; set; }

        [String("mode")]
        public int? Mode { get; set; }

        [String("popularity")]
        public int? Popularity { get; set; }

        [String("speechiness")]
        public float? Speechiness { get; set; }

        [String("tempo")]
        public float? Tempo { get; set; }

        [String("time_signature")]
        public int? TimeSignature { get; set; }

        [String("valence")]
        public float? Valence { get; set; }

        public string BuildUrlParams(string prefix)
        {
            List<string> urlParams = new List<string>();
            foreach (PropertyInfo info in GetType().GetProperties())
            {
                object value = info.GetValue(this);
                string name = info.GetCustomAttribute<StringAttribute>()?.Text;
                if(name == null || value == null)
                    continue;
                urlParams.Add(value is float valueAsFloat
                    ? $"{prefix}_{name}={valueAsFloat.ToString(CultureInfo.InvariantCulture)}"
                    : $"{prefix}_{name}={value}");
            }
            if (urlParams.Count > 0)
                return "&" + string.Join("&", urlParams);
            return "";
        }
    }
}