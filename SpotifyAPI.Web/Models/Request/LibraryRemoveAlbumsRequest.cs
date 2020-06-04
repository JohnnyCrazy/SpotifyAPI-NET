using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryRemoveAlbumsRequest : RequestParams
  {
    /// <summary>
    /// </summary>
    /// <param name="ids">
    /// A comma-separated list of the Spotify IDs.
    /// For example: ids=4iV5W9uYEdYUVa79Axb7Rh,1301WleyT98MSxVHPZCA6M. Maximum: 50 IDs.
    /// </param>
    public LibraryRemoveAlbumsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs.
    /// For example: ids=4iV5W9uYEdYUVa79Axb7Rh,1301WleyT98MSxVHPZCA6M. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [BodyParam("ids")]
    public IList<string> Ids { get; }
  }
}

