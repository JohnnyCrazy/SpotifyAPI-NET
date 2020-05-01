using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [System.Serializable]
  public class APIException : System.Exception
  {
    public APIException(IResponse response) : base(ParseAPIErrorMessage(response))
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      Response = response;
    }

    private static string ParseAPIErrorMessage(IResponse response)
    {
      var body = response.Body as string;
      if (string.IsNullOrEmpty(body))
      {
        return null;
      }
      try
      {
        JObject bodyObject = JObject.Parse(body);
        JObject error = bodyObject.Value<JObject>("error");
        if (error != null)
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

    public IResponse Response { get; set; }
  }
}
