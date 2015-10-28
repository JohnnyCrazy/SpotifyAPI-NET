using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class FullArtist : BasicModel
    {
        [JsonProperty("external_urls")]
        public Dictionary<String, String> ExternalUrls { get; set; }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        [JsonProperty("genres")]
        public List<String> Genres { get; set; }

        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }
    }
}