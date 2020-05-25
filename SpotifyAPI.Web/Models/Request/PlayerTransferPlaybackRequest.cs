using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlayerTransferPlaybackRequest : RequestParams
  {
    public PlayerTransferPlaybackRequest(IList<string> deviceIds)
    {
      Ensure.ArgumentNotNullOrEmptyList(deviceIds, nameof(deviceIds));

      DeviceIds = deviceIds;
    }

    [BodyParam("device_ids")]
    public IList<string> DeviceIds { get; }

    [BodyParam("play")]
    public bool? Play { get; set; }
  }
}

