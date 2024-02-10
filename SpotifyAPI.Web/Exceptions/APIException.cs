using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [Serializable]
  public class APIException : Exception
  {
    public IResponse? Response { get; set; }

    public APIException(IResponse response) : base(ParseAPIErrorMessage(response))
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      Response = response;
    }

    public APIException()
    {
    }

    public APIException(string message) : base(message)
    {
    }

    public APIException(string message, Exception innerException) : base(message, innerException)
    {
    }

#if NET8_0_OR_GREATER
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.")]
#endif
    protected APIException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
      Response = info.GetValue("APIException.Response", typeof(IResponse)) as IResponse;
    }

    private static string? ParseAPIErrorMessage(IResponse response)
    {
      var body = response.Body as string;
      if (string.IsNullOrEmpty(body))
      {
        return null;
      }
      try
      {
        JObject bodyObject = JObject.Parse(body!);

        var error = bodyObject.Value<JToken>("error");
        if (error == null)
        {
          return null;
        }
        else if (error.Type == JTokenType.String)
        {
          return error.ToString();
        }
        else if (error.Type == JTokenType.Object)
        {
          return error.Value<string>("message");
        }
      }
      catch (JsonReaderException)
      {
        return null;
      }
      return null;
    }



#if NET8_0_OR_GREATER
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.")]
#endif
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("APIException.Response", Response);
    }
  }
}
