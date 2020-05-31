using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class ShowsRequest : RequestParams
  {
    /// <summary>
    /// Get Spotify catalog information for several shows based on their Spotify IDs.
    /// </summary>
    /// <param name="ids">
    /// A comma-separated list of the Spotify IDs for the shows. Maximum: 50 IDs.
    /// </param>
    public ShowsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the shows. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code. If a country code is specified, only shows and episodes
    /// that are available in that market will be returned.
    /// If a valid user access token is specified in the request header,
    /// the country associated with the user account will take priority over this parameter.
    /// Note: If neither market or user country are provided,
    /// the content is considered unavailable for the client.
    /// Users can view the country that is associated with their account in the account settings.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

