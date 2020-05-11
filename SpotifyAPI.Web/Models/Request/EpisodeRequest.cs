namespace SpotifyAPI.Web
{
  public class EpisodeRequest : RequestParams
  {
    [QueryParam("market")]
    public string Market { get; set; }
  }
}
