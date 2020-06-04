using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistAddItemsRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="uris">
    /// A JSON array of the Spotify URIs to add.
    /// For example: {"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
    /// "spotify:track:1301WleyT98MSxVHPZCA6M", "spotify:episode:512ojhOuo1ktJprKbVcKyQ"]}
    /// A maximum of 100 items can be added in one request.
    /// </param>
    public PlaylistAddItemsRequest(IList<string> uris)
    {
      Ensure.ArgumentNotNull(uris, nameof(uris));

      Uris = uris;
    }

    /// <summary>
    /// A JSON array of the Spotify URIs to add.
    /// For example: {"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
    /// "spotify:track:1301WleyT98MSxVHPZCA6M", "spotify:episode:512ojhOuo1ktJprKbVcKyQ"]}
    /// A maximum of 100 items can be added in one request.
    /// </summary>
    /// <value></value>
    [BodyParam("uris")]
    public IList<string> Uris { get; }

    /// <summary>
    /// The position to insert the items, a zero-based index.
    /// For example, to insert the items in the first position: position=0 ;
    ///  to insert the items in the third position: position=2. If omitted, the items will be appended to the playlist.
    /// Items are added in the order they appear in the uris array.
    /// </summary>
    /// <value></value>
    [BodyParam("position")]
    public int? Position { get; set; }
  }
}

