using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpotifyAPI.Web;

namespace Example.ASP.Pages
{
  public class IndexModel : PageModel
  {
    private const int LIMIT = 10;
    private readonly SpotifyClientBuilder _spotifyClientBuilder;

    public Paging<SimplePlaylist> Playlists { get; set; }

    public string Next { get; set; }
    public string Previous { get; set; }

    public IndexModel(SpotifyClientBuilder spotifyClientBuilder)
    {
      _spotifyClientBuilder = spotifyClientBuilder;
    }

    public async Task OnGet()
    {
      var spotify = await _spotifyClientBuilder.BuildClient();

      int offset = int.TryParse(Request.Query["Offset"], out offset) ? offset : 0;
      var playlistRequest = new PlaylistCurrentUsersRequest
      {
        Limit = LIMIT,
        Offset = offset
      };
      Playlists = await spotify.Playlists.CurrentUsers(playlistRequest);

      if (Playlists.Next != null)
      {
        Next = Url.Page("Index", new { Offset = offset + LIMIT });
      }
      if (Playlists.Previous != null)
      {
        Previous = Url.Page("Index", values: new { Offset = offset - LIMIT });
      }
    }
  }
}
