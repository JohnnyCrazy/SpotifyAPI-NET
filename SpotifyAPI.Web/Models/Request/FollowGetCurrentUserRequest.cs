namespace SpotifyAPI.Web
{
  public class FollowOfCurrentUserRequest : RequestParams
  {
    public FollowOfCurrentUserRequest()
    {
      Type = Types.Artist;
    }


    [QueryParam("type")]
    public Types Type { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("after")]
    public string After { get; set; }

    public enum Types
    {
      [String("artist")]
      Artist
    }
  }
}
