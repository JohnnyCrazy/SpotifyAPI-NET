namespace SpotifyAPI.Web
{
  public class CategoryPlaylistsResponse
  {
    public Paging<SimplePlaylist, CategoryPlaylistsResponse> Playlists { get; set; } = default!;
  }
}

