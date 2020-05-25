namespace SpotifyAPI.Web
{
  public class FollowPlaylistRequest : RequestParams
  {
    [BodyParam("public")]
    public bool? Public { get; set; }
  }
}

