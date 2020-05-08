namespace SpotifyAPI.Web
{
  public class NewReleasesResponse
  {
    public string Message { get; set; }
    public Paging<SimpleAlbum> Albums { get; set; }
  }
}
