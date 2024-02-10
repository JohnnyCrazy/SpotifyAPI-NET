using System;
using System.Runtime.Serialization;

namespace SpotifyAPI.Web.Auth
{
  [Serializable]
  public class AuthException : Exception
  {
    public AuthException(string? error, string? state)
    {
      Error = error;
      State = state;
    }
    public AuthException(string message) : base(message) { }
    public AuthException(string message, Exception inner) : base(message, inner) { }

#if NET8_0_OR_GREATER
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.")]
#endif
    protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public string? Error { get; set; }
    public string? State { get; set; }
  }
}
