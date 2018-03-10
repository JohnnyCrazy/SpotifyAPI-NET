using Newtonsoft.Json;
using SpotifyAPI.Local.Enums;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyAPI.Local.Models
{
    public class Track
    {
        [JsonProperty("track_resource")]
        public SpotifyResource TrackResource { get; set; }

        [JsonProperty("artist_resource")]
        public SpotifyResource ArtistResource { get; set; }

        [JsonProperty("album_resource")]
        public SpotifyResource AlbumResource { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("track_type")]
        public string TrackType { get; set; }

        /// <summary>
        /// Checks if the track is an advert
        /// </summary>
        /// <returns>true if the track is an advert, false otherwise</returns>
        public bool IsAd()
        {
            if (TrackType == "ad")
                return true;
            if (Length == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Returns a URL to the album cover in the provided size
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A String, which is the URL to the Albumart</returns>
        public async Task<string> GetAlbumArtUrlAsync(AlbumArtSize size)
        {
            if (AlbumResource.Uri == null || !AlbumResource.Uri.Contains("spotify:album:") || AlbumResource.Uri.Contains("spotify:album:0000000000000000000000"))
                return "";

            int albumsize = 0;
            switch (size)
            {
                case AlbumArtSize.Size160:
                    albumsize = 160;
                    break;

                case AlbumArtSize.Size320:
                    albumsize = 320;
                    break;

                case AlbumArtSize.Size640:
                    albumsize = 640;
                    break;
            }
            string raw;
            using (HttpClient httpClient = new HttpClient())
            {
                raw = await httpClient.GetStringAsync("http://open.spotify.com/album/" + AlbumResource.Uri.Split(new[] { ":" }, StringSplitOptions.None)[2]);
            }
            raw = raw.Replace("\t", "");

            // < meta property = "og:image" content = "http://o.scdn.co/cover/12b318ffe0e4c92f9b4e1486e4726a57e6437ca7" >
            // Spotify changed the response so I am now getting the substring from the first line that parses out the above tag.
            string[] lines = raw.Split(new[] { "\n" }, StringSplitOptions.None);
            const string startString = "<meta property=\"og:image\"";
            const string endString = "\">";
            foreach (string line in lines)
            {
                if (line.Trim().Contains("<meta property=\"og:image\""))
                {
                    int start = line.IndexOf(startString, 0, StringComparison.Ordinal) + startString.Length;
                    int end = line.IndexOf(endString, start, StringComparison.Ordinal);
                    string content = line.Substring(start, end - start);
                    string[] l = content.Split(new[] { "/" }, StringSplitOptions.None);
                    return "http://o.scdn.co/" + albumsize + @"/" + l[4].Replace("\"", "").Replace(">", "");
                }
            }
            return "";
        }

        /// <summary>
        /// Returns a byte[] of the the album cover in the provided size asynchronous
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A byte[], which is the albumart in binary data</returns>
        public async Task<byte[]> GetAlbumArtAsByteArrayAsync(AlbumArtSize size)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = await GetAlbumArtUrlAsync(size);
                if (url == "")
                    return null;
                return await httpClient.GetByteArrayAsync(url);
            }
        }
    }
}