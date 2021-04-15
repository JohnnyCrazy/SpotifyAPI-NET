using System;
namespace SpotifyAPI.Web
{
  public class PlayHistoryItem
  {
    public FullTrack Track { get; set; } = default!;
    public DateTime PlayedAt { get; set; }
    public Context Context { get; set; } = default!;
  }
}

