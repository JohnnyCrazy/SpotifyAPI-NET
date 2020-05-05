namespace SpotifyAPI.Web
{
  public class PlaylistCreateRequest : RequestParams
  {
    public PlaylistCreateRequest(string name)
    {
      Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

      Name = name;
    }

    [BodyParam("name")]
    public string Name { get; }

    [BodyParam("public")]
    public bool? Public { get; set; }

    [BodyParam("collaborative")]
    public bool? Collaborative { get; set; }

    [BodyParam("description")]
    public string Description { get; set; }
  }
}
