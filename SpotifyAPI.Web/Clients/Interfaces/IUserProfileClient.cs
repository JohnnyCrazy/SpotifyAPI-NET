using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
  public interface IUserProfileClient
  {
    /// <summary>
    ///   Test
    /// </summary>
    /// <exception cref="APIUnauthorizedException">Thrown if the client is not authenticated.</exception>
    /// <returns>A <see cref="PrivateUser"/></returns>
    Task<PrivateUser> Current();


    /// <summary>
    ///
    /// </summary>
    /// <param name="userId"></param>
    /// <exception cref="APIUnauthorizedException">Thrown if the client is not authenticated.</exception>
    /// <returns></returns>
    Task<PublicUser> Get(string userId);
  }
}
