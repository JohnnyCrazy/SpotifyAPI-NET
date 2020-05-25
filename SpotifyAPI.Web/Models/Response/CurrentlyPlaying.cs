using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class CurrentlyPlaying
  {
    public Context Context { get; set; } = default!;
    public string CurrentlyPlayingType { get; set; } = default!;
    public bool IsPlaying { get; set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem Item { get; set; } = default!;
    public int? ProgressMs { get; set; }
    public long Timestamp { get; set; }
  }
}

