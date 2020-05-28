namespace SpotifyAPI.Web
{
  public class NewReleasesRequest : RequestParams
  {
    /// <summary>
    /// A country: an ISO 3166-1 alpha-2 country code.
    /// Provide this parameter if you want the list of returned items to be relevant to a particular country.
    /// If omitted, the returned items will be relevant to all countries.
    /// </summary>
    /// <value></value>
    [QueryParam("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first object).
    /// Use with limit to get the next set of items.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

