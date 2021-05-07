namespace SpotifyAPI.Web
{
  public class LibraryEpisodesRequest : RequestParams
  {
    /// <summary>
    /// The maximum number of episodes to return. Default: 20. Minimum: 1. Maximum: 50
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first episode to return. Default: 0 (the first object).
    /// Use with limit to get the next set of episodes.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}
