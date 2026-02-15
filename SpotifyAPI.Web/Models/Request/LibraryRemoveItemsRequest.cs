using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryRemoveItemsRequest : RequestParams
  {
    /// <summary>
    /// </summary>
    /// <param name="uris">
    /// A list of Spotify URIs to remove from the user's library.
    /// For example: uris=spotify:track:4iV5W9uYEdYUVa79Axb7Rh. Maximum: 50 URIs.
    /// </param>
    public LibraryRemoveItemsRequest(IList<string> uris)
    {
      Ensure.ArgumentNotNullOrEmptyList(uris, nameof(uris));

      Uris = uris;
    }

    /// <summary>
    /// A list of Spotify URIs to remove from the user's library. Maximum: 50 URIs.
    /// </summary>
    /// <value></value>
    [BodyParam("uris")]
    public IList<string> Uris { get; }
  }
}
