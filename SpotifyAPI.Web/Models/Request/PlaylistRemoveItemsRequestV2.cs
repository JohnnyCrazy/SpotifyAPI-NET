using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistRemoveItemsRequestV2 : RequestParams
  {
    /// <summary>
    /// An array of objects containing Spotify URIs of the tracks or episodes to remove.
    /// For example: { "items": [{ "uri": "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" },
    /// { "uri": "spotify:track:1301WleyT98MSxVHPZCA6M" }] }.
    /// A maximum of 100 objects can be sent at once.
    /// </summary>
    /// <value></value>
    [BodyParam("items")]
    public IList<Item>? Items { get; set; }

    /// <summary>
    /// The playlist’s snapshot ID against which you want to make the changes.
    /// The API will validate that the specified items exist and in the specified positions and make the changes,
    /// even if more recent changes have been made to the playlist.
    /// </summary>
    /// <value></value>
    [BodyParam("snapshot_id")]
    public string? SnapshotId { get; set; }

    public class Item
    {
      [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
      public string? Uri { get; set; }
    }
  }
}

