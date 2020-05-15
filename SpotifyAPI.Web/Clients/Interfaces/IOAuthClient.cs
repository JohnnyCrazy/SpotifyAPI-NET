using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface IOAuthClient
  {
    Task<CredentialsTokenResponse> RequestToken(ClientCredentialsRequest request);
  }
}
