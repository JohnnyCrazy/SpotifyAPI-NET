using System;
namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsRequest : RequestParams
  {
    [QueryParam("country")]
    public string Country { get; set; }
    [QueryParam("locale")]
    public string Locale { get; set; }
    [QueryParam("limit")]
    public int? Limit { get; set; }
    [QueryParam("offset")]
    public int? Offset { get; set; }
    public DateTime? Timestamp { get; set; }

    [QueryParam("timestamp")]
    protected string _Timestamp
    {
      get => Timestamp?.ToString("o");
    }
  }
}
