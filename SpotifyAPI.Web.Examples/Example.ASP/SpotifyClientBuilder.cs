using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;

namespace Example.ASP
{
  public class SpotifyClientBuilder
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SpotifyClientConfig _spotifyClientConfig;

    public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig)
    {
      _httpContextAccessor = httpContextAccessor;
      _spotifyClientConfig = spotifyClientConfig;
    }

    public async Task<SpotifyClient> BuildClient()
    {
      var token = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");

      return new SpotifyClient(_spotifyClientConfig.WithToken(token));
    }
  }
}
