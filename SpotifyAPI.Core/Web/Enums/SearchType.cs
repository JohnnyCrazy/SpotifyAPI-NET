using System;

namespace SpotifyAPI.Web.Enums
{
    [Flags]
    public enum SearchType
    {
        [String("artist")]
        Artist = 1,

        [String("album")]
        Album = 2,

        [String("track")]
        Track = 4,

        [String("playlist")]
        Playlist = 8,

        [String("track,album,artist,playlist")]
        All = 16
    }
}