using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class AuthorizationCodeTokenResponse
  {
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public int ExpiresIn { get; set; }
    public string Scope { get; set; }
    public string RefreshToken { get; set; }

    /// <summary>
    ///   Auto-Initalized to UTC Now
    /// </summary>
    /// <value></value>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsExpired { get => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow; }
  }
}
