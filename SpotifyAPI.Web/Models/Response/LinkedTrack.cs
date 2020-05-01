using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class LinkedTrack
  {
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Type { get; set; }
    public string uri { get; set; }
  }
}
