using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  /// <summary>
  ///   The Retry Handler will be directly called after the response is retrived and before errors and body are processed.
  /// </summary>
  public interface IRetryHandler
  {
    delegate Task<IResponse> RetryFunc(IRequest request, CancellationToken cancel = default);

    Task<IResponse> HandleRetry(IRequest request, IResponse response, RetryFunc retry, CancellationToken cancel = default);
  }
}
