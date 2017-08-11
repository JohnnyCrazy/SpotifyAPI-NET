using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.ExampleWeb.Extensions;

namespace SpotifyAPI.ExampleWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult SignIn() => View("SignIn", HttpContext.GetExternalProviders());

        [HttpPost]
        public IActionResult SignIn([FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!HttpContext.IsProviderSupported(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") }, provider);
        }

        [HttpGet, HttpPost]
        public IActionResult SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            var result = SignOut(new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") }, CookieAuthenticationDefaults.AuthenticationScheme);
            return result;
        }
    }
}
