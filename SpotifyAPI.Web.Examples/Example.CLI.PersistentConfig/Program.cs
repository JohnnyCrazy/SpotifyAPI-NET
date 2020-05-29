using System.IO;
using System.Threading.Tasks;
using System;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Http;
using SpotifyAPI.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using static SpotifyAPI.Web.Scopes;

namespace Example.CLI.PersistentConfig
{
  /// <summary>
  ///   This is a basic example how to get user access using the Auth package and a CLI Program
  ///   Your spotify app needs to have http://localhost:5000 as redirect uri whitelisted
  /// </summary>
  public class Program
  {
    private const string CredentialsPath = "credentials.json";
    private static readonly string? clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
    private static readonly string? clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");
    private static readonly EmbedIOAuthServer _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);

    public static async Task<int> Main()
    {
      if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
      {
        throw new NullReferenceException(
          "Please set SPOTIFY_CLIENT_ID and SPOTIFY_CLIENT_SECRET via environment variables before starting the program"
        );
      }

      if (File.Exists(CredentialsPath))
      {
        await Start();
      }
      else
      {
        await StartAuthentication();
      }

      Console.ReadKey();
      return 0;
    }

    private static async Task Start()
    {
      var json = await File.ReadAllTextAsync(CredentialsPath);
      var token = JsonConvert.DeserializeObject<AuthorizationCodeTokenResponse>(json);

      var authenticator = new AuthorizationCodeAuthenticator(clientId!, clientSecret!, token);
      authenticator.TokenRefreshed += (sender, token) => File.WriteAllText(CredentialsPath, JsonConvert.SerializeObject(token));

      var config = SpotifyClientConfig.CreateDefault()
        .WithAuthenticator(authenticator);

      var spotify = new SpotifyClient(config);

      var me = await spotify.UserProfile.Current();
      Console.WriteLine($"Welcome {me.DisplayName} ({me.Id}), your authenticated!");

      var playlists = await spotify.PaginateAll(() => spotify.Playlists.CurrentUsers());
      Console.WriteLine($"Total Playlists in your Account: {playlists.Count}");

      _server.Dispose();
      Environment.Exit(0);
    }

    private static async Task StartAuthentication()
    {
      await _server.Start();
      _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;

      var request = new LoginRequest(_server.BaseUri, clientId!, LoginRequest.ResponseType.Code)
      {
        Scope = new List<string> { UserReadEmail, UserReadPrivate, PlaylistReadPrivate }
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
    }

    private static async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
    {
      await _server.Stop();
      AuthorizationCodeTokenResponse token = await new OAuthClient().RequestToken(
        new AuthorizationCodeTokenRequest(clientId!, clientSecret!, response.Code, _server.BaseUri)
      );

      await File.WriteAllTextAsync(CredentialsPath, JsonConvert.SerializeObject(token));
      await Start();
    }
  }
}
