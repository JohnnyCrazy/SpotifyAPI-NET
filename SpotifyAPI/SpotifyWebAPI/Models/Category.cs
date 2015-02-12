using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
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
