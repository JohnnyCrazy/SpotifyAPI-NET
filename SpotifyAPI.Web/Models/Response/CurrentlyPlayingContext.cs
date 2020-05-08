using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class CurrentlyPlayingContext
  {
    public Device Device { get; set; }
    public string RepeatState { get; set; }
    public bool ShuffleState { get; set; }
    public Context Context { get; set; }
    public long Timestamp { get; set; }
    public int ProgressMs { get; set; }
    public bool IsPlaying { get; set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public IPlayableItem Item { get; set; }

    public string CurrentlyPlayingType { get; set; }
    public Actions Actions { get; set; }
  }
}
