using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace SpotifyAPI.Web.Http
{
  public class APIConnector : IAPIConnector
  {
    private Uri _baseAddress;
    private IAuthenticator _authenticator;
    private IJSONSerializer _jsonSerializer;
    private IHTTPClient _httpClient;

    public APIConnector(Uri baseAddress, IAuthenticator authenticator) :
      this(baseAddress, authenticator, new NewtonsoftJSONSerializer(), new NetHttpClient())
    { }
    public APIConnector(Uri baseAddress, IAuthenticator authenticator, IJSONSerializer jsonSerializer, IHTTPClient httpClient)
    {
      _baseAddress = baseAddress;
      _authenticator = authenticator;
      _jsonSerializer = jsonSerializer;
      _httpClient = httpClient;
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

    private async Task<T> SendAPIRequest<T>(
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
        ContentType = "application/json",
        Parameters = parameters,
        Endpoint = uri,
        Method = method
      };

      _jsonSerializer.SerializeRequest(request);
      await _authenticator.Apply(request).ConfigureAwait(false);
      IResponse response = await _httpClient.DoRequest(request).ConfigureAwait(false);
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

      switch (response.StatusCode)
      {
        case HttpStatusCode.Unauthorized:
          throw new APIUnauthorizedException(response);
        default:
          throw new APIException(response);
      }
    }
  }
}
