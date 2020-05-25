namespace SpotifyAPI.Web
{
  public class PlayerSkipNextRequest : RequestParams
  {
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

