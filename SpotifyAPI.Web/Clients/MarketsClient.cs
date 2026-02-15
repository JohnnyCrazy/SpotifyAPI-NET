using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class MarketsClient : APIClient, IMarketsClient
  {
    public MarketsClient(IAPIConnector apiConnector) : base(apiConnector) { }

    [System.Obsolete("This endpoint (GET /markets) has been removed.")]
    public Task<AvailableMarketsResponse> AvailableMarkets(CancellationToken cancel = default)
    {
      return API.Get<AvailableMarketsResponse>(URLs.Markets(), cancel);
    }
  }
}
