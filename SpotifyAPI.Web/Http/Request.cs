using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SpotifyAPI.Web.Http
{
  class Request : IRequest
  {
    public Request()
    {
      Headers = new Dictionary<string, string>();
      Parameters = new Dictionary<string, string>();
    }

    public Uri BaseAddress { get; set; }

    public Uri Endpoint { get; set; }

    public IDictionary<string, string> Headers { get; set; }

    public IDictionary<string, string> Parameters { get; set; }

    public HttpMethod Method { get; set; }

    public string ContentType { get; set; }

    public object Body { get; set; }
  }
}
