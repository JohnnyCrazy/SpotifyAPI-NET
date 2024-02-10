using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FullShow
  {
    public List<string> AvailableMarkets { get; set; } = default!;
    public List<Copyright> Copyrights { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string HtmlDescription { get; set; } = default!;
    public Paging<SimpleEpisode> Episodes { get; set; } = default!;
    public bool Explicit { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public bool IsExternallyHosted { get; set; }
    public List<string> Languages { get; set; } = default!;
    public string MediaType { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Publisher { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
    public int TotalEpisodes { get; set; } = default!;
  }
}

