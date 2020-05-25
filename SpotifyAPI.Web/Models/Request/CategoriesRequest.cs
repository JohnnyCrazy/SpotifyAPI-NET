namespace SpotifyAPI.Web
{
  public class CategoriesRequest : RequestParams
  {
    [QueryParam("country")]
    public string? Country { get; set; }

    [QueryParam("locale")]
    public string? Locale { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

