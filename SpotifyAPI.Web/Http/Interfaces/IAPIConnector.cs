using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public interface IAPIConnector
  {
    // IAuthenticator Authenticator { get; }

    // IJSONSerializer JSONSerializer { get; }

    // IHTTPClient HTTPClient { get; }

    event EventHandler<IResponse>? ResponseReceived;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<T> Get<T>(Uri uri, CancellationToken cancel = default);
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<HttpStatusCode> Get(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

    Task<T> Post<T>(Uri uri, CancellationToken cancel = default);
    Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);
    Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);
    Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, Dictionary<string, string>? headers, CancellationToken cancel = default);
    Task<HttpStatusCode> Post(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

    Task<T> Put<T>(Uri uri, CancellationToken cancel = default);
    Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);
    Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);
    Task<HttpStatusCode> Put(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);
    Task<HttpStatusCode> PutRaw(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

    Task<T> Delete<T>(Uri uri, CancellationToken cancel = default);
    Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);
    Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);
    Task<HttpStatusCode> Delete(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

    Task<T> SendAPIRequest<T>(
      Uri uri, HttpMethod method,
      IDictionary<string, string>? parameters = null,
      object? body = null,
      IDictionary<string, string>? headers = null,
      CancellationToken cancel = default);

    void SetRequestTimeout(TimeSpan timeout);
  }
}
