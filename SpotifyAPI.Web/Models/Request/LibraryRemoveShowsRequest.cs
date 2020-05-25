using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class LibraryRemoveShowsRequest : RequestParams
  {
    public LibraryRemoveShowsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    [BodyParam("ids")]
    public IList<string> Ids { get; }
  }
}

