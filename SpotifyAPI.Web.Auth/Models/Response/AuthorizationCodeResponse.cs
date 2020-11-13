namespace SpotifyAPI.Web.Auth
{
  public class AuthorizationCodeResponse
  {
    public AuthorizationCodeResponse(string code)
    {
      Ensure.ArgumentNotNullOrEmptyString(code, nameof(code));

      Code = code;
    }

    public string Code { get; set; } = default!;
    public string? State { get; set; } = default!;
  }
}
