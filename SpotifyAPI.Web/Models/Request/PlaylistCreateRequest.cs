namespace SpotifyAPI.Web
{
  public class PlaylistCreateRequest : RequestParams
  {
    /// <summary>
    /// </summary>
    /// <param name="name">
    /// The name for the new playlist, for example "Your Coolest Playlist" .
    /// This name does not need to be unique; a user may have several playlists with the same name.
    /// </param>
    public PlaylistCreateRequest(string name)
    {
      Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

      Name = name;
    }

    /// <summary>
    /// The name for the new playlist, for example "Your Coolest Playlist" .
    /// This name does not need to be unique; a user may have several playlists with the same name.
    /// </summary>
    /// <value></value>
    [BodyParam("name")]
    public string Name { get; }

    /// <summary>
    /// Defaults to true . If true the playlist will be public, if false it will be private.
    /// To be able to create private playlists, the user must have granted the playlist-modify-private scope
    /// </summary>
    /// <value></value>
    [BodyParam("public")]
    public bool? Public { get; set; }

    /// <summary>
    /// Defaults to false . If true the playlist will be collaborative.
    /// Note that to create a collaborative playlist you must also set public to false .
    /// To create collaborative playlists you must have
    /// granted playlist-modify-private and playlist-modify-public scopes .
    /// </summary>
    /// <value></value>
    [BodyParam("collaborative")]
    public bool? Collaborative { get; set; }

    /// <summary>
    /// value for playlist description as displayed in Spotify Clients and in the Web API.
    /// </summary>
    /// <value></value>
    [BodyParam("description")]
    public string? Description { get; set; }
  }
}

