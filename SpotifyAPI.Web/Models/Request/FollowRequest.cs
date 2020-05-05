using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowRequest : RequestParams
  {
    public FollowRequest(Type type, IList<string> ids)
    {
      Ensure.ArgumentNotNull(type, nameof(type));
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      TypeParam = type;
      Ids = ids;
    }

    [QueryParam("type")]
    public Type? TypeParam { get; set; }

    [BodyParam("ids")]
    public IList<string> Ids { get; }

    public enum Type
    {
      [String("artist")]
      Artist,
      [String("user")]
      User
    }
  }
}
