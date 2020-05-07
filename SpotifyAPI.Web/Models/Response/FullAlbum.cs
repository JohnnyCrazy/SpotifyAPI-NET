using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FullAlbum
  {
    public string AlbumType { get; private set; }
    public List<SimpleArtist> Artists { get; private set; }
    public List<string> AvailableMarkets { get; private set; }
    public List<Copyright> Copyrights { get; private set; }
    public Dictionary<string, string> ExternalIds { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public List<string> Genres { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public List<Image> Images { get; private set; }
    public string Label { get; private set; }
    public string Name { get; private set; }
    public int Popularity { get; private set; }
    public string ReleaseDate { get; private set; }
    public string ReleaseDatePrecision { get; private set; }
    public Dictionary<string, string> Restrictions { get; private set; }
    public Paging<SimpleTrack> Tracks { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
  }
}
