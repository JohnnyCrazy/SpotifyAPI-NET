namespace SpotifyAPI.Web
{
  public class PlayerSetRepeatRequest : RequestParams
  {
    public PlayerSetRepeatRequest(State state)
    {
      Ensure.ArgumentNotNull(state, nameof(state));

      StateParam = state;
    }

    [QueryParam("device_id")]
    public string DeviceId { get; set; }

    [QueryParam("state")]
    public State StateParam { get; }

    public enum State
    {
      [String("track")]
      Track,

      [String("context")]
      Context,

      [String("off")]
      Off
    }
  }
}
