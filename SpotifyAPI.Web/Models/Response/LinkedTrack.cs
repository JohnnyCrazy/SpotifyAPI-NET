using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class LinkedTrack
  {
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
  }
}
