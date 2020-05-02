using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace SpotifyAPI.Web.Http
{
  public class APIConnector : IAPIConnector
  {
    private readonly Uri _baseAddress;
    private readonly IAuthenticator _authenticator;
    private readonly IJSONSerializer _jsonSerializer;
    private readonly IHTTPClient _httpClient;
    private readonly IRetryHandler _retryHandler;

    public APIConnector(Uri baseAddress, IAuthenticator authenticator) :
      this(baseAddress, authenticator, new NewtonsoftJSONSerializer(), new NetHttpClient(), null)
    { }
    public APIConnector(
      Uri baseAddress,
      IAuthenticator authenticator,
      IJSONSerializer jsonSerializer,
      IHTTPClient httpClient,
      IRetryHandler retryHandler)
    {
      _baseAddress = baseAddress;
      _authenticator = authenticator;
      _jsonSerializer = jsonSerializer;
      _httpClient = httpClient;
      _retryHandler = retryHandler;
    }

    public Task<T> Delete<T>(Uri uri)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete);
    }

    public Task<T> Delete<T>(Uri uri, IDictionary<string, string> parameters)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete, parameters);
    }

    public Task<T> Delete<T>(Uri uri, IDictionary<string, string> parameters, object body)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete, parameters, body);
    }

    public Task<T> Get<T>(Uri uri)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Get);
    }

    public Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Get, parameters);
    }

    public Task<T> Post<T>(Uri uri)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post);
    }

    public Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post, parameters);
    }

    public Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters, object body)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Get, parameters, body);
    }

    public Task<T> Put<T>(Uri uri)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put);
    }

    public Task<T> Put<T>(Uri uri, IDictionary<string, string> parameters)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put, parameters);
    }

    public Task<T> Put<T>(Uri uri, IDictionary<string, string> parameters, object body)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put, parameters, body);
    }

    public void SetRequestTimeout(TimeSpan timeout)
    {
      _httpClient.SetRequestTimeout(timeout);
    }

    public async Task<T> SendAPIRequest<T>(
        Uri uri,
        HttpMethod method,
        IDictionary<string, string> parameters = null,
        object body = null
      )
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));
      Ensure.ArgumentNotNull(method, nameof(method));

      var request = new Request
      {
        BaseAddress = _baseAddress,
        Parameters = parameters,
        Endpoint = uri,
        Method = method,
        Body = body
      };

      _jsonSerializer.SerializeRequest(request);
      await _authenticator.Apply(request).ConfigureAwait(false);
      IResponse response = await _httpClient.DoRequest(request).ConfigureAwait(false);
      if (_retryHandler != null)
      {
        response = await _retryHandler?.HandleRetry(request, response, async (newRequest) =>
        {
          await _authenticator.Apply(newRequest).ConfigureAwait(false);
          return await _httpClient.DoRequest(request).ConfigureAwait(false);
        });
      }
      ProcessErrors(response);

      IAPIResponse<T> apiResponse = _jsonSerializer.DeserializeResponse<T>(response);
      return apiResponse.Body;
    }

    private void ProcessErrors(IResponse response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 400)
      {
        return;
      }

      throw response.StatusCode switch
      {
        HttpStatusCode.Unauthorized => new APIUnauthorizedException(response),
        _ => new APIException(response),
      };
    }
  }
}
