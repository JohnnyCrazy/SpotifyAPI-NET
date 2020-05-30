namespace SpotifyAPI.Web
{
  public class PlayerSkipNextRequest : RequestParams
  {
    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

