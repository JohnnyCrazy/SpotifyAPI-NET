using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Context
  {
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
  }
}
