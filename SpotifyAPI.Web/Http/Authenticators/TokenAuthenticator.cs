using System.Threading.Tasks;

namespace SpotifyAPI.Web.Http
{
  public class TokenAuthenticator : IAuthenticator
  {
    public TokenAuthenticator(string token, string tokenType)
    {
      Token = token;
      TokenType = tokenType;
    }

    public string Token { get; set; }

    public string TokenType { get; set; }

    public Task Apply(IRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      request.Headers["Authorization"] = $"{TokenType} {Token}";
      return Task.CompletedTask;
    }
  }
}
