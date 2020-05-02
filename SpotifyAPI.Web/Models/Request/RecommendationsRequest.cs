using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class RecommendationsRequest : RequestParams
  {
    public RecommendationsRequest()
    {
      Min = new Dictionary<string, string>();
      Max = new Dictionary<string, string>();
      Target = new Dictionary<string, string>();
    }

    [QueryParam("seed_artists")]
    public string SeedArtists { get; set; }

    [QueryParam("seed_genres")]
    public string SeedGenres { get; set; }

    [QueryParam("seed_tracks")]
    public string SeedTracks { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    public Dictionary<string, string> Min { get; set; }
    public Dictionary<string, string> Max { get; set; }
    public Dictionary<string, string> Target { get; set; }

    protected override void CustomEnsure()
    {
      if (string.IsNullOrEmpty(SeedTracks) && string.IsNullOrEmpty(SeedGenres) && string.IsNullOrEmpty(SeedArtists))
      {
        throw new ArgumentException("At least one of the seeds has to be non-empty");
      }
    }

    protected override void AddCustomQueryParams(System.Collections.Generic.Dictionary<string, string> queryParams)
    {
      foreach (KeyValuePair<string, string> pair in Min)
      {
        queryParams.Add($"min_{pair.Key}", pair.Value);
      }
      foreach (KeyValuePair<string, string> pair in Min)
      {
        queryParams.Add($"max_{pair.Key}", pair.Value);
      }
      foreach (KeyValuePair<string, string> pair in Min)
      {
        queryParams.Add($"target_{pair.Key}", pair.Value);
      }
    }
  }
}
