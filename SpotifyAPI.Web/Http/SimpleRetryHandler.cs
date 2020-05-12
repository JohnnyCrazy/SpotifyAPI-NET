using System.Linq;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Http
{
  public class SimpleRetryHandler : IRetryHandler
  {
    private readonly Func<int, Task> _sleep;

    /// <summary>
    ///     Specifies after how many miliseconds should a failed request be retried.
    /// </summary>
    public int RetryAfter { get; set; }

    /// <summary>
    ///     Maximum number of tries for one failed request.
    /// </summary>
    public int RetryTimes { get; set; }

    /// <summary>
    ///     Whether a failure of type "Too Many Requests" should use up one of the allocated retry attempts.
    /// </summary>
    public bool TooManyRequestsConsumesARetry { get; set; }

    /// <summary>
    ///     Error codes that will trigger auto-retry
    /// </summary>
    public IEnumerable<HttpStatusCode> RetryErrorCodes { get; set; }

    /// <summary>
    ///   A simple retry handler which retries a request based on status codes with a fixed sleep interval.
    ///   It also supports Retry-After headers sent by spotify. The execution will be delayed by the amount in
    ///   the Retry-After header
    /// </summary>
    /// <returns></returns>
    public SimpleRetryHandler() : this(Task.Delay) { }
    public SimpleRetryHandler(Func<int, Task> sleep)
    {
      _sleep = sleep;
      RetryAfter = 50;
      RetryTimes = 10;
      TooManyRequestsConsumesARetry = false;
      RetryErrorCodes = new[] {
        HttpStatusCode.InternalServerError,
        HttpStatusCode.BadGateway,
        HttpStatusCode.ServiceUnavailable
      };
    }

    private static int? ParseTooManyRetriesToMs(IResponse response)
    {
      if (response.StatusCode != HttpStatusCode.TooManyRequests)
      {
        return null;
      }
      if (int.TryParse(response.Headers["Retry-After"], out int secondsToWait))
      {
        return secondsToWait * 1000;
      }

      throw new APIException("429 received, but unable to parse Retry-After Header. This should not happen!");
    }

    public Task<IResponse> HandleRetry(IRequest request, IResponse response, Func<IRequest, Task<IResponse>> retry)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      return HandleRetryInternally(request, response, retry, RetryTimes);
    }

    private async Task<IResponse> HandleRetryInternally(IRequest request, IResponse response, Func<IRequest, Task<IResponse>> retry, int triesLeft)
    {
      var secondsToWait = ParseTooManyRetriesToMs(response);
      if (secondsToWait != null && (!TooManyRequestsConsumesARetry || triesLeft > 0))
      {
        await _sleep(secondsToWait.Value).ConfigureAwait(false);
        response = await retry(request).ConfigureAwait(false);
        var newTriesLeft = TooManyRequestsConsumesARetry ? triesLeft - 1 : triesLeft;
        return await HandleRetryInternally(request, response, retry, newTriesLeft).ConfigureAwait(false);
      }

      while (RetryErrorCodes.Contains(response.StatusCode) && triesLeft > 0)
      {
        await _sleep(RetryAfter).ConfigureAwait(false);
        response = await retry(request).ConfigureAwait(false);
        return await HandleRetryInternally(request, response, retry, triesLeft - 1).ConfigureAwait(false);
      }

      return response;
    }
  }
}
