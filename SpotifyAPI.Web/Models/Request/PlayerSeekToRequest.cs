namespace SpotifyAPI.Web
{
  public class PlayerSeekToRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="positionMs">
    /// The position in milliseconds to seek to. Must be a positive number.
    /// Passing in a position that is greater than the length of the track will
    /// cause the player to start playing the next song.
    /// </param>
    public PlayerSeekToRequest(long positionMs)
    {
      PositonMs = positionMs;
    }

    /// <summary>
    /// The position in milliseconds to seek to. Must be a positive number.
    /// Passing in a position that is greater than the length of the track will cause
    /// the player to start playing the next song.
    /// </summary>
    /// <value></value>
    [QueryParam("position_ms")]
    public long PositonMs { get; }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

