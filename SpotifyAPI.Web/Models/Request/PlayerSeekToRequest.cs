namespace SpotifyAPI.Web
{
  public class PlayerSeekToRequest : RequestParams
  {
    public PlayerSeekToRequest(long positionMs)
    {
      PositonMs = positionMs;
    }

    [QueryParam("position_ms")]
    public long PositonMs { get; }

    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

