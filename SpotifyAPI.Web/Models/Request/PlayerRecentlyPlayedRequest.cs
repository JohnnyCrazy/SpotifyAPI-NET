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
    /// The desired language, consisting of an ISO 639-1 language code and an ISO 3166-1 alpha-2 country code,
    /// joined by an underscore. For example: es_MX, meaning "Spanish (Mexico)".
    /// Provide this parameter if you want the category strings returned in a particular language.
    /// Note that, if locale is not supplied, or if the specified language is not available,
    /// the category strings returned will be in the Spotify default language (American English).
    /// </summary>
    /// <value></value>
    [QueryParam("locale")]
    public string? Locale { get; set; }

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

