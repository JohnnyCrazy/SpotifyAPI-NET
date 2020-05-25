namespace SpotifyAPI.Web
{
  public class AlbumRequest : RequestParams
  {
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}
