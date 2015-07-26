using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class CursorPaging<T>
    {
        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("items")]
        public List<T> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public String Next { get; set; }

        [JsonProperty("cursors")]
        public Cursor Cursors { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}