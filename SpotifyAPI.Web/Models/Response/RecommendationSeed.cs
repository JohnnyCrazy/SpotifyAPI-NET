using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class RecommendationSeed
  {
    [JsonProperty("afterFilteringSize")]
    public int AfterFiliteringSize { get; private set; }

    [JsonProperty("afterRelinkingSize")]
    public int AfterRelinkingSize { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    [JsonProperty("initialPoolSize")]
    public int InitialPoolSize { get; private set; }
    public string Type { get; private set; }
  }
}
