using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IOAuthClient
  {
    Task<TokenResponse> RequestToken(ClientCredentialsRequest request);
  }
}
