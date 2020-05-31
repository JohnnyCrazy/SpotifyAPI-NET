using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TracksRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">A comma-separated list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
    public TracksRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

