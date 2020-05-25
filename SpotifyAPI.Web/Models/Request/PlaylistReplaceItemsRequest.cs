using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistReplaceItemsRequest : RequestParams
  {
    public PlaylistReplaceItemsRequest(List<string> uris)
    {
      Ensure.ArgumentNotNull(uris, nameof(uris));

      Uris = uris;
    }

    [BodyParam("uris")]
    public IList<string> Uris { get; }
  }
}

