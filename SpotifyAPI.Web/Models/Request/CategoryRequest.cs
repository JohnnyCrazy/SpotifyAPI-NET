namespace SpotifyAPI.Web
{
  public class CategoryRequest : RequestParams
  {
    /// <summary>
    /// A country: an ISO 3166-1 alpha-2 country code.
    /// Provide this parameter to ensure that the category exists for a particular country.
    /// </summary>
    /// <value></value>
    [QueryParam("country")]
    public string? Country { get; set; }

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
  }
}

