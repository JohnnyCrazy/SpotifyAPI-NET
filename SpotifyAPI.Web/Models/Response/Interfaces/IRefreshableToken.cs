namespace SpotifyAPI.Web
{
  /// <summary>
  /// An user token, which can be refreshed
  /// </summary>
  public interface IRefreshableToken : IUserToken
  {
    /// <summary>
    /// Refresh token
    /// </summary>
    public string RefreshToken { get; set; }
  }
}
