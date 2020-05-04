using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowCheckCurrentUserRequest : RequestParams
  {
    [QueryParam("type")]
    public Types? Type { get; set; }

    [QueryParam("ids")]
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
