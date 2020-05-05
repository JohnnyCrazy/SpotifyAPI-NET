namespace SpotifyAPI.Web
{
  public class FollowOfCurrentUserRequest : RequestParams
  {
    public FollowOfCurrentUserRequest(Type type = Type.Artist)
    {
      TypeParam = type;
    }

    [QueryParam("type")]
    public Type TypeParam { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("after")]
    public string After { get; set; }

    public enum Type
    {
      [String("artist")]
      Artist
    }
  }
}
