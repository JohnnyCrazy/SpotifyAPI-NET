namespace SpotifyAPI.Web
{
  public class LibraryAlbumsRequest : RequestParams
  {
    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [QueryParam("market")]
    public string? Market { get; set; }
  }
}

