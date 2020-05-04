using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowCheckPlaylistRequest : RequestParams
  {
    [QueryParam("ids")]
    public List<string> Ids { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNullOrEmptyList(Ids, nameof(Ids));
    }
  }
}
