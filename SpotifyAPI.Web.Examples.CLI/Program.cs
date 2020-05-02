using System;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Examples.CLI
{
  internal static class Program
  {
    // private static string _clientId = ""; //"";
    // private static string _secretId = ""; //"";

    // ReSharper disable once UnusedParameter.Local
    // public static void Main(string[] args)
    // {
    //   _clientId = string.IsNullOrEmpty(_clientId) ?
    //     Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID") :
    //     _clientId;

    //   _secretId = string.IsNullOrEmpty(_secretId) ?
    //     Environment.GetEnvironmentVariable("SPOTIFY_SECRET_ID") :
    //     _secretId;

    //   Console.WriteLine("####### Spotify API Example #######");
    //   Console.WriteLine("This example uses AuthorizationCodeAuth.");
    //   Console.WriteLine(
    //     "Tip: If you want to supply your ClientID and SecretId beforehand, use env variables (SPOTIFY_CLIENT_ID and SPOTIFY_SECRET_ID)");

    //   var auth =
    //     new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4002", "http://localhost:4002",
    //       Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative);
    //   auth.AuthReceived += AuthOnAuthReceived;
    //   auth.Start();
    //   auth.OpenBrowser();

    //   Console.ReadLine();
    //   auth.Stop(0);

    // }

    // private static async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
    // {
    //   var auth = (AuthorizationCodeAuth)sender;
    //   auth.Stop();

    //   Token token = await auth.ExchangeCode(payload.Code);
    //   var api = new SpotifyWebAPI
    //   {
    //     AccessToken = token.AccessToken,
    //     TokenType = token.TokenType
    //   };
    //   await PrintUsefulData(api);
    // }

    // private static async Task PrintAllPlaylistTracks(SpotifyWebAPI api, Paging<SimplePlaylist> playlists)
    // {
    //   if (playlists.Items == null) return;

    //   playlists.Items.ForEach(playlist => Console.WriteLine($"- {playlist.Name}"));
    //   if (playlists.HasNextPage())
    //     await PrintAllPlaylistTracks(api, await api.GetNextPageAsync(playlists));
    // }

    // private static async Task PrintUsefulData(SpotifyWebAPI api)
    // {
    //   PrivateProfile profile = await api.GetPrivateProfileAsync();
    //   string name = string.IsNullOrEmpty(profile.DisplayName) ? profile.Id : profile.DisplayName;
    //   Console.WriteLine($"Hello there, {name}!");

    //   Console.WriteLine("Your playlists:");
    //   await PrintAllPlaylistTracks(api, api.GetUserPlaylists(profile.Id));
    // }
  }
}
