namespace SpotifyAPI.Web
{
  public class PlayerSetRepeatRequest : RequestParams
  {
    /// <summary></summary>
    /// <param name="state">
    /// track, context or off. track will repeat the current track. context will repeat the current context.
    /// off will turn repeat off.
    /// </param>
    public PlayerSetRepeatRequest(State state)
    {
      Ensure.ArgumentNotNull(state, nameof(state));

      StateParam = state;
    }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// track, context or off. track will repeat the current track. context will repeat the current context.
    /// off will turn repeat off.
    /// </summary>
    /// <value></value>
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

