using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifyAPI.Web.Http
{
  public class NewtonsoftJSONSerializer : IJSONSerializer
  {
    private readonly JsonSerializerSettings _serializerSettings;

    public NewtonsoftJSONSerializer()
    {
      _serializerSettings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
          NamingStrategy = new SnakeCaseNamingStrategy()
        }
      };
    }

    public IAPIResponse<T> DeserializeResponse<T>(IResponse response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      if (response.ContentType?.Equals("application/json", StringComparison.Ordinal) is true || response.ContentType == null)
      {
        var body = JsonConvert.DeserializeObject<T>(response.Body as string, _serializerSettings);
        return new APIResponse<T>(response, body);
      }
      return new APIResponse<T>(response);
    }

    public void SerializeRequest(IRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      if (request.Body is string || request.Body is Stream || request.Body is HttpContent || request.Body is null)
      {
        return;
      }

      request.Body = JsonConvert.SerializeObject(request.Body, _serializerSettings);
    }
  }
}
