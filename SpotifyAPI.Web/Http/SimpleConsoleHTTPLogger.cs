using System;
using System.Linq;

namespace SpotifyAPI.Web.Http
{
  public class SimpleConsoleHTTPLogger : IHTTPLogger
  {
    private const string OnRequestFormat = "\n{0} {1} [{2}] {3}";

    public void OnRequest(IRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      string? parameters = null;
      if (request.Parameters != null)
      {
        parameters = string.Join(",",
          request.Parameters.Select(kv => kv.Key + "=" + kv.Value)?.ToArray() ?? Array.Empty<string>()
        );
      }

      Console.WriteLine(OnRequestFormat, request.Method, request.Endpoint, parameters, request.Body);
    }

    public void OnResponse(IResponse response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));
#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
      string? body = response.Body?.ToString()?.Replace("\n", "", StringComparison.InvariantCulture);
#else
      string? body = response.Body?.ToString()?.Replace("\n", "");
#endif
      body = body?.Substring(0, Math.Min(50, body.Length));
      Console.WriteLine("--> {0} {1} {2}\n", response.StatusCode, response.ContentType, body);
    }
  }
}
