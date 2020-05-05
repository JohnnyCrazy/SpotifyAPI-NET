using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SpotifyAPI.Web.Http
{
  public class Request : IRequest
  {
    public Request()
    {
      Headers = new Dictionary<string, string>();
      Parameters = new Dictionary<string, string>();
    }

    public Request(IDictionary<string, string> headers)
    {
      Headers = headers;
      Parameters = new Dictionary<string, string>();
    }

    public Request(IDictionary<string, string> headers, IDictionary<string, string> parameters)
    {
      Headers = headers;
      Parameters = parameters;
    }

    public Uri BaseAddress { get; set; }

    public Uri Endpoint { get; set; }

    public IDictionary<string, string> Headers { get; }

    public IDictionary<string, string> Parameters { get; }

    public HttpMethod Method { get; set; }

    public object Body { get; set; }
  }
}
