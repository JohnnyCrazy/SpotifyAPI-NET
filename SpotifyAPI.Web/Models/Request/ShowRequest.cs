namespace SpotifyAPI.Web
{
  public class ShowRequest : RequestParams
  {
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

