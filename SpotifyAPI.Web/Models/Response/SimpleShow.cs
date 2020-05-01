using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class SimpleShow
  {
    public List<string> AvailableMarkets { get; set; }
    public Copyright Copyright { get; set; }
    public string Description { get; set; }
    public bool Explicit { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public bool IsExternallyHosted { get; set; }
    public List<string> Languages { get; set; }
    public string MediaType { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
  }
}
