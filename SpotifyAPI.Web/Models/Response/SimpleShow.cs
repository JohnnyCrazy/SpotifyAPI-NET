using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class SimpleShow
  {
    public List<string> AvailableMarkets { get; private set; }
    public List<Copyright> Copyrights { get; private set; }
    public string Description { get; private set; }
    public bool Explicit { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public List<Image> Images { get; private set; }
    public bool IsExternallyHosted { get; private set; }
    public List<string> Languages { get; private set; }
    public string MediaType { get; private set; }
    public string Name { get; private set; }
    public string Publisher { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
  }
}
