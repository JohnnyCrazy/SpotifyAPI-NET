using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class CurrentlyPlaying
  {
    public Context Context { get; private set; }
    public string CurrentlyPlayingType { get; private set; }
    public bool IsPlaying { get; private set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem Item { get; private set; }
    public int? ProgressMs { get; private set; }
    public long Timestamp { get; private set; }
  }
}
