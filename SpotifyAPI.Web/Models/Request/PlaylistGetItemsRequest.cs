using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetItemsRequest : RequestParams
  {
    [QueryParam("fields")]
    public List<string> Fields { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    [QueryParam("additional_types")]
    public List<string> AdditionalTypes { get; set; }
  }
}
