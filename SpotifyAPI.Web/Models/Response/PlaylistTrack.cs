using System;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PlaylistTrack<T>
  {
    public DateTime? AddedAt { get; private set; }
    public PublicUser AddedBy { get; private set; }
    public bool IsLocal { get; private set; }

    [JsonConverter(typeof(PlaylistElementConverter))]
    public T Track { get; private set; }
  }
}
