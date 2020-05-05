using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowCheckCurrentUserRequest : RequestParams
  {
    public FollowCheckCurrentUserRequest(Type type, IList<string> ids)
    {
      Ensure.ArgumentNotNull(type, nameof(type));
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      TypeParam = type;
      Ids = ids;
    }

    [QueryParam("type")]
    public Type TypeParam { get; }

    [QueryParam("ids")]
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
