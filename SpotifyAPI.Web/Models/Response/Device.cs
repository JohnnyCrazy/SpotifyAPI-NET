namespace SpotifyAPI.Web
{
  public class Device
  {
    public string Id { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool IsPrivateSession { get; set; }
    public bool IsRestricted { get; set; }
    public string Name { get; set; } = default!;
    public bool SupportsVolume { get; set; }
    public string Type { get; set; } = default!;
    public int? VolumePercent { get; set; }
  }
}

