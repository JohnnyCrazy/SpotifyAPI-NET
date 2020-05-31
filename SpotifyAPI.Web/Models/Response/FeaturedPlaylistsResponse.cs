namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsResponse
  {
    public string Message { get; set; } = default!;
    public Paging<SimplePlaylist, FeaturedPlaylistsResponse> Playlists { get; set; } = default!;
  }
}

