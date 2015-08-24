using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Local;

namespace SpotifyMVC.Example.Controllers
{
    public class SpotifyController : Controller
    {
        private static readonly SpotifyLocalAPI Spotify;

        static SpotifyController()
        {
            Spotify = new SpotifyLocalAPI();
            Spotify.Connect();
        }


        // GET: Spotify
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Play()
        {
            await Spotify.Play();
            return View("Index");
        }

        public async Task<ActionResult> Pause()
        {
            await Spotify.Pause();
            return View("Index");
        }
    }
}