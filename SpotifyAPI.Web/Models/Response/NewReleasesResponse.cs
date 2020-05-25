namespace SpotifyAPI.Web
{
  public class NewReleasesResponse
  {
    public string Message { get; set; } = default!;
    public Paging<SimpleAlbum> Albums { get; set; } = default!;
  }
}

