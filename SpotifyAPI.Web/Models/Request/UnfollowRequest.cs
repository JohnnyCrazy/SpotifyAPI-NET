using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public class UnfollowRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="type">The ID type: either artist or user.</param>
    /// <param name="ids">
    /// A comma-separated list of the artist or the user Spotify IDs. F
    /// or example: ids=74ASZWbe4lXaubB36ztrGX,08td7MxkoHQkXnWAYD8d6Q.
    /// A maximum of 50 IDs can be sent in one request.
    /// </param>
    public UnfollowRequest(Type type, IList<string> ids)
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
    /// A comma-separated list of the artist or the user Spotify IDs. F
    /// or example: ids=74ASZWbe4lXaubB36ztrGX,08td7MxkoHQkXnWAYD8d6Q.
    /// A maximum of 50 IDs can be sent in one request.
    /// </summary>
    /// <value></value>
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

