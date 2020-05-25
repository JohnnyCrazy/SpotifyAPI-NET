namespace SpotifyAPI.Web
{
  public class AlbumTracksRequest : RequestParams
  {
    [QueryParam("market")]
    public string? Market { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

