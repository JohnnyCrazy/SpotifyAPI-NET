namespace SpotifyAPI.Web
{
  public class TrackRequest : RequestParams
  {
    [QueryParam("market")]
    public string Market { get; set; }
  }
}
