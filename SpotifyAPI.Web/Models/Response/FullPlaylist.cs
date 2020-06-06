using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class FullPlaylist
  {
    public bool Collaborative { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    public string Name { get; set; } = default!;
    public PublicUser Owner { get; set; } = default!;
    public bool Public { get; set; }
    public string SnapshotId { get; set; } = default!;

    /// <summary>
    /// A list of PlaylistTracks, which items can be a FullTrack or FullEpisode
    /// </summary>
    /// <value></value>
    public Paging<PlaylistTrack<IPlayableItem>> Tracks { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

