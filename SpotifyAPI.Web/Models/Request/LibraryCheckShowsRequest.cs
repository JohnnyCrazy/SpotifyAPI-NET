using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryCheckShowsRequest : RequestParams
  {
    public LibraryCheckShowsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNull(ids, nameof(ids));

      Ids = ids;
    }

    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}
