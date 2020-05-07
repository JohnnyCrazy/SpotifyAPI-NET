namespace SpotifyAPI.Web
{
  public class PlayerRecentlyPlayedRequest : RequestParams
  {
    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("after")]
    public long? After { get; set; }

    [QueryParam("before")]
    public long? Before { get; set; }
  }
}
