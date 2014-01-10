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

        public String GetName()
        {
            return track_resource.name;
        }
        public int GetLength()
        {
            return length;
        }
        public String GetFormatedLength()
        {
            String format = "{0}:{1}";
            return String.Format(format, TimeSpan.FromSeconds(GetLength()).ToString("mm:ss"));
        }
        public String GetAlbum()
        {
            return album_resource.name;
        }
        public String GetArtist()
        {
            return artist_resource.name;
        }
        public String GetAlbumArtURL(SizeEnum size)
        {
            int albumsize = 0;
            switch (size)
            {
                case SizeEnum.SIZE_160:
                    albumsize = 160;
                    break;
                case SizeEnum.SIZE_320:
                    albumsize = 320;
                    break;
                case SizeEnum.SIZE_640:
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
        public Bitmap GetAlbumArt(SizeEnum size)
        {
            int albumsize = 0;
            switch (size)
            {
                case SizeEnum.SIZE_160:
                    albumsize = 160;
                    break;
                case SizeEnum.SIZE_320:
                    albumsize = 320;
                    break;
                case SizeEnum.SIZE_640:
                    albumsize = 640;
                    break;
            }
            String raw = "";
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                raw = wc.DownloadString("http://open.spotify.com/album/" + album_resource.uri.Split(new string[] { ":" }, StringSplitOptions.None)[2]);
                raw = raw.Replace("\t", ""); ;
                string[] lines = raw.Split(new string[] { "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line.StartsWith("<meta property=\"og:image\""))
                    {
                        string[] l = line.Split(new string[] { "/" }, StringSplitOptions.None);
                        String url = "http://o.scdn.co/" + albumsize + @"/" + l[4].Replace("\"", "").Replace(">", "");
                        using (MemoryStream ms = new MemoryStream(wc.DownloadData(url)))
                        {
                            return (Bitmap)Image.FromStream(ms);
                        }
                    }
                }
                return null;
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
