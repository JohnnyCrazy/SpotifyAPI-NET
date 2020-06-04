using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlayerResumePlaybackRequest : RequestParams
  {
    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.
    /// </summary>
    /// <value></value>
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Undocumented by Spotify Beta Docs
    /// </summary>
    /// <value></value>
    [BodyParam("context_uri")]
    public string? ContextUri { get; set; }

    /// <summary>
    /// Undocumented by Spotify Beta Docs
    /// </summary>
    /// <value></value>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227")]
    [BodyParam("uris")]
    public IList<string>? Uris { get; set; }

    /// <summary>
    /// Undocumented by Spotify Beta Docs
    /// </summary>
    /// <value></value>
    [BodyParam("offset")]
    public Offset? OffsetParam { get; set; }

    /// <summary>
    /// Undocumented by Spotify Beta Docs
    /// </summary>
    /// <value></value>
    [BodyParam("position_ms")]
    public int? PositionMs { get; set; }

    public class Offset
    {
      /// <summary>
      /// Undocumented by Spotify Beta Docs
      /// </summary>
      /// <value></value>
      [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
      public string? Uri { get; set; }

      /// <summary>
      /// Undocumented by Spotify Beta Docs
      /// </summary>
      /// <value></value>
      [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
      public int? Position { get; set; }
    }
  }
}

