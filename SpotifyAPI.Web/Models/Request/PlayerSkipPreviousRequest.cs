namespace SpotifyAPI.Web
{
  public class PlayerSkipPreviousRequest : RequestParams
  {
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

