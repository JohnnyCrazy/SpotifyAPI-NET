namespace SpotifyAPI.Web
{
  public class NewReleasesResponse
  {
    public string Message { get; private set; }
    public Paging<SimpleAlbum> Albums { get; private set; }
  }
}
