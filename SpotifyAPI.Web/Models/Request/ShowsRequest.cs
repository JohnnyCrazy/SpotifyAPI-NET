using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class ShowsRequest : RequestParams
  {
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
