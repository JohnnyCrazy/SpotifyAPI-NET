namespace SpotifyAPI.Web
{
  public interface ISpotifyClient
  {
    IUserProfileClient UserProfile { get; }

    IBrowseClient Browse { get; }

    IShowsClient Shows { get; }

    IPlaylistsClient Playlists { get; }
  }
}
