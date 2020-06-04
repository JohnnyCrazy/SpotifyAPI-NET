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
  }
}

