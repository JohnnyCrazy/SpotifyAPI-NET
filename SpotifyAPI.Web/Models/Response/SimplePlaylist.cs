using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  /// <summary>
  ///   <a href="https://developer.spotify.com/documentation/web-api/reference/object-model/#playlist-object-simplified">Docs</a>
  /// </summary>
  public class SimplePlaylist
  {
    public bool Collaborative { get; private set; }
    public string Description { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public List<Image> Images { get; private set; }
    public string Name { get; private set; }
    public PublicUser Owner { get; private set; }
    public bool? Public { get; private set; }
    public string SnapshotId { get; private set; }
    public Paging<PlaylistTrack<IPlayableItem>> Tracks { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
  }
}
