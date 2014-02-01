using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

namespace SpotifyAPIv1
{
    public class Track
    {
        public TrackResource track_resource { get; set; }
        public TrackResource artist_resource { get; set; }
        public TrackResource album_resource { get; set; }
        public int length { get; set; }
        public string track_type { get; set; }

        public String GetTrackName()
        {
            return track_resource.name;
        }
        public int GetLength()
        {
            return length;
        }
        public String GetAlbumURI()
        {
            return album_resource.uri;
        }
        public String GetTrackURI()
        {
            return track_resource.uri;
        }
        public String GetArtistURI()
        {
            return artist_resource.uri;
        }
        public String GetAlbumName()
        {
            return album_resource.name;
        }
        public String GetArtistName()
        {
            return artist_resource.name;
        }
        public String GetAlbumArtURL(AlbumArtSize size)
        {
            if (album_resource.uri.Contains("local"))
                return "";
            int albumsize = 0;
            switch (size)
            {
                case AlbumArtSize.SIZE_160:
                    albumsize = 160;
                    break;
                case AlbumArtSize.SIZE_320:
                    albumsize = 320;
                    break;
                case AlbumArtSize.SIZE_640:
                    albumsize = 640;
                    break;
            }
            String raw = "";
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                raw = wc.DownloadString("http://open.spotify.com/album/" + album_resource.uri.Split(new string[] { ":" }, StringSplitOptions.None)[2]);
            }
            raw = raw.Replace("\t", ""); ;
            string[] lines = raw.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.StartsWith("<meta property=\"og:image\""))
                {
                    string[] l = line.Split(new string[] { "/" }, StringSplitOptions.None);
                    return "http://o.scdn.co/" + albumsize + @"/" + l[4].Replace("\"", "").Replace(">", "");
                }
            }
            return "";
        }
        public async Task<Bitmap> GetAlbumArtAsync(AlbumArtSize size)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                String url = GetAlbumArtURL(size);
                if (url == "")
                    return new Bitmap(640, 640);
                byte[] data = null;
                try
                {
                    data = await wc.DownloadDataTaskAsync(url);
                }
                catch(WebException e)
                {
                    throw;
                }
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }
        public Bitmap GetAlbumArt(AlbumArtSize size)
        {
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                String url = GetAlbumArtURL(size);
                if (url == "")
                    return new Bitmap(640,640);
                byte[] data = null;
                try
                {
                    data = wc.DownloadData(url);
                }
                catch (WebException e)
                {
                    throw;
                }
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (Bitmap)Image.FromStream(ms);
                }
            }
        }
    }
    public class TrackResource
    {
        public String name { get; set; }
        public String uri { get; set; }
        public TrackResourceLocation location { get; set; }
    }
    public class TrackResourceLocation
    {
        public String og { get; set; }
    }
    public class OpenGraphState
    {
        public Boolean private_session { get; set; }
        public Boolean posting_disabled { get; set; }
    }
}
