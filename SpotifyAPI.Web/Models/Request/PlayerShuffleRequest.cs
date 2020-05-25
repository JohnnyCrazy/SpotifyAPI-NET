namespace SpotifyAPI.Web
{
  public class PlayerShuffleRequest : RequestParams
  {
    public PlayerShuffleRequest(bool state)
    {
      State = state;
    }

    [QueryParam("state")]
    public bool State { get; }

    [QueryParam("device_id")]
    public string? DeviceId { get; set; }
  }
}

