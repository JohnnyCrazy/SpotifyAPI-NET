namespace SpotifyAPI.Web
{
  public class FollowedArtistsResponse
  {
    public CursorPaging<FullArtist, FollowedArtistsResponse> Artists { get; set; } = default!;
  }
}

