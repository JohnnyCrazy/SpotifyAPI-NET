namespace SpotifyAPI.Web
{
  public class PlayerVolumeRequest : RequestParams
  {
    public PlayerVolumeRequest(int volumePercent)
    {
      VolumePercent = volumePercent;
    }

    [QueryParam("volume_percent")]
    public int VolumePercent { get; }

    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

