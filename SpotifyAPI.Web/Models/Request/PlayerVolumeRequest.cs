namespace SpotifyAPI.Web
{
  public class PlayerVolumeRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="volumePercent">The volume to set. Must be a value from 0 to 100 inclusive.</param>
    public PlayerVolumeRequest(int volumePercent)
    {
      VolumePercent = volumePercent;
    }

    /// <summary>
    /// The volume to set. Must be a value from 0 to 100 inclusive.
    /// </summary>
    /// <value></value>
    [QueryParam("volume_percent")]
    public int VolumePercent { get; }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

