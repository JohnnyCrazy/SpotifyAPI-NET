using System;
namespace SpotifyAPI.Web
{
  public class PlayHistoryItem
  {
    public SimpleTrack Track { get; set; }
    public DateTime PlayedAt { get; set; }
    public Context Context { get; set; }
  }
}
