using System;
using System.Globalization;
using System.Runtime.Serialization;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [Serializable]
  public class APIPagingException : APIException
  {
    public TimeSpan RetryAfter { get; }

    public APIPagingException(IResponse response) : base(response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      if (response.Headers.TryGetValue("Retry-After", out string? retryAfter))
      {
        RetryAfter = TimeSpan.FromSeconds(int.Parse(retryAfter, CultureInfo.InvariantCulture));
      }
    }

    public APIPagingException() { }

    public APIPagingException(string message) : base(message) { }

    public APIPagingException(string message, Exception innerException) : base(message, innerException) { }

    protected APIPagingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
