using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SpotifyAPI.SpotifyWebAPI;
using SpotifyAPI.SpotifyWebAPI.Models;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.IO;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class SpotifyWebAPIClass
    {
        public String TokenType { get; set; }
        public String AccessToken { get; set; }
        /// <summary>
        /// Set to false, if you want anonymous calls without auth
        /// </summary>
        public Boolean UseAuth { get; set; }

        WebClient webclient;
        JsonSerializerSettings settings;
        public SpotifyWebAPIClass()
        {
            UseAuth = true;
            webclient = new WebClient();
            webclient.Proxy = null;
            settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }
        public PrivateProfile GetPrivateProfile()
        {
            return DownloadString<PrivateProfile>("https://api.spotify.com/v1/me");
        }
        public PublicProfile GetPublicProfile(String userId = "")
        {
            if(userId.Length == 0)
                return DownloadString<PublicProfile>("https://api.spotify.com/v1/me");
            else
                return DownloadString<PublicProfile>("https://api.spotify.com/v1/users/" + userId);
        }
        public Paging<SimplePlaylist> GetUserPlaylists(String userId)
        {
            return DownloadString<Paging<SimplePlaylist>>("https://api.spotify.com/v1/users/" + userId + "/playlists");
        }
        public FullPlaylist GetPlaylist(String userId,String playlistId)
        {
            return DownloadString<FullPlaylist>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId);
        }
        public Paging<PlaylistTrack> GetPlaylistTracks(String userId,String playlistId)
        {
            return DownloadString<Paging<PlaylistTrack>>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks");
        }
        public FullPlaylist CreatePlaylist(String userId,String playlistName,Boolean isPublic = true)
        {
            CreatePlaylistArgs args = new CreatePlaylistArgs()
            {
                Name = playlistName,
                Public = isPublic
            };
            return UploadData<FullPlaylist>("https://api.spotify.com/v1/users/" + userId + "/playlists",JsonConvert.SerializeObject(args));
        }
        public Error AddTracks(String userId,String playlistId,List<String> uris,int position = int.MaxValue)
        {
            if(position == int.MaxValue)
                return UploadData<Error>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks", JsonConvert.SerializeObject(uris));
            else
            {
                String tracks = string.Join(",", uris);
                return UploadData<Error>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks?position=" + position
                    + "&ids=" + tracks
                    , JsonConvert.SerializeObject(uris));
            }
        }
        public SearchItem SearchItems(String q,SearchType type,int limit = 20,int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/search");
            builder.Append("?q=" + q);
            builder.Append("&type=" + type.GetSearchValue(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);

            return DownloadString<SearchItem>(builder.ToString());
        }
        public SeveralTracks GetSeveralTracks(List<String> ids)
        {
            return DownloadString<SeveralTracks>("https://api.spotify.com/v1/tracks?ids=" + string.Join(",",ids));
        }
        public SeveralAlbums GetSeveralAlbums(List<String> ids)
        {
            return DownloadString<SeveralAlbums>("https://api.spotify.com/v1/albums?ids=" + string.Join(",", ids));
        }
        public SeveralArtists GetSeveralArtists(List<String> ids)
        {
            return DownloadString<SeveralArtists>("https://api.spotify.com/v1/artists?ids=" + string.Join(",", ids));
        }
        public FullTrack GetTrack(String id)
        {
            return DownloadString<FullTrack>("https://api.spotify.com/v1/tracks/" + id);
        }
        public SeveralArtists GetRelatedArtists(String id)
        {
            return DownloadString<SeveralArtists>("https://api.spotify.com/v1/artists/" + id + "/related-artists");
        }
        public SeveralTracks GetArtistsTopTracks(String id, String country)
        {
            return DownloadString<SeveralTracks>("https://api.spotify.com/v1/artists/" + id + "/top-tracks?country=" + country);
        }
        public Paging<SimpleAlbum> GetArtistsAlbums(String id,AlbumType type = AlbumType.ALL,String country = "",int limit = 20,int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/artists/" + id + "/albums");
            builder.Append("?type=" + type.GetAlbumValue(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            return DownloadString<Paging<SimpleAlbum>>(builder.ToString());
        }
        public FullArtist GetArtist(String id)
        {
            return DownloadString<FullArtist>("https://api.spotify.com/v1/artists/" + id);
        }
        public Paging<SimpleTrack> GetAlbumTracks(String id,int limit = 20,int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/albums/" + id + "/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            return DownloadString<Paging<SimpleTrack>>(builder.ToString());
        }
        public FullAlbum GetAlbum(String id )
        {
            return DownloadString<FullAlbum>("https://api.spotify.com/v1/albums/" + id);
        }
        public T UploadData<T>(String url,String uploadData)
        {
            if (!UseAuth)
                throw new Exception("UseAuth required for 'UploadData'");
            webclient.Headers.Add("Authorization", TokenType + " " + AccessToken);
            webclient.Headers.Add("Content-Type","application/json");
            String response = "";
            try
            {
                byte[] data = webclient.UploadData(url,Encoding.UTF8.GetBytes(uploadData));
                response = Encoding.UTF8.GetString(data);
            }
            catch (WebException e)
            {
                response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(response, settings);
        }
        public T DownloadString<T>(String url)
        {
            if(UseAuth)
                webclient.Headers.Add("Authorization", TokenType + " " + AccessToken);
            String response = "";
            try
            {
                byte [] data = webclient.DownloadData(url);
                response = Encoding.UTF8.GetString(data);
            }catch(WebException e)
            {
                response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(response, settings);
        }
        public void Dispose()
        {
            webclient.Dispose();
        }
    }
}