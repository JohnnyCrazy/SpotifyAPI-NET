namespace SpotifyAPI.Web
{
  public class ShowEpisodesRequest : RequestParams
  {
    /// <summary>
    /// The maximum number of episodes to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first episode to return.
    /// Default: 0 (the first object). Use with limit to get the next set of episodes.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code. If a country code is specified, only shows and episodes
    /// that are available in that market will be returned.
    /// If a valid user access token is specified in the request header,
    /// the country associated with the user account will take priority over this parameter.
    /// Note: If neither market or user country are provided, the content is considered unavailable for the client.
    /// Users can view the country that is associated with their account in the account settings.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

