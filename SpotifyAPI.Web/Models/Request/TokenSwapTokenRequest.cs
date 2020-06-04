using System;

namespace SpotifyAPI.Web
{
  public class TokenSwapTokenRequest
  {
    public TokenSwapTokenRequest(Uri tokenUri, string code)
    {
      Ensure.ArgumentNotNull(tokenUri, nameof(tokenUri));
      Ensure.ArgumentNotNullOrEmptyString(code, nameof(code));

      TokenUri = tokenUri;
      Code = code;
    }

    public string Code { get; }

    public Uri TokenUri { get; }
  }
}
