using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public enum ItemType
  {
    Track,
    Episode
  }

  public interface IPlaylistItem
  {
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; set; }
  }
}
