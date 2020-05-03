using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetRequest : RequestParams
  {
    public PlaylistGetRequest()
    {
      AdditionalTypes = new List<string> { "track", "episode" };
    }

    /// <summary>
    ///   This is set to `"track", "episode"` by default.
    /// </summary>
    /// <value></value>
    [QueryParam("additional_types")]
    public List<string> AdditionalTypes { get; set; }
  }
}
