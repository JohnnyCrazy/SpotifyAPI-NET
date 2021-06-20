using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PublicUser
  {
    public string DisplayName { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public Followers Followers { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

