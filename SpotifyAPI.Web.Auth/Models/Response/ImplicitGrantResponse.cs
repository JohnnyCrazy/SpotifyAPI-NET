using System;

namespace SpotifyAPI.Web.Auth
{
  public class ImplictGrantResponse
  {
    public ImplictGrantResponse(string accessToken, string tokenType, int expiresIn)
    {
      Ensure.ArgumentNotNullOrEmptyString(accessToken, nameof(accessToken));
      Ensure.ArgumentNotNullOrEmptyString(tokenType, nameof(tokenType));

      AccessToken = accessToken;
      TokenType = tokenType;
      ExpiresIn = expiresIn;
    }

    public string AccessToken { get; set; } = default!;
    public string TokenType { get; set; } = default!;
    public int ExpiresIn { get; set; }
    public string? State { get; set; } = default!;

    /// <summary>
    ///   Auto-Initalized to UTC Now
    /// </summary>
    /// <value></value>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsExpired { get => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow; }
  }
}
