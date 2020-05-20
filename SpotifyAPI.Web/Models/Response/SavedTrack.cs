using System;

namespace SpotifyAPI.Web
{
  public class SavedTrack
  {
    public DateTime AddedAt { get; set; }
    public FullTrack Track { get; set; }
  }
}
