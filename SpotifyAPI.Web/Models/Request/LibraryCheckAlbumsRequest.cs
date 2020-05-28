using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryCheckAlbumsRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">
    /// A comma-separated list of the Spotify IDs for the albums. Maximum: 50 IDs.
    /// </param>
    public LibraryCheckAlbumsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNull(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the albums. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

