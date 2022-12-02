namespace SpotifyAPI.Web
{
  public class ArtistsTopTracksRequest : RequestParams
  {
    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token. Synonym for country.
    /// </summary>
    /// <param name="market"></param>
    public ArtistsTopTracksRequest(string market)
    {
      Ensure.ArgumentNotNullOrEmptyString(market, nameof(market));

      Market = market;
    }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token. Synonym for country.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string Market { get; }

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

