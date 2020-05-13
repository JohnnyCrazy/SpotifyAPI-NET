using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public interface IAuthenticator
  {
    Task Apply(IRequest request, IAPIConnector apiConnector);
  }
}
