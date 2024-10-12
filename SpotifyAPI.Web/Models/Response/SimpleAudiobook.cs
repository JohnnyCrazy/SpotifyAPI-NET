using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class SimpleAudiobook
  {
    public List<Author> Authors { get; set; } = default!;
    public List<string> AvailableMarkets { get; set; } = default!;
    public List<Copyright> Copyrights { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string HtmlDescription { get; set; } = default!;
    public string Edition { get; set; } = default!;
    public bool Explicit { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public List<string> Languages { get; set; } = default!;
    public string MediaType { get; set; } = default!;
    public string Name { get; set; } = default!;
    public List<Narrator> Narrators { get; set; } = default!;
    public string Publisher { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
    public int TotalChapters { get; set; }
  }
}

