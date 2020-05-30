namespace SpotifyAPI.Web
{
  public class PlaylistGetUsersRequest : RequestParams
  {
    /// <summary>
    /// The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first playlist to return. Default: 0 (the first object).
    /// Maximum offset: 100.000. Use with limit to get the next set of playlists.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

