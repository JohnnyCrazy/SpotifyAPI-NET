namespace SpotifyAPI.Web
{
  public class PlaylistCurrentUsersRequest : RequestParams
  {
    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

