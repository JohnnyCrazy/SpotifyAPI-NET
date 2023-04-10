using System.Collections;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TrackRecommendationsRequest : RequestParams
  {
    public TrackRecommendationsRequest(IList<string> seedIdsArtists, 
      IList<string> seedIdsGenres, 
      IList<string> seedIdTracks, int minTempo, int maxTempo)
    {
      Ensure.ArgumentNotNullOrEmptyList(seedIdsArtists, nameof(seedIdsArtists));
      IdsArtists = seedIdsArtists;

      Ensure.ArgumentNotNullOrEmptyList(seedIdsGenres, nameof(seedIdsGenres));
      IdsGenres = seedIdsGenres;

      Ensure.ArgumentNotNullOrEmptyList(seedIdTracks, nameof(seedIdTracks));
      IdsTracks = seedIdTracks;

      MinTempo = minTempo;
      MaxTempo = maxTempo;
    }
    
    [QueryParam("min_tempo")]
    public int MinTempo { get; }

    [QueryParam("max_tempo")]
    public int MaxTempo { get; }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the artists. Maximum: 100 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_artists")]
    public IList<string> IdsArtists { get; }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 100 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_tracks")]
    public IList<string> IdsTracks { get; }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 100 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("seed_genres")]
    public IList<string> IdsGenres { get; }
  }
}
