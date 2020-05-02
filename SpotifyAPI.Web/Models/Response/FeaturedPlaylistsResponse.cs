namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsResponse
  {
    public string Message { get; set; }
    public Paging<SimplePlaylist> Playlists { get; set; }
  }
}
