using System;
namespace SpotifyAPI.Web
{
  public class PlaylistTrack
  {
    public DateTime? AddedAt { get; set; }
    public PublicUser AddedBy { get; set; }
    public bool IsLocal { get; set; }
    public IPlaylistElement Track { get; set; }
  }
}
