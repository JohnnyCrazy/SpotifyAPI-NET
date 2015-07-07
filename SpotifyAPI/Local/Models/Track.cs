using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyAPI.Local.Enums;

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
        /// Returns a URL to the album cover in the provided size
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A String, which is the URL to the Albumart</returns>
        public String GetAlbumArtUrl(AlbumArtSize size)
        {
            if (AlbumResource.Uri.Contains("local"))
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
            String raw;
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                raw = wc.DownloadString("http://open.spotify.com/album/" + AlbumResource.Uri.Split(new[] { ":" }, StringSplitOptions.None)[2]);
            }
            raw = raw.Replace("\t", "");
            string[] lines = raw.Split(new[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.Trim().StartsWith("<meta property=\"og:image\""))
                {
                    string[] l = line.Split(new[] { "/" }, StringSplitOptions.None);
                    return "http://o.scdn.co/" + albumsize + @"/" + l[4].Replace("\"", "").Replace(">", "");
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
                wc.Proxy = null;
                String url = GetAlbumArtUrl(size);
                if (url == "")
                    return null;
                var data = await wc.DownloadDataTaskAsync(url);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }
        /// <summary>
        /// Returns a Bitmap of the album cover in the provided size
        /// </summary>
        /// <param name="size">AlbumArtSize (160,320,640)</param>
        /// <returns>A Bitmap, which is the albumart</returns>
        public Bitmap GetAlbumArt(AlbumArtSize size)
        {
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                String url = GetAlbumArtUrl(size);
                if (url == "")
                    return null;
                var data = wc.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }
    }
    
    
}
