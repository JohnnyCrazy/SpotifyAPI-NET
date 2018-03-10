using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace SpotifyAPI.ExampleWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = await HttpContext.Authentication.GetTokenAsync("access_token");
            if (!string.IsNullOrEmpty(token))
            {
                var spotifyWebApi = new SpotifyWebAPI
                {
                    UseAuth = true,
                    AccessToken = token,
                    TokenType = "Bearer",
                };
                var profile = await spotifyWebApi.GetPrivateProfile();
                ViewData["SpotifUserDisplayName"] = profile?.DisplayName;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
