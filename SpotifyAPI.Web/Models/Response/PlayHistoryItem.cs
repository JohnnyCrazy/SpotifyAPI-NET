using System;
namespace SpotifyAPI.Web
{
  public class PlayHistoryItem
  {
    public SimpleTrack Track { get; private set; }
    public DateTime PlayedAt { get; private set; }
    public Context Context { get; private set; }
  }
}
