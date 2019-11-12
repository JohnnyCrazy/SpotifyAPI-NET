using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Examples.ASP.Models;
using SpotifyAPI.Web.Models;
using Microsoft.Extensions.Configuration;

namespace SpotifyAPI.Web.Examples.ASP.Controllers
{
    public class Auth : Controller
    {
        public IConfiguration Configuration { get; set; }

        public Auth(IConfiguration config)
        {
            Configuration = config;
        }
        
        private static Dictionary<string, AuthorizationCodeAuth> LoginRequests { get; } = new Dictionary<string, AuthorizationCodeAuth>();
        
        // GET
        public IActionResult Login()
        {
            string guid = Guid.NewGuid().ToString();
            var auth = new AuthorizationCodeAuth( // TODO: Extract to own method
                Configuration["spotify_client_id"], Configuration["spotify_client_secret"],
                "http://localhost:5000/auth/callback", "", Scope.PlaylistReadPrivate | Scope.PlaylistReadPrivate, guid);
            
            LoginRequests.Add(guid, auth); // TODO: Clean up after a timeout, else: DOS possible

            return Redirect(auth.GetUri());
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Callback([FromQuery(Name = "code")] string code, [FromQuery(Name = "state")] string state,
            [FromQuery(Name = "error")] string error)
        {
            if (error != null)
                return View("Error", new ErrorViewModel { Message = error, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
            
            if(!LoginRequests.ContainsKey(state))
                return View("Error", new ErrorViewModel { Message = "Unknown login request", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

            AuthorizationCodeAuth auth = LoginRequests[state];
            Token token = await auth.ExchangeCode(code);

            if (token.HasError())
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        Message = $"Unable to exchange Code: ${token.Error}",
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }
            
            var api = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            PrivateProfile profile = await api.GetPrivateProfileAsync();
            
            var claims = new List<Claim>
            {
                // TODO: Extract claim types to either Enum or class
                new Claim("user_id", profile.Id),
                new Claim("display_name", profile.DisplayName ?? profile.Id),
                new Claim("access_token", token.AccessToken),
                new Claim("token_type", token.TokenType),
                new Claim("refresh_token", token.RefreshToken),
                new Claim("expires_in", token.ExpiresIn.ToString(CultureInfo.InvariantCulture))
            };
            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user_id", "")));

            return Redirect("/");
        }
    }
}