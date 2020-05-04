using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowRequest : RequestParams
  {
    [QueryParam("type")]
    public Types? Type { get; set; }

    [BodyParam("ids")]
    public List<string> Ids { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNull(Type, nameof(Type));
      Ensure.ArgumentNotNullOrEmptyList(Ids, nameof(Ids));
    }

    public enum Types
    {
      [String("artist")]
      Artist,
      [String("user")]
      User
    }
  }
}
