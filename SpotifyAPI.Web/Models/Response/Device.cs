namespace SpotifyAPI.Web
{
  public class Device
  {
    public string Id { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsPrivateSession { get; private set; }
    public bool IsRestricted { get; private set; }
    public string Name { get; private set; }
    public string Type { get; private set; }
    public int? VolumePercent { get; private set; }
  }
}
