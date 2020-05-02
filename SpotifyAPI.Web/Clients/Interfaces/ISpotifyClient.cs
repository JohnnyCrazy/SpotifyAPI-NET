namespace SpotifyAPI.Web
{
  public interface ISpotifyClient
  {
    IUserProfileClient UserProfile { get; }

    IBrowseClient Browse { get; }
  }
}
