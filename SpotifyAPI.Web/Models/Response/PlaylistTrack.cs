using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistTrack<T>
  {
    public DateTime? AddedAt { get; set; }
    public PublicUser AddedBy { get; set; } = default!;
    public bool IsLocal { get; set; }

    [JsonConverter(typeof(PlayableItemConverter))]
    public T Track { get; set; } = default!;

    [JsonConverter(typeof(PlayableItemConverter))]
    public T Item { get; set; } = default!;
  }
}

