using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class Image
  {
    [JsonConverter(typeof(DoubleToIntConverter))]
    public int Height { get; set; }
    [JsonConverter(typeof(DoubleToIntConverter))]
    public int Width { get; set; }
    public string Url { get; set; } = default!;
  }
}

