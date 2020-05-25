using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryRemoveAlbumsRequest : RequestParams
  {
    public LibraryRemoveAlbumsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    [BodyParam("ids")]
    public IList<string> Ids { get; }
  }
}

