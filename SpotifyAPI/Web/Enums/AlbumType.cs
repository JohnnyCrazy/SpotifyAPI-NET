using System;

namespace SpotifyAPI.Web.Enums
{
    [Flags]
    public enum AlbumType
    {
        [String("album")]
        Album = 1,

        [String("single")]
        Single = 2,

        [String("compilation")]
        Compilation = 4,

        [String("appears_on")]
        AppearsOn = 8,

        [String("album,single,compilation,appears_on")]
        All = 16
    }
}