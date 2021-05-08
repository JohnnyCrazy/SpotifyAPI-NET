using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibrarySaveEpisodesRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="uris">A comma-separated list of Spotify URIs for the shows to be added to the user’s library.</param>
    public LibrarySaveEpisodesRequest(IList<string> uris)
    {
      Ensure.ArgumentNotNullOrEmptyList(uris, nameof(uris));

      URIs = uris;
    }

    /// <summary>
    /// A comma-separated list of Spotify URIs for the shows to be added to the user’s library.
    /// </summary>
    /// <value></value>
    [QueryParam("uRIs")]
    public IList<string> URIs { get; }
  }
}
