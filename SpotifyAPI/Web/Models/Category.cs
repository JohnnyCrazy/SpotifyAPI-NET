using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class Category : BasicModel
    {
        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("icons")]
        public List<Image> Icons { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}