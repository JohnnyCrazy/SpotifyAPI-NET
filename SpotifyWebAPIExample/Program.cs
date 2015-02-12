using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SpotifyAPI.SpotifyWebAPI;
using SpotifyAPI.SpotifyWebAPI.Models;

namespace SpotifyWebAPIExample
{
    class Program
    {
        static ImplicitGrantAuth auth;
        static void Main(string[] args)
        {
            Console.WriteLine("### SpotifyWebAPI .NET Test App");
            Console.WriteLine("Starting auth process...");
            //Create the auth object
            auth = new ImplicitGrantAuth()
            {
                //Your client Id
                ClientId = "26d287105e31491889f3cd293d85bfea",
                //Set this to localhost if you want to use the built-in HTTP Server
                RedirectUri = "http://localhost",
                //How many permissions we need?
                Scope = Scope.USER_READ_PRIVATE | Scope.USER_READ_EMAIL | Scope.PLAYLIST_READ_PRIVATE | Scope.USER_LIBRARAY_READ | Scope.USER_LIBRARY_MODIFY | Scope.USER_READ_PRIVATE
                    | Scope.USER_FOLLOW_MODIFY | Scope.USER_FOLLOW_READ | Scope.PLAYLIST_MODIFY_PRIVATE | Scope.USER_READ_BIRTHDATE
            };
            //Start the internal http server
            auth.StartHttpServer();
            //When we got our response
            auth.OnResponseReceivedEvent += auth_OnResponseReceivedEvent;
            //Start
            auth.DoAuth();
        }

        static void auth_OnResponseReceivedEvent(Token token, string state, string error)
        {
            //stop the http server
            auth.StopHttpServer();

            if(error != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + error);
                return;
            }
            DisplayMenu(new SpotifyWebAPIClass()
                {
                    AccessToken = token.AccessToken,
                    TokenType = token.TokenType,
                    UseAuth = true 
                });
        }

        public static void DisplayMenu(SpotifyWebAPIClass spotify)
        {
            Console.WriteLine("Choose one of the following Tests:");
            Console.WriteLine("1 - Display Profile information");
            Console.WriteLine("2 - Display all of your playlists");
            Console.WriteLine("3 - List all of your playlist-tracks");
            Console.Write("Number: ");
            String number = Console.ReadLine();
            switch (number)
            {
                default:
                    DisplayMenu(spotify);
                    break;
                case "1":
                    DisplayProfile(spotify);
                    break;
                case "2":
                    DisplayPlaylists(spotify);
                    break;
                case "3":
                    DisplayPlaylistTracks(spotify);
                    break;
            }
        }
        public static void DisplayProfile(SpotifyWebAPIClass spotify)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            PrivateProfile profile = spotify.GetPrivateProfile();
            Console.WriteLine("Your Display name: " + profile.DisplayName);
            Console.WriteLine("Your Country: " + profile.Country);
            Console.WriteLine("Your ID: " + profile.Id);
            Console.WriteLine("Account product: " + profile.Product);
            Console.WriteLine("Your images:");
            foreach (Image image in profile.Images)
                Console.WriteLine("- " + image.Url);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMenu(spotify);
        }
        private static void DisplayPlaylists(SpotifyWebAPIClass spotify)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Paging<SimplePlaylist> playlists = spotify.GetUserPlaylists(spotify.GetPublicProfile().Id);

            Console.WriteLine("Printing playlists...");
            Console.WriteLine("");
            foreach (SimplePlaylist playlist in playlists.Items)
                Console.WriteLine(playlist.Name + " (" + playlist.Id + ")");
            while(playlists.Next != null)
            {
                playlists = spotify.DownloadData<Paging<SimplePlaylist>>(playlists.Next);
                foreach (SimplePlaylist playlist in playlists.Items)
                    Console.WriteLine(playlist.Name + " (" + playlist.Id + ")");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMenu(spotify);
        }
        private static void DisplayPlaylistTracks(SpotifyWebAPIClass spotify)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Playlist ID (must be one of yours): ");
            String id = Console.ReadLine();

            Paging<PlaylistTrack> col = spotify.GetPlaylistTracks(spotify.GetPrivateProfile().Id, id);
            if(col.HasError())
            {
                Console.WriteLine("ERROR: " + col.ErrorResponse.Message);
                DisplayMenu(spotify);
                return;
            }
            foreach(PlaylistTrack track in col.Items)
                Console.WriteLine(track.Track.Name + " (" + track.Track.Id + ")");
            while (col.Next != null)
            {
                col = spotify.DownloadData<Paging<PlaylistTrack>>(col.Next);
                foreach (PlaylistTrack track in col.Items)
                    Console.WriteLine(track.Track.Name + " (" + track.Track.Id + ")");
            }
            DisplayMenu(spotify);
        }
    }
}
