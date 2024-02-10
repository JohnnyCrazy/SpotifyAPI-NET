namespace SpotifyAPI.Web
{
  public class FollowOfCurrentUserRequest : RequestParams
  {
    /// <summary>
    /// The ID type: currently only artist is supported.
    /// </summary>
    /// <param name="type"></param>
    public FollowOfCurrentUserRequest(Type type = Type.Artist)
    {
      TypeParam = type;
    }

    /// <summary>
    /// The ID type: currently only artist is supported.
    /// </summary>
    /// <value></value>
    [QueryParam("type")]
    public Type TypeParam { get; set; }

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
    /// The last artist ID retrieved from the previous request.
    /// </summary>
    /// <value></value>
    [QueryParam("after")]
    public string? After { get; set; }

    public enum Type
    {
      [String("artist")]
      Artist
    }
  }
}

