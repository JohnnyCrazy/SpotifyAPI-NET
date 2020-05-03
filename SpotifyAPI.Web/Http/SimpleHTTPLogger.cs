using System.Linq;
using System;

namespace SpotifyAPI.Web.Http
{
  public class SimpleHTTPLogger : IHTTPLogger
  {
    public void OnRequest(IRequest request)
    {
      string parameters = null;
      if (request.Parameters != null)
      {
        parameters = string.Join(",", request.Parameters?.Select(kv => kv.Key + "=" + kv.Value).ToArray());
      }
      Console.WriteLine("\n{0} {1} [{2}] {3}", request.Method, request.Endpoint, parameters, request.Body);
    }

    public void OnResponse(IResponse response)
    {
      string body = response.Body?.ToString().Replace("\n", "");
      body = body?.Substring(0, Math.Min(50, body?.Length ?? 0));
      Console.WriteLine("--> {0} {1} {2}\n", response.StatusCode, response.ContentType, body);
    }
  }
}
