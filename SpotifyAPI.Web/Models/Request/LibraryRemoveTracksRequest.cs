using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryRemoveTracksRequest : RequestParams
  {
    public LibraryRemoveTracksRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    [BodyParam("ids")]
    public IList<string> Ids { get; }
  }
}
