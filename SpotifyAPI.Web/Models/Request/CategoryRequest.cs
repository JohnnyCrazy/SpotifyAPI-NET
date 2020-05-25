namespace SpotifyAPI.Web
{
  public class CategoryRequest : RequestParams
  {
    [QueryParam("country")]
    public string? Country { get; set; }

    [QueryParam("locale")]
    public string? Locale { get; set; }
  }
}

