using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistReplaceItemsRequest : RequestParams
  {
    [BodyParam("uris")]
    public List<string> Uris { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNullOrEmptyList(Uris, nameof(Uris));
    }
  }
}
