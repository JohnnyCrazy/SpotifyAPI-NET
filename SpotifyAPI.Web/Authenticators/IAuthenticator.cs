using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public interface IAuthenticator
  {
    Task Apply(IRequest request, IAPIConnector apiConnector);
  }
}
