using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class CategoryList : BasicModel
    {
        [JsonProperty("categories")]
        public Paging<Category> Categories { get; set; }
    }
}