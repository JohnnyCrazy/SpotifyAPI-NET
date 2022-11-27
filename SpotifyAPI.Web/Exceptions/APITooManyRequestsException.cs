using System;
using System.Globalization;
using System.Runtime.Serialization;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [Serializable]
  public class APITooManyRequestsException : APIException
  {
    public TimeSpan RetryAfter { get; }

    public APITooManyRequestsException(IResponse response) : base(response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      if (response.Headers.TryGetValue("Retry-After", out string? retryAfter))
      {
        RetryAfter = TimeSpan.FromSeconds(int.Parse(retryAfter, CultureInfo.InvariantCulture));
      }
    }

    public APITooManyRequestsException() { }

    public APITooManyRequestsException(string message) : base(message) { }

    public APITooManyRequestsException(string message, Exception innerException) : base(message, innerException) { }

    protected APITooManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
