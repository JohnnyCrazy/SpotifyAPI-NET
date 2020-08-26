using System;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// A token to access the Spotify API
  /// </summary>
  public interface IToken
  {
    /// <summary>
    /// Access token string
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Type of this token (eg. Bearer)
    /// </summary>
    public string TokenType { get; set; }

    /// <summary>
    /// Auto-Initalized to UTC Now
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Is the token still valid?
    /// </summary>
    public bool IsExpired { get; }
  }
}
