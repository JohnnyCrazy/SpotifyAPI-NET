using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class SimpleAlbum : BasicModel
    {
        [JsonProperty("album_type")]
        public String AlbumType { get; set; }

        [JsonProperty("available_markets")]
        public List<String> AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<String, String> ExternalUrls { get; set; }

        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }
    }
}