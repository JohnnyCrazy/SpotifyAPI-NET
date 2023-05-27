namespace SpotifyAPI.Web
{
  public class CategoryPlaylistsResponse
  {
    public Paging<FullPlaylist, CategoryPlaylistsResponse> Playlists { get; set; } = default!;
  }
}

