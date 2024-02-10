using System;
using System.Runtime.Serialization;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [Serializable]
  public class APIUnauthorizedException : APIException
  {
    public APIUnauthorizedException(IResponse response) : base(response) { }

    public APIUnauthorizedException() { }

    public APIUnauthorizedException(string message) : base(message) { }

    public APIUnauthorizedException(string message, Exception innerException) : base(message, innerException) { }

#if NET8_0_OR_GREATER
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.")]
#endif
    protected APIUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
