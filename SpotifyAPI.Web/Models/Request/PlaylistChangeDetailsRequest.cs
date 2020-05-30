namespace SpotifyAPI.Web
{
  public class PlaylistChangeDetailsRequest : RequestParams
  {
    /// <summary>
    /// The new name for the playlist, for example "My New Playlist Title"
    /// </summary>
    /// <value></value>
    [BodyParam("name")]
    public string? Name { get; set; }

    /// <summary>
    /// If true the playlist will be public, if false it will be private.
    /// </summary>
    /// <value></value>
    [BodyParam("public")]
    public bool? Public { get; set; }

    /// <summary>
    /// If true , the playlist will become collaborative and other users will be able to modify the
    /// playlist in their Spotify client. Note: You can only set collaborative to true on non-public playlists.
    /// </summary>
    /// <value></value>
    [BodyParam("collaborative")]
    public bool? Collaborative { get; set; }

    /// <summary>
    /// Value for playlist description as displayed in Spotify Clients and in the Web API.
    /// </summary>
    /// <value></value>
    [BodyParam("description")]
    public string? Description { get; set; }
  }
}

