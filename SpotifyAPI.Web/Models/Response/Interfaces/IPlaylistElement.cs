using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public enum ItemType
  {
    Track,
    Episode,
    Chapter
  }

  public interface IPlayableItem
  {
    [JsonConverter(typeof(StringEnumConverter))]
    ItemType Type { get; }
  }
}

