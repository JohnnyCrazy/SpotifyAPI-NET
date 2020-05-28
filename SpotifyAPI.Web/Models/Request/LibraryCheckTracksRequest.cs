using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryCheckTracksRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 50 IDs.
    /// </param>
    public LibraryCheckTracksRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNull(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

