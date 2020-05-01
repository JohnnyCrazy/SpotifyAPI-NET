namespace SpotifyAPI.Web
{
  interface ISpotifyClient
  {
    IUserProfileClient UserProfile { get; }

    IBrowseClient Browse { get; }
  }
}
