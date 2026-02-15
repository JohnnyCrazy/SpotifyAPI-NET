using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryCheckItemsRequest : RequestParams
  {
    /// <summary>
    /// </summary>
    /// <param name="uris">
    /// A list of Spotify URIs to check in the user's library. Maximum: 50 URIs.
    /// </param>
    public LibraryCheckItemsRequest(IList<string> uris)
    {
      Ensure.ArgumentNotNullOrEmptyList(uris, nameof(uris));

      Uris = uris;
    }

    /// <summary>
    /// A list of Spotify URIs to check in the user's library. Maximum: 50 URIs.
    /// </summary>
    /// <value></value>
    [QueryParam("uris")]
    public IList<string> Uris { get; }
  }
}
