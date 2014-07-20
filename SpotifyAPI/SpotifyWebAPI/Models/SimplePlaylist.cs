using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
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
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("owner")]
        public PublicProfile Owner { get; set; }
        [JsonProperty("public")]
        public Boolean Public { get; set; }
        [JsonProperty("tracks")]
        public PlaylistTrackCollection Tracks { get; set; }
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("uri")]
        public String Uri { get; set; }
    }
}
