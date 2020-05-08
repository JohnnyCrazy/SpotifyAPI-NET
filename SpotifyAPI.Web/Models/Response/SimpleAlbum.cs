using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class SimpleAlbum
  {
    public string AlbumGroup { get; set; }
    public string AlbumType { get; set; }
    public List<SimpleArtist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public Dictionary<string, string> Restrictions { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
  }
}
