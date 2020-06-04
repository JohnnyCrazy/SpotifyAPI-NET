using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistReplaceItemsRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="uris">
    /// A comma-separated list of Spotify URIs to set, can be track or episode URIs.
    /// A maximum of 100 items can be set in one request.
    /// </param>
    public PlaylistReplaceItemsRequest(List<string> uris)
    {
      Ensure.ArgumentNotNull(uris, nameof(uris));

      Uris = uris;
    }

    /// <summary>
    /// A comma-separated list of Spotify URIs to set, can be track or episode URIs.
    /// A maximum of 100 items can be set in one request.
    /// </summary>
    /// <value></value>
    [BodyParam("uris")]
    public IList<string> Uris { get; }
  }
}

