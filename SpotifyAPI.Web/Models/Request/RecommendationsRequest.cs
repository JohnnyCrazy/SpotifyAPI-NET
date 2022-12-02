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

    /// <summary>
    /// A comma separated list of Spotify IDs for seed artists.
    /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_artists")]
    public IList<string> SeedArtists { get; }

    /// <summary>
    /// A comma separated list of any genres in the set of available genre seeds.
    /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_genres")]
    public IList<string> SeedGenres { get; }

    /// <summary>
    /// A comma separated list of Spotify IDs for a seed track.
    /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_tracks")]
    public IList<string> SeedTracks { get; }

    /// <summary>
    /// The target size of the list of recommended tracks.
    /// For seeds with unusually small pools or when highly restrictive filtering is applied,
    ///  it may be impossible to generate the requested number of recommended tracks.
    /// Debugging information for such cases is available in the response. Default: 20. Minimum: 1. Maximum: 100.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking.
    /// Because min_*, max_* and target_* are applied to pools before relinking, the generated results
    ///  may not precisely match the filters applied. Original,
    /// non-relinked tracks are available via the linked_from attribute of the relinked track response.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }

    /// <summary>
    /// The desired language, consisting of an ISO 639-1 language code and an ISO 3166-1 alpha-2 country code,
    /// joined by an underscore. For example: es_MX, meaning "Spanish (Mexico)".
    /// Provide this parameter if you want the category strings returned in a particular language.
    /// Note that, if locale is not supplied, or if the specified language is not available,
    /// the category strings returned will be in the Spotify default language (American English).
    /// </summary>
    /// <value></value>
    [QueryParam("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// Multiple values. For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided.
    /// See tunable track attributes below for the list of available options.
    /// For example, min_tempo=140 would restrict results to only those tracks with a tempo of greater than 140 beats per minute.
    /// DO NOT INCLUDE min_ IN THE KEY
    /// </summary>
    /// <value></value>
    public Dictionary<string, string> Min { get; }

    /// <summary>
    /// Multiple values. For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided.
    /// See tunable track attributes below for the list of available options.
    /// For example, max_instrumentalness=0.35 would filter out most tracks that are likely to be instrumental.
    /// DO NOT INCLUDE max_ IN THE KEY
    /// </summary>
    /// <value></value>
    public Dictionary<string, string> Max { get; }

    /// <summary>
    /// Multiple values. For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request target_energy=0.6 and target_danceability=0.8.
    /// All target values will be weighed equally in ranking results.
    /// DO NOT INCLUDE target_ IN THE KEY
    /// </summary>
    /// <value></value>
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
      foreach (KeyValuePair<string, string> pair in Max)
      {
        queryParams.Add($"max_{pair.Key}", pair.Value);
      }
      foreach (KeyValuePair<string, string> pair in Target)
      {
        queryParams.Add($"target_{pair.Key}", pair.Value);
      }
    }
  }
}

