namespace SpotifyAPI.Web
{
  public class PlaylistChangeDetailsRequest : RequestParams
  {
    [BodyParam("name")]
    public string? Name { get; set; }

    [BodyParam("public")]
    public bool? Public { get; set; }

    [BodyParam("collaborative")]
    public bool? Collaborative { get; set; }

    [BodyParam("description")]
    public string? Description { get; set; }
  }
}

