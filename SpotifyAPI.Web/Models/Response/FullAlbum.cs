using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FullAlbum
  {
    public string AlbumType { get; set; } = default!;
    public List<SimpleArtist> Artists { get; set; } = default!;
    public List<string> AvailableMarkets { get; set; } = default!;
    public List<Copyright> Copyrights { get; set; } = default!;
    public Dictionary<string, string> ExternalIds { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public List<string> Genres { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public string Label { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Popularity { get; set; }
    public string ReleaseDate { get; set; } = default!;
    public string ReleaseDatePrecision { get; set; } = default!;
    public Dictionary<string, string> Restrictions { get; set; } = default!;
    public Paging<SimpleTrack> Tracks { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

