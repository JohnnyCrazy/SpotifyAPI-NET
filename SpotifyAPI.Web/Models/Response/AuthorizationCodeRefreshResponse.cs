using System;

namespace SpotifyAPI.Web
{
  public class AuthorizationCodeRefreshResponse: IUserToken
  {
    public string AccessToken { get; set; } = default!;
    public string TokenType { get; set; } = default!;
    public int ExpiresIn { get; set; }
    public string Scope { get; set; } = default!;

    /// <summary>
    ///   Auto-Initalized to UTC Now
    /// </summary>
    /// <value></value>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsExpired { get => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow; }
  }
}

