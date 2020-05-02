using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistAddItemsRequest : RequestParams
  {
    [BodyParam("uris")]
    public List<string> Uris { get; set; }

    [BodyParam("position")]
    public int? Position { get; set; }
  }
}
