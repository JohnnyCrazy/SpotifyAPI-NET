namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsResponse
  {
    public string Message { get; set; } = default!;
    public Paging<FullPlaylist, FeaturedPlaylistsResponse> Playlists { get; set; } = default!;
  }
}

