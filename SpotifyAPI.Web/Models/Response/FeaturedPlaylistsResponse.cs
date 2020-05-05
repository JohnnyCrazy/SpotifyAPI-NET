namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsResponse
  {
    public string Message { get; private set; }
    public Paging<SimplePlaylist> Playlists { get; private set; }
  }
}
