using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using SpotifyAPI.SpotifyWebAPI;
using SpotifyAPI.SpotifyWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.IO;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class SpotifyWebAPIClass : IDisposable
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
            settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, TypeNameHandling = TypeNameHandling.All };
        }

        #region User

        public PrivateProfile GetPrivateProfile()
        {
            return DownloadData<PrivateProfile>("https://api.spotify.com/v1/me");
        }
        public PublicProfile GetPublicProfile(String userId = "")
        {
            if (userId.Length == 0)
                return DownloadData<PublicProfile>("https://api.spotify.com/v1/me");
            else
                return DownloadData<PublicProfile>("https://api.spotify.com/v1/users/" + userId);
        }

        #endregion

        #region User-Library
        public ErrorResponse SaveTracks(List<String> ids)
        {
            JArray array = new JArray(ids.ToArray());
            return UploadData<ErrorResponse>("https://api.spotify.com/v1/me/tracks/", array.ToString(Formatting.None), "PUT");
        }
        public Paging<FullTrack> GetSavedTracks()
        {
            return DownloadData<Paging<FullTrack>>("https://api.spotify.com/v1/me/tracks");
        }
        public ErrorResponse RemoveSavedTracks(List<String> ids)
        {
            JArray array = new JArray(ids.ToArray());
            return UploadData<ErrorResponse>("https://api.spotify.com/v1/me/tracks/", array.ToString(Formatting.None), "DELETE");
        }
        public CheckUserTracks CheckSavedTracks(List<String> ids)
        {
            String resp = DownloadString("https://api.spotify.com/v1/me/tracks/contains?ids=" + string.Join(",", ids));
            JToken res = JToken.Parse(resp);
            if (res is JArray)
            {
                return new CheckUserTracks { Checked = res.ToObject<List<Boolean>>(), ErrorResponse = null };
            }
            else
            {
                return new CheckUserTracks { Checked = null, ErrorResponse = res.ToObject<Error>() };
            }
        }
        #endregion

        #region Playlist
        public Paging<SimplePlaylist> GetUserPlaylists(String userId)
        {
            return DownloadData<Paging<SimplePlaylist>>("https://api.spotify.com/v1/users/" + userId + "/playlists");
        }
        public FullPlaylist GetPlaylist(String userId, String playlistId)
        {
            return DownloadData<FullPlaylist>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId);
        }
        public Paging<PlaylistTrack> GetPlaylistTracks(String userId, String playlistId)
        {
            return DownloadData<Paging<PlaylistTrack>>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks");
        }
        public FullPlaylist CreatePlaylist(String userId, String playlistName, Boolean isPublic = true)
        {
            CreatePlaylistArgs args = new CreatePlaylistArgs()
            {
                Name = playlistName,
                Public = isPublic
            };
            return UploadData<FullPlaylist>("https://api.spotify.com/v1/users/" + userId + "/playlists", JsonConvert.SerializeObject(args));
        }
        public ErrorResponse UpdatePlaylist(String userId, String playlistId, String newName = null, Boolean? newPublic = null)
        {
            JObject ob = new JObject();
            if (newName != null)
                ob.Add("name", newName);
            if (newPublic != null)
                ob.Add("public", newPublic);
            return UploadData<ErrorResponse>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId, ob.ToString(Formatting.None), "PUT");
        }
        public ErrorResponse ReplacePlaylistTracks(String userId, String playlistId, List<String> uris)
        {
            JObject ob = new JObject();
            ob.Add("uris", new JArray(uris));
            return UploadData<ErrorResponse>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks", ob.ToString(Formatting.None), "PUT");
        }
        public ErrorResponse DeletePlaylistTracks(String userId, String playlistId, List<DeleteTrackArg> args)
        {
            JObject ob = new JObject();
            ob.Add("tracks", JArray.FromObject(args));
            return UploadData<ErrorResponse>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks", ob.ToString(Formatting.None), "DELETE");
        }
        public ErrorResponse AddTracks(String userId, String playlistId, List<String> uris, int position = int.MaxValue)
        {
            if (position == int.MaxValue)
                return UploadData<ErrorResponse>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks", JsonConvert.SerializeObject(uris));
            else
            {
                String tracks = string.Join(",", uris);
                return UploadData<ErrorResponse>("https://api.spotify.com/v1/users/" + userId + "/playlists/" + playlistId + "/tracks?position=" + position
                    + "&ids=" + tracks
                    , JsonConvert.SerializeObject(uris));
            }
        }
        public FeaturedPlaylists GetFeaturedPlaylists(String locale = "", String country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            limit = Math.Max(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/browse/featured-playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if(locale != "")
                builder.Append("&locale=" + locale);
            if(country != "")
                builder.Append("&country=" + country);
            if (timestamp != default(DateTime))
                builder.Append("&timestamp=" + timestamp.ToString("yyyy-MM-ddTHH:mm:ss"));
            return DownloadData<FeaturedPlaylists>(builder.ToString());
        }
        #endregion

        #region Search and Fetch
        public NewAlbumReleases GetNewAlbumReleases(String country = "", int limit = 50, int offset = 0)
        {
            limit = Math.Max(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/browse/new-releases");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (country != "")
                builder.Append("&country=" + country);
            return DownloadData<NewAlbumReleases>(builder.ToString());
            
        }
        public SearchItem SearchItems(String q, SearchType type, int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/search");
            builder.Append("?q=" + q);
            builder.Append("&type=" + type.GetSearchValue(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);

            return DownloadData<SearchItem>(builder.ToString());
        }
        public SeveralTracks GetSeveralTracks(List<String> ids)
        {
            return DownloadData<SeveralTracks>("https://api.spotify.com/v1/tracks?ids=" + string.Join(",", ids));
        }
        public SeveralAlbums GetSeveralAlbums(List<String> ids)
        {
            return DownloadData<SeveralAlbums>("https://api.spotify.com/v1/albums?ids=" + string.Join(",", ids));
        }
        public SeveralArtists GetSeveralArtists(List<String> ids)
        {
            return DownloadData<SeveralArtists>("https://api.spotify.com/v1/artists?ids=" + string.Join(",", ids));
        }
        public FullTrack GetTrack(String id)
        {
            return DownloadData<FullTrack>("https://api.spotify.com/v1/tracks/" + id);
        }
        public SeveralArtists GetRelatedArtists(String id)
        {
            return DownloadData<SeveralArtists>("https://api.spotify.com/v1/artists/" + id + "/related-artists");
        }
        public SeveralTracks GetArtistsTopTracks(String id, String country)
        {
            return DownloadData<SeveralTracks>("https://api.spotify.com/v1/artists/" + id + "/top-tracks?country=" + country);
        }
        public Paging<SimpleAlbum> GetArtistsAlbums(String id, AlbumType type = AlbumType.ALL, String market = "", int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/artists/" + id + "/albums");
            builder.Append("?type=" + type.GetAlbumValue(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (market != "")
                builder.Append("&market=" + market);
            return DownloadData<Paging<SimpleAlbum>>(builder.ToString());
        }
        public FullArtist GetArtist(String id)
        {
            return DownloadData<FullArtist>("https://api.spotify.com/v1/artists/" + id);
        }
        public Paging<SimpleTrack> GetAlbumTracks(String id, int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder("https://api.spotify.com/v1/albums/" + id + "/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            return DownloadData<Paging<SimpleTrack>>(builder.ToString());
        }
        public FullAlbum GetAlbum(String id)
        {
            return DownloadData<FullAlbum>("https://api.spotify.com/v1/albums/" + id);
        }
        #endregion

        #region Util
        public T UploadData<T>(String url, String uploadData, String method = "POST")
        {
            if (!UseAuth)
                throw new Exception("UseAuth required for 'UploadData'");
            webclient.Headers.Add("Authorization", TokenType + " " + AccessToken);
            webclient.Headers.Add("Content-Type", "application/json");
            String response = "";
            try
            {
                byte[] data = webclient.UploadData(url, method, Encoding.UTF8.GetBytes(uploadData));
                response = Encoding.UTF8.GetString(data);
            }
            catch (WebException e)
            {
                response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(response, settings);
        }
        public T DownloadData<T>(String url)
        {
            return JsonConvert.DeserializeObject<T>(DownloadString(url), settings);
        }

        public String DownloadString(String url)
        {
            if (UseAuth)
                webclient.Headers.Add("Authorization", TokenType + " " + AccessToken);
            String response = "";
            try
            {
                byte[] data = webclient.DownloadData(url);
                response = Encoding.UTF8.GetString(data);
            }
            catch (WebException e)
            {
                response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            Debug.WriteLine(response);
            return response;
        }
        #endregion

        public void Dispose()
        {
            webclient.Dispose();
        }
    }
}