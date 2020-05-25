using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class RecommendationsResponse
  {
    public List<RecommendationSeed> Seeds { get; set; } = default!;
    public List<SimpleTrack> Tracks { get; set; } = default!;
  }
}

