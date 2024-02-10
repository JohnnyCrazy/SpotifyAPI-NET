using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class Followers
  {
    public string Href { get; set; } = default!;

    [JsonConverter(typeof(DoubleToIntConverter))]
    public int Total { get; set; }
  }
}
