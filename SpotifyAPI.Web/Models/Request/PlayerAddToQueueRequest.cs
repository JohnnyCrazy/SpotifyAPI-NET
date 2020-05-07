namespace SpotifyAPI.Web
{
  public class PlayerAddToQueueRequest : RequestParams
  {
    public PlayerAddToQueueRequest(string uri)
    {
      Ensure.ArgumentNotNullOrEmptyString(uri, nameof(uri));

      Uri = uri;
    }

    [QueryParam("uri")]
    public string Uri { get; }

    [QueryParam("device_id")]
    public string DeviceId { get; set; }
  }
}
