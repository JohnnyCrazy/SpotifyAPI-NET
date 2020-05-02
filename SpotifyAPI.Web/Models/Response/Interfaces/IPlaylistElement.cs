using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public enum ElementType
  {
    Track,
    Episode
  }

  public interface IPlaylistElement
  {
    [JsonConverter(typeof(StringEnumConverter))]
    public ElementType Type { get; set; }
  }
}
