using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public interface IHTTPClient : IDisposable
  {
    Task<IResponse> DoRequest(IRequest request, CancellationToken cancel = default);
    void SetRequestTimeout(TimeSpan timeout);
  }
}
