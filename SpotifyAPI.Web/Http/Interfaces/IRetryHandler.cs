using System;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  /// <summary>
  ///   The Retry Handler will be directly called after the response is retrived and before errors and body are processed.
  /// </summary>
  public interface IRetryHandler
  {
    Task<IResponse> HandleRetry(IRequest request, IResponse response, Func<IRequest, Task<IResponse>> retry);
  }
}
