using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public enum PlaylistElementType
  {
    Track,
    Episode
  }
  public interface IPlaylistElement
  {
    [JsonConverter(typeof(StringEnumConverter))]
    public PlaylistElementType Type { get; set; }
  }
}
