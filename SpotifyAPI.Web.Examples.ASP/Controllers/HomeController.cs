using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Examples.ASP.Models;

namespace SpotifyAPI.Web.Examples.ASP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            var claimsIdent = User.Identity as ClaimsIdentity;

            SpotifyWebAPI api = GetSpotifyApiFromUser(claimsIdent);
            if (api == null)
                return View(new HomeModel());
            
            string userId = claimsIdent.GetSpecificClaim("user_id");
            var playlists = await api.GetUserPlaylistsAsync(userId);
            return View(new HomeModel
            {
                Playlists = playlists
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private static SpotifyWebAPI GetSpotifyApiFromUser(ClaimsIdentity claimsIdent)
        {
            // TODO: Add expires_in logic

            string accessToken = claimsIdent.GetSpecificClaim("access_token");
            string tokenType = claimsIdent.GetSpecificClaim("token_type");
            return new SpotifyWebAPI
            {
                AccessToken = accessToken,
                TokenType = tokenType
            };
        }
    }
}