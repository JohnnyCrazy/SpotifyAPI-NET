namespace SpotifyAPI.Web
{
  public class CategoriesRequest : RequestParams
  {
    /// <summary>
    /// A country: an ISO 3166-1 alpha-2 country code.
    /// Provide this parameter if you want to narrow the list of returned categories to those relevant to a particular country.
    /// If omitted, the returned items will be globally relevant.
    /// </summary>
    /// <value></value>
    [QueryParam("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The desired language, consisting of an ISO 639-1 language code and an ISO 3166-1 alpha-2 country code,
    /// joined by an underscore. For example: es_MX, meaning “Spanish (Mexico)”. Provide this parameter if
    /// you want the category metadata returned in a particular language.
    /// Note that, if locale is not supplied, or if the specified language is not available, all strings will
    /// be returned in the Spotify default language (American English).
    /// The locale parameter, combined with the country parameter, may give odd results if not carefully matched.
    /// For example country=SE&amp;locale=de_DE will return a list of categories relevant to Sweden but as German language strings.
    /// </summary>
    /// <value></value>
    [QueryParam("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first object). Use with limit to get the next set of categories.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

