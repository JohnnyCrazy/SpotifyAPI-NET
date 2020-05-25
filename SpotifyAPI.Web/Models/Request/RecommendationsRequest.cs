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
      SeedArtists = new List<string>();
      SeedGenres = new List<string>();
      SeedTracks = new List<string>();
    }

    [QueryParam("seed_artists")]
    public IList<string> SeedArtists { get; }

    [QueryParam("seed_genres")]
    public IList<string> SeedGenres { get; }

    [QueryParam("seed_tracks")]
    public IList<string> SeedTracks { get; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("market")]
    public string? Market { get; set; }

    public Dictionary<string, string> Min { get; }
    public Dictionary<string, string> Max { get; }
    public Dictionary<string, string> Target { get; }

    protected override void CustomEnsure()
    {
      if (SeedArtists.Count == 0 && SeedGenres.Count == 0 && SeedTracks.Count == 0)
      {
        throw new ArgumentException("At least one of the seeds has to be non-empty");
      }
    }

    protected override void AddCustomQueryParams(Dictionary<string, string> queryParams)
    {
      Ensure.ArgumentNotNull(queryParams, nameof(queryParams));

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

