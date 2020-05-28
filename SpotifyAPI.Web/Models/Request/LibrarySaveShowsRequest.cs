using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibrarySaveShowsRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">A comma-separated list of Spotify IDs for the shows to be added to the user’s library.</param>
    public LibrarySaveShowsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of Spotify IDs for the shows to be added to the user’s library.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

