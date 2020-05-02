using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class RecommendationSeed
  {
    [JsonProperty("afterFilteringSize")]
    public int AfterFiliteringSize { get; set; }

    [JsonProperty("afterRelinkingSize")]
    public int AfterRelinkingSize { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    [JsonProperty("initialPoolSize")]
    public int InitialPoolSize { get; set; }
    public string Type { get; set; }
  }
}
