using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class FullTrack : BasicModel
    {
        [JsonProperty("album")]
        public SimpleAlbum Album { get; set; }

        [JsonProperty("artists")]
        public List<SimpleArtist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<String> AvailableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("explicit")]
        public Boolean Explicit { get; set; }

        [JsonProperty("external_ids")]
        public Dictionary<String, String> ExternalIds { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<String, String> ExternUrls { get; set; }

        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("preview_url")]
        public String PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }

        /// <summary>
        ///     Only filled when the "market"-parameter was supplied!
        /// </summary>
        [JsonProperty("is_playable")]
        public Boolean? IsPlayable { get; set; }

        /// <summary>
        ///     Only filled when the "market"-parameter was supplied!
        /// </summary>
        [JsonProperty("linked_from")]
        public LinkedFrom LinkedFrom { get; set; }
    }
}