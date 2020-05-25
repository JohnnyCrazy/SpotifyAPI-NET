using System;

namespace SpotifyAPI.Web
{
  public class SavedAlbum
  {
    public DateTime AddedAt { get; set; }
    public FullAlbum Album { get; set; } = default!;
  }
}

