using System;
using System.Threading.Tasks;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Example
{
    static class Program
    {
        private static string _clientId = ""; //"";
        private static string _secretId = ""; //"";

        static void Main(string[] args)
        {
            _clientId = string.IsNullOrEmpty(_clientId)
                ? System.Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID")
                : _clientId;

            _secretId = string.IsNullOrEmpty(_secretId)
                ? System.Environment.GetEnvironmentVariable("SPOTIFY_SECRET_ID")
                : _secretId;

            Console.WriteLine("####### Spotify API Example #######");
            Console.WriteLine("This example uses AuthorizationCodeAuth.");
            Console.WriteLine(
                "Tip: If you want to supply your ClientID and SecretId beforehand, use env variables (SPOTIFY_CLIENT_ID and SPOTIFY_SECRET_ID)");


                        AuthorizationCodeAuth auth =
                            new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4002", "http://localhost:4002",
                                Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative);
                        auth.AuthReceived += AuthOnAuthReceived;
                        auth.Start();
                        auth.OpenBrowser();

/*            ImplictGrantAuth auth = new ImplictGrantAuth("26d287105e31491889f3cd293d85bfea", "http://localhost:4002", "http://localhost:4002");
            auth.Start();
            auth.OpenBrowser();*/

            Console.ReadLine();
            auth.Stop(0);
        }

        private static async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
        {
            AuthorizationCodeAuth auth = (AuthorizationCodeAuth) sender;
            auth.Stop();

            Token token = await auth.ExchangeCode(payload.Code);
            SpotifyWebAPI api = new SpotifyWebAPI()
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            PrintUsefulDate(api);
        }

        private static async void PrintUsefulDate(SpotifyWebAPI api)
        {
            PrivateProfile profile = await api.GetPrivateProfileAsync();
            string name = string.IsNullOrEmpty(profile.DisplayName) ? profile.Id : profile.DisplayName;
            Console.WriteLine($"Hello there, {name}!");

            Console.WriteLine("Your playlists:");
            Paging<SimplePlaylist> playlists = await api.GetUserPlaylistsAsync(profile.Id);
            do
            {
                playlists.Items.ForEach(playlist =>
                {
                    Console.WriteLine($"- {playlist.Name}");
                });
                playlists = await api.GetNextPageAsync(playlists);
            } while (playlists.HasNextPage());


        }
    }
}