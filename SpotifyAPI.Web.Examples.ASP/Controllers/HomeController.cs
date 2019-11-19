using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web.Examples.ASP.Models;

namespace SpotifyAPI.Web.Examples.ASP.Controllers
{
    [Authorize(AuthenticationSchemes = "Spotify")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("Spotify", "access_token");
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = accessToken,
                TokenType = "Bearer"
            };

            var savedTracks = await api.GetSavedTracksAsync(50);

            return View(new IndexModel { SavedTracks = savedTracks });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
