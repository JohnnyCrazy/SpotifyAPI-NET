using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryCheckAudiobooksRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">A comma-separated list of the Spotify IDs for the shows. Maximum: 50 ids.</param>
    public LibraryCheckAudiobooksRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNull(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the shows. Maximum: 50 ids.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}
