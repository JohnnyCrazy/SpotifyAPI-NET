using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowCheckCurrentUserRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="type">The ID type: either artist or user.</param>
    /// <param name="ids">
    /// A list of the artist or the user Spotify IDs to check.
    /// For example: ids=74ASZWbe4lXaubB36ztrGX,08td7MxkoHQkXnWAYD8d6Q.
    /// A maximum of 50 IDs can be sent in one request.
    /// </param>
    public FollowCheckCurrentUserRequest(Type type, IList<string> ids)
    {
      Ensure.ArgumentNotNull(type, nameof(type));
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      TypeParam = type;
      Ids = ids;
    }

    /// <summary>
    /// The ID type: either artist or user.
    /// </summary>
    /// <value></value>
    [QueryParam("type")]
    public Type TypeParam { get; }

    /// <summary>
    /// A list of the artist or the user Spotify IDs to check.
    /// For example: ids=74ASZWbe4lXaubB36ztrGX,08td7MxkoHQkXnWAYD8d6Q.
    /// A maximum of 50 IDs can be sent in one request.
    /// </summary>
    /// <value></value>
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

