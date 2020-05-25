using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlayerResumePlaybackRequest : RequestParams
  {
    [QueryParam("device_id")]
    public string? DeviceId { get; set; }

    [BodyParam("context_uri")]
    public string? ContextUri { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227")]
    [BodyParam("uris")]
    public IList<string>? Uris { get; set; }

    [BodyParam("offset")]
    public Offset? OffsetParam { get; set; }

    [BodyParam("position_ms")]
    public int? PositionMs { get; set; }

    public class Offset
    {
      [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
      public string? Uri { get; set; }

      [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
      public int? Position { get; set; }
    }
  }
}

