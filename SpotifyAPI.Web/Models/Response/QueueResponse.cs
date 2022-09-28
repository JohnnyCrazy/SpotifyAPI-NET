using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class QueueResponse
  {
    public FullTrack CurrentlyPlaying { get; set; } = default!;
    public List<FullTrack> Queue { get; set; } = default!;
  }
}

