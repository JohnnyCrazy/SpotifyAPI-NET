using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistRemoveItemsRequest : RequestParams
  {
    [BodyParam("tracks")]
    public List<Item> Tracks { get; set; }

    [BodyParam("snapshot_id")]
    public string SnapshotId { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNullOrEmptyList(Tracks, nameof(Tracks));
    }

    public class Item
    {
      public Item(string uri)
      {
        Uri = uri;
      }

      [JsonProperty("uri")]
      public string Uri { get; set; }

      [JsonProperty("positions", NullValueHandling = NullValueHandling.Ignore)]
      public List<int> Positions { get; set; }
    }
  }
}
