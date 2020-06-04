using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlayerTransferPlaybackRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="deviceIds">
    /// A JSON array containing the ID of the device on which playback should be started/transferred.
    /// For example:{device_ids:["74ASZWbe4lXaubB36ztrGX"]}
    /// Note: Although an array is accepted, only a single device_id is currently supported.
    /// Supplying more than one will return 400 Bad Request
    /// </param>
    public PlayerTransferPlaybackRequest(IList<string> deviceIds)
    {
      Ensure.ArgumentNotNullOrEmptyList(deviceIds, nameof(deviceIds));

      DeviceIds = deviceIds;
    }

    /// <summary>
    /// A JSON array containing the ID of the device on which playback should be started/transferred.
    /// For example:{device_ids:["74ASZWbe4lXaubB36ztrGX"]}
    /// Note: Although an array is accepted, only a single device_id is currently supported.
    /// Supplying more than one will return 400 Bad Request
    /// </summary>
    /// <value></value>
    [BodyParam("device_ids")]
    public IList<string> DeviceIds { get; }

    /// <summary>
    /// true: ensure playback happens on new device. false or not provided: keep the current playback state.
    /// </summary>
    /// <value></value>
    [BodyParam("play")]
    public bool? Play { get; set; }
  }
}

