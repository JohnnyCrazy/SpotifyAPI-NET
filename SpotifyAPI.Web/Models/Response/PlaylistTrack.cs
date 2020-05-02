using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistTrack<T>
  {
    public DateTime? AddedAt { get; set; }
    public PublicUser AddedBy { get; set; }
    public bool IsLocal { get; set; }

    [JsonConverter(typeof(PlaylistElementConverter))]
    public T Track { get; set; }
  }
}
