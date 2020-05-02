using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class ShowsRequest : RequestParams
  {
    public ShowsRequest(List<string> ids)
    {
      Ids = ids;
    }
    [QueryParam("ids")]
    public List<string> Ids { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNullOrEmptyList(Ids, nameof(Ids));
    }
  }
}
