using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralShows : BasicModel
    {
        [JsonProperty("shows")]
        public List<SimpleShow> Shows { get; set; }
    }
}