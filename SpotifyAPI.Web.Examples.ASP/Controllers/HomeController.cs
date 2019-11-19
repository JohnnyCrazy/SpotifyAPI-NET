using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web.Examples.ASP.Models;

namespace SpotifyAPI.Web.Examples.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if(!User.Identity.IsAuthenticated)
                return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Spotify");

            var accessToken = await HttpContext.GetTokenAsync("Spotify", "access_token");
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = accessToken,
                TokenType = "Bearer"
            };

            var savedTracks = await api.GetSavedTracksAsync(50);

            return View(new IndexModel { SavedTracks = savedTracks });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
