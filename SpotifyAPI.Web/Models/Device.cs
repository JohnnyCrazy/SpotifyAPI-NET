using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
  public class Device
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("is_active")]
    public bool IsActive { get; set; }

    [JsonProperty("is_restricted")]
    public bool IsRestricted { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("volume_percent")]
    public int VolumePercent { get; set; }
  }
}