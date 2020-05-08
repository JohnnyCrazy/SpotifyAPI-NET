using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class CurrentlyPlaying
  {
    public Context Context { get; set; }
    public string CurrentlyPlayingType { get; set; }
    public bool IsPlaying { get; set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem Item { get; set; }
    public int? ProgressMs { get; set; }
    public long Timestamp { get; set; }
  }
}
