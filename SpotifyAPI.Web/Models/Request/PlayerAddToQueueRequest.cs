namespace SpotifyAPI.Web
{
  public class PlayerAddToQueueRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="uri">The uri of the item to add to the queue. Must be a track or an episode uri.</param>
    public PlayerAddToQueueRequest(string uri)
    {
      Ensure.ArgumentNotNullOrEmptyString(uri, nameof(uri));

      Uri = uri;
    }

    /// <summary>
    /// The uri of the item to add to the queue. Must be a track or an episode uri.
    /// </summary>
    /// <value></value>
    [QueryParam("uri")]
    public string Uri { get; }

    /// <summary>
    /// The id of the device this command is targeting.
    /// If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

