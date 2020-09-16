---
id: retry_handling
title: Retry Handling
---

In [Error Handling](error_handling.md), we already found out that requests can fail. We provide a way to automatically retry requests via retry handlers. Note that, by default, no retries are performed.

```csharp
var config = SpotifyClientConfig
  .CreateDefault()
  .WithRetryHandler(new YourCustomRetryHandler())
```

[`IRetryHandler`](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Http/Interfaces/IRetryHandler.cs) only needs one function:

```csharp
public class YourCustomRetryHandler : IRetryHandler
{
  public Task<IResponse> HandleRetry(IRequest request, IResponse response, IRetryHandler.RetryFunc retry)
  {
    // request is the sent request and response is the received response, obviously

    // don't retry:
    return response;

    // retry once:
    var newResponse = retry(request);
    return newResponse;

    // use retry as often as you want, make sure to return a response
  }
}
```

## SimpleRetryHandler

A `SimpleRetryHandler` is included, which contains the following retry logic:

* Retries the (configurable) status codes: 500, 502, 503 and 429.
* `RetryAfter` - Specifies the delay between retried calls.
* `RetryTimes` - Specifies the maxiumum amount of performed retries per call.
* `TooManyRequestsConsumesARetry` - Whether a failure of type "Too Many Requests" should use up one of the retry attempts.

```csharp
var config = SpotifyClientConfig
  .CreateDefault()
  .WithRetryHandler(new SimpleRetryHandler() { RetryAfter = TimeSpan.FromSeconds(1) });

var spotify = new SpotifyClient(config);
```
