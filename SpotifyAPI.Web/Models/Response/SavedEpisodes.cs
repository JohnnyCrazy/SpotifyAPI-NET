using System;

namespace SpotifyAPI.Web
{
  public class SavedEpisodes
  {
    public DateTime AddedAt { get; set; }
    public FullEpisode Episode { get; set; } = default!;
  }
}
