using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistRemoveItemsRequest : RequestParams
  {
    public PlaylistRemoveItemsRequest(IList<Item> tracks)
    {
      Ensure.ArgumentNotNullOrEmptyList(tracks, nameof(tracks));

      Tracks = tracks;
    }

    [BodyParam("tracks")]
    public IList<Item> Tracks { get; }

    [BodyParam("snapshot_id")]
    public string SnapshotId { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034")]
    public class Item
    {
      [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
      public string Uri { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227")]
      [JsonProperty("positions", NullValueHandling = NullValueHandling.Ignore)]
      public List<int> Positions { get; set; }
    }
  }
}
