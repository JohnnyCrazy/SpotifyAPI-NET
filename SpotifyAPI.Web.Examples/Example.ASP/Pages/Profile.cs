using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpotifyAPI.Web;

namespace Example.ASP.Pages
{
  public class ProfileModel : PageModel
  {
    private readonly SpotifyClientBuilder _spotifyClientBuilder;
    public ProfileModel(SpotifyClientBuilder spotifyClientBuilder)
    {
      _spotifyClientBuilder = spotifyClientBuilder;
    }

    public PrivateUser Me { get; set; }

    public async Task OnGet()
    {
      var spotify = await _spotifyClientBuilder.BuildClient();

      Me = await spotify.UserProfile.Current();
    }

    public async Task<IActionResult> OnPost()
    {
      await HttpContext.SignOutAsync();
      return Redirect("https://google.com");
    }
  }
}
