namespace SpotifyAPI.Web
{
  public class AlbumRequest : RequestParams
  {
    /// <summary>
    /// The market you’d like to request. Synonym for country.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }
  }
}
