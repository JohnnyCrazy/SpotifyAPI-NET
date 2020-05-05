using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistAddItemsRequest : RequestParams
  {
    public PlaylistAddItemsRequest(IList<string> uris)
    {
      Ensure.ArgumentNotNull(uris, nameof(uris));

      Uris = uris;
    }

    [BodyParam("uris")]
    public IList<string> Uris { get; }

    [BodyParam("position")]
    public int? Position { get; set; }
  }
}
