using Newtonsoft.Json;
using SpotifyAPI.Local.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
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
        public string GetAlbumArtUrl(AlbumArtSize size)
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
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                raw = wc.DownloadString("http://open.spotify.com/album/" + AlbumResource.Uri.Split(new[] { ":" }, StringSplitOptions.None)[2]);
            }
            raw = raw.Replace("\t", "");

            // <img id="cover-img" src="https://d3rt1990lpmkn.cloudfront.net/640/e62a04cfea4122961f3b9159493730c27d61f71b" ...
            string[] lines = raw.Split(new[] { "\n" }, StringSplitOptions.None);
            const string pattern = "id=\"cover-img\".*?src=\"(.*?)\"";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (string line in lines)
            {
                MatchCollection matches = rgx.Matches(line);
                if (matches.Count > 0)
                {
                    string content = matches[0].Groups[1].Value;
                    string[] l = content.Split(new[] { "/" }, StringSplitOptions.None);
                    return "http://o.scdn.co/" + albumsize + @"/" + l[4];
                }
            }
            return "";
        }

        /// <summary>
        /// Returns a Bitmap of the album cover in the provided size asynchronous
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A Bitmap, which is the albumart</returns>
        public async Task<Bitmap> GetAlbumArtAsync(AlbumArtSize size)
        {
            using (WebClient wc = new WebClient())
            {
                string url = GetAlbumArtUrl(size);
                if (url == "")
                    return null;
                var data = await wc.DownloadDataTaskAsync(url).ConfigureAwait(false);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }

        /// <summary>
        /// Returns a byte[] of the the album cover in the provided size asynchronous
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A byte[], which is the albumart in binary data</returns>
        public Task<byte[]> GetAlbumArtAsByteArrayAsync(AlbumArtSize size)
        {
            using (WebClient wc = new WebClient())
            {
                string url = GetAlbumArtUrl(size);
                if (url == "")
                    return null;
                return wc.DownloadDataTaskAsync(url);
            }
        }

        /// <summary>
        /// Returns a Bitmap of the album cover in the provided size
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A Bitmap, which is the albumart</returns>
        public Bitmap GetAlbumArt(AlbumArtSize size)
        {
            using (WebClient wc = new WebClient())
            {
                string url = GetAlbumArtUrl(size);
                if (string.IsNullOrEmpty(url))
                    return null;
                var data = wc.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }

        /// <summary>
        /// Returns a byte[] of the album cover in the provided size
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A byte[], which is the albumart in binary data</returns>
        public byte[] GetAlbumArtAsByteArray(AlbumArtSize size)
        {
            using (WebClient wc = new WebClient())
            {
                string url = GetAlbumArtUrl(size);
                if (string.IsNullOrEmpty(url))
                    return null;
                return wc.DownloadData(url);
            }
        }
    }
}