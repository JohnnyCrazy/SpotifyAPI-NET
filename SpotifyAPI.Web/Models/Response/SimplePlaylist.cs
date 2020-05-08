using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  /// <summary>
  ///   <a href="https://developer.spotify.com/documentation/web-api/reference/object-model/#playlist-object-simplified">Docs</a>
  /// </summary>
  public class SimplePlaylist
  {
    public bool Collaborative { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public PublicUser Owner { get; set; }
    public bool? Public { get; set; }
    public string SnapshotId { get; set; }
    public Paging<PlaylistTrack<IPlayableItem>> Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
  }
}
