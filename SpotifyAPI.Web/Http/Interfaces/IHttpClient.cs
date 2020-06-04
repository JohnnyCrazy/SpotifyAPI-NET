using System;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public interface IHTTPClient : IDisposable
  {
    Task<IResponse> DoRequest(IRequest request);
    void SetRequestTimeout(TimeSpan timeout);
  }
}
