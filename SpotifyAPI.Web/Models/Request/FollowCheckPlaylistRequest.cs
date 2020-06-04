using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class FollowCheckPlaylistRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="ids">
    /// A comma-separated list of Spotify User IDs ;
    /// the ids of the users that you want to check to see if they follow the playlist.
    /// Maximum: 5 ids.
    /// </param>
    public FollowCheckPlaylistRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    /// <summary>
    /// A comma-separated list of Spotify User IDs ;
    /// the ids of the users that you want to check to see if they follow the playlist.
    /// Maximum: 5 ids.
    /// </summary>
    /// <value></value>
    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

