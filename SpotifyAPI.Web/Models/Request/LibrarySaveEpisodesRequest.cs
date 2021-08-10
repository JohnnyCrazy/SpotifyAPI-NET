using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibrarySaveEpisodesRequest : RequestParams
  {
    /// <summary>
    /// Request for SaveEpisodes.
    /// </summary>
    /// <param name="ids"></param>
    public LibrarySaveEpisodesRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs. 
    /// Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}
