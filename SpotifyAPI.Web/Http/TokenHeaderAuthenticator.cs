using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  class TokenHeaderAuthenticator : IAuthenticator
  {
    public TokenHeaderAuthenticator(string token, string tokenType)
    {
      Token = token;
      TokenType = tokenType;
    }

    public string Token { get; set; }

    public string TokenType { get; set; }

    public Task Apply(IRequest request)
    {
      request.Headers["Authorization"] = $"{TokenType} {Token}";
      return Task.CompletedTask;
    }
  }
}
