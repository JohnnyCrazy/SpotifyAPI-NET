using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class RecommendationsResponse
  {
    public List<RecommendationSeed> Seeds { get; private set; }
    public List<SimpleTrack> Tracks { get; private set; }
  }
}
