namespace SpotifyAPI.Web
{
  public class TokenResponse
  {
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public int ExpiresIn { get; set; }
  }
}
