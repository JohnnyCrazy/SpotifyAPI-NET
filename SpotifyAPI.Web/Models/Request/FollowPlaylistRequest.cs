namespace SpotifyAPI.Web
{
  public class FollowPlaylistRequest : RequestParams
  {
    /// <summary>
    /// Defaults to true. If true the playlist will be included in user’s public playlists,
    /// if false it will remain private. To be able to follow playlists privately,
    /// the user must have granted the playlist-modify-private scope.
    /// </summary>
    /// <value></value>
    [BodyParam("public")]
    public bool? Public { get; set; }
  }
}

