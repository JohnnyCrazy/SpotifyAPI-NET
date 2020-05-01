using System.Collections.Generic;
using System.Net;

namespace SpotifyAPI.Web.Http
{
  public interface IResponse
  {
    object Body { get; }

    IReadOnlyDictionary<string, string> Headers { get; }

    HttpStatusCode StatusCode { get; }

    string ContentType { get; }
  }
}
