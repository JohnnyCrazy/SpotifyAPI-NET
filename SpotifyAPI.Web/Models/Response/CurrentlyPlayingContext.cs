using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class CurrentlyPlayingContext
  {
    public Device Device { get; set; } = default!;
    public string RepeatState { get; set; } = default!;
    public bool ShuffleState { get; set; }
    public Context Context { get; set; } = default!;
    public long Timestamp { get; set; }
    public int ProgressMs { get; set; }
    public bool IsPlaying { get; set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem Item { get; set; } = default!;

    public string CurrentlyPlayingType { get; set; } = default!;
    public Actions Actions { get; set; } = default!;
  }
}

