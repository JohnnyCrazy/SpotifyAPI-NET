using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyAPI.Web
{
  public class SimpleEpisode
  {
    public string AudioPreviewUrl { get; private set; }
    public string Description { get; private set; }
    public int DurationMs { get; private set; }
    public bool Explicit { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public List<Image> Images { get; private set; }
    public bool IsExternallyHosted { get; private set; }
    public bool IsPlayable { get; private set; }

    [Obsolete("This field is deprecated and might be removed in the future. Please use the languages field instead")]
    public string Language { get; private set; }
    public List<string> Languages { get; private set; }
    public string Name { get; private set; }
    public string ReleaseDate { get; private set; }
    public string ReleaseDatePrecision { get; private set; }
    public ResumePoint ResumePoint { get; private set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType Type { get; private set; }
    public string Uri { get; private set; }
  }
}
