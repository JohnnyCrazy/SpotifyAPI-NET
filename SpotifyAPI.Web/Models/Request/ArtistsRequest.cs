using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class ArtistsRequest : RequestParams
  {
    /// <summary>
    /// ArtistsRequest
    /// </summary>
    /// <param name="ids">A comma-separated list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
    public ArtistsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the artists. Maximum: 50 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

