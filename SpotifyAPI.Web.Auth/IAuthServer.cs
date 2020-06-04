using System;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Auth
{
  public interface IAuthServer : IDisposable
  {
    event Func<object, AuthorizationCodeResponse, Task> AuthorizationCodeReceived;

    event Func<object, ImplictGrantResponse, Task> ImplictGrantReceived;

    Task Start();
    Task Stop();

    Uri BaseUri { get; }
  }
}
