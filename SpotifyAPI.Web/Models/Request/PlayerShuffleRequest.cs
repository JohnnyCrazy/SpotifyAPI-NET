namespace SpotifyAPI.Web
{
  public class PlayerShuffleRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="state">true : Shuffle user’s playback false : Do not shuffle user’s playback.</param>
    public PlayerShuffleRequest(bool state)
    {
      State = state;
    }

    /// <summary>
    /// true : Shuffle user’s playback false : Do not shuffle user’s playback.
    /// </summary>
    /// <value></value>
    [QueryParam("state")]
    public bool State { get; }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied,
    /// the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

