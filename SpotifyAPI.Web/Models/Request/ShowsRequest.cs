using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class ShowsRequest : RequestParams
  {
    public ShowsRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    [QueryParam("ids")]
    public IList<string> Ids { get; }

    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

