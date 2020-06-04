using System;

namespace SpotifyAPI.Web
{
  public class TokenSwapRefreshRequest
  {
    public TokenSwapRefreshRequest(Uri refreshUri, string refreshToken)
    {
      Ensure.ArgumentNotNull(refreshUri, nameof(refreshUri));
      Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

      RefreshUri = refreshUri;
      RefreshToken = refreshToken;
    }

    public string RefreshToken { get; }

    public Uri RefreshUri { get; }
  }
}
