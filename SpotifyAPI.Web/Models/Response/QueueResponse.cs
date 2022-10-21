using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class QueueResponse
  {
    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem CurrentlyPlaying { get; set; } = default!;
    [JsonProperty(ItemConverterType = typeof(PlayableItemConverter))]
    public List<IPlayableItem> Queue { get; set; } = default!;
  }
}

