namespace SpotifyAPI.Web
{
  public class ArtistsTopTracksRequest : RequestParams
  {
    public ArtistsTopTracksRequest(string market)
    {
      Ensure.ArgumentNotNullOrEmptyString(market, nameof(market));

      Market = market;
    }

    [QueryParam("market")]
    public string Market { get; }
  }
}

