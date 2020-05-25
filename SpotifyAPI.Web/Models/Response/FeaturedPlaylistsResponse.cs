namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsResponse
  {
    public string Message { get; set; } = default!;
    public Paging<SimplePlaylist> Playlists { get; set; } = default!;
  }
}

