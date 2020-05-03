using System.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public interface IAPIConnector
  {
    // IAuthenticator Authenticator { get; }

    // IJSONSerializer JSONSerializer { get; }

    // IHTTPClient HTTPClient { get; }

    Task<T> Get<T>(Uri uri);
    Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters);

    Task<T> Post<T>(Uri uri);
    Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters);
    Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters, object body);

    Task<T> Put<T>(Uri uri);
    Task<T> Put<T>(Uri uri, IDictionary<string, string> parameters);
    Task<T> Put<T>(Uri uri, IDictionary<string, string> parameters, object body);
    Task<HttpStatusCode> PutRaw(Uri uri, IDictionary<string, string> parameters, object body);

    Task<T> Delete<T>(Uri uri);
    Task<T> Delete<T>(Uri uri, IDictionary<string, string> parameters);
    Task<T> Delete<T>(Uri uri, IDictionary<string, string> parameters, object body);

    Task<T> SendAPIRequest<T>(Uri uri, HttpMethod method, IDictionary<string, string> parameters = null, object body = null);

    void SetRequestTimeout(TimeSpan timeout);
  }
}
