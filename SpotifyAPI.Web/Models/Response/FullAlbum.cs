using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FullAlbum
  {
    public string AlbumType { get; set; }
    public List<SimpleArtist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public List<Copyright> Copyrights { get; set; }
    public Dictionary<string, string> ExternalIds { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public List<string> Genres { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
    public int Popularity { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public Dictionary<string, string> Restrictions { get; set; }
    public Paging<SimpleTrack> Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
  }
}
