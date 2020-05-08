namespace SpotifyAPI.Web
{
  public class Device
  {
    public string Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsPrivateSession { get; set; }
    public bool IsRestricted { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int? VolumePercent { get; set; }
  }
}
