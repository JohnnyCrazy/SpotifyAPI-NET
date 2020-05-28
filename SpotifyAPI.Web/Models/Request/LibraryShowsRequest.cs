namespace SpotifyAPI.Web
{
  public class LibraryShowsRequest : RequestParams
  {
    /// <summary>
    /// The maximum number of shows to return. Default: 20. Minimum: 1. Maximum: 50
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first show to return. Default: 0 (the first object).
    /// Use with limit to get the next set of shows.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

