using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowRequest : RequestParams
  {
    [QueryParam("type")]
    public Type? TypeParam { get; set; }

    [BodyParam("ids")]
    public List<string> Ids { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNull(TypeParam, nameof(TypeParam));
      Ensure.ArgumentNotNullOrEmptyList(Ids, nameof(Ids));
    }

    public enum Type
    {
      [String("artist")]
      Artist,
      [String("user")]
      User
    }
  }
}
