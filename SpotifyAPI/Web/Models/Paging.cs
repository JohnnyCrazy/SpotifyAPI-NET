using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class Paging<T> : BasicModel
    {
        [JsonProperty("href")]
        public String Href { get; set; }
        [JsonProperty("items")]
        public List<T> Items { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("next")]
        public String Next { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("previous")]
        public String Previous { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
