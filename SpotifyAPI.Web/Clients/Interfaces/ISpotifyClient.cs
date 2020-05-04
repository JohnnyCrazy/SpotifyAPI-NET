namespace SpotifyAPI.Web
{
  public interface ISpotifyClient
  {
    IUserProfileClient UserProfile { get; }

    IBrowseClient Browse { get; }

    IShowsClient Shows { get; }

    IPlaylistsClient Playlists { get; }

    ISearchClient Search { get; }

    IFollowClient Follow { get; }

    ITracksClient Tracks { get; }
  }
}
