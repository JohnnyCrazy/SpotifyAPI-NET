using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class SimpleAlbum
  {
    [System.Obsolete("Field 'album_group' has been removed.")]
    public string AlbumGroup { get; set; } = default!;
    public string AlbumType { get; set; } = default!;
    public List<SimpleArtist> Artists { get; set; } = default!;
    [System.Obsolete("Field 'available_markets' has been removed.")]
    public List<string> AvailableMarkets { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ReleaseDate { get; set; } = default!;
    public string ReleaseDatePrecision { get; set; } = default!;
    public Dictionary<string, string> Restrictions { get; set; } = default!;
    public int TotalTracks { get; set; }
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

