namespace SpotifyAPI.Web.Models.Response.Interfaces
{
  /// <summary>
  /// A token which allows you to access the API as user
  /// </summary>
  public interface IUserToken : IToken
  {
    /// <summary>
    /// Comma-Seperated list of scopes
    /// </summary>
    public string Scope { get; set; }
  }
}
