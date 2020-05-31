using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TracksAudioFeaturesRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">A comma-separated list of the Spotify IDs for the tracks. Maximum: 100 IDs.</param>
    public TracksAudioFeaturesRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of the Spotify IDs for the tracks. Maximum: 100 IDs.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

