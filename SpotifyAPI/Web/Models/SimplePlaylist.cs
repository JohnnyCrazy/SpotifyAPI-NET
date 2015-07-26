using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SimplePlaylist : BasicModel
    {
        [JsonProperty("collaborative")]
        public Boolean Collaborative { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("owner")]
        public PublicProfile Owner { get; set; }

        [JsonProperty("public")]
        public Boolean Public { get; set; }

        [JsonProperty("snapshot_id")]
        public String SnapshotId { get; set; }

        [JsonProperty("tracks")]
        public PlaylistTrackCollection Tracks { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }
    }
}