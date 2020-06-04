namespace SpotifyAPI.Web
{
  public class PlayerRecentlyPlayedRequest : RequestParams
  {
    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A Unix timestamp in milliseconds. Returns all items after (but not including) this cursor position.
    /// If after is specified, before must not be specified.
    /// </summary>
    /// <value></value>
    [QueryParam("after")]
    public long? After { get; set; }

    /// <summary>
    /// A Unix timestamp in milliseconds. Returns all items before (but not including) this cursor position.
    /// If before is specified, after must not be specified.
    /// </summary>
    /// <value></value>
    [QueryParam("before")]
    public long? Before { get; set; }
  }
}

