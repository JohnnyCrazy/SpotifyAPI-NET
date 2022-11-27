using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace Client
{
  public class Program
  {
    private static readonly string clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
    private static EmbedIOAuthServer _server;

    public static async Task Main()
    {
      _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
      await _server.Start();

      _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;

      var request = new LoginRequest(_server.BaseUri, clientId, LoginRequest.ResponseType.Code)
      {
        Scope = new List<string> { Scopes.UserReadEmail }
      };

      Uri uri = request.ToUri();
      try
      {
        BrowserUtil.Open(uri);
      }
      catch (Exception)
      {
        Console.WriteLine("Unable to open URL, manually open: {0}", uri);
      }

      Console.ReadKey();
    }

    private static async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
    {
      var oauth = new OAuthClient();

      var tokenRequest = new TokenSwapTokenRequest(new Uri("http://localhost:5001/swap"), response.Code);
      var tokenResponse = await oauth.RequestToken(tokenRequest);

      Console.WriteLine($"We got an access token from server: {tokenResponse.AccessToken}");

      var refreshRequest = new TokenSwapRefreshRequest(
        new Uri("http://localhost:5001/refresh"),
        tokenResponse.RefreshToken
      );
      var refreshResponse = await oauth.RequestToken(refreshRequest);

      Console.WriteLine($"We got a new refreshed access token from server: {refreshResponse.AccessToken}");
    }
  }
}
