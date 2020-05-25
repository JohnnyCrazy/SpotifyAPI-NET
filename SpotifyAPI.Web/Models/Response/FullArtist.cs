using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FullArtist
  {
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public Followers Followers { get; set; } = default!;
    public List<string> Genres { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Popularity { get; set; }
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

