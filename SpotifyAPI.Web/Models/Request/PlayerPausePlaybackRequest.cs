namespace SpotifyAPI.Web
{
  public class PlayerPausePlaybackRequest : RequestParams
  {
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

