using System;

namespace SpotifyAPI.Web.Enums
{
    [Flags]
    public enum RepeatState
    {
        [String("track")]
        Track = 1,

        [String("context")]
        Context = 2,

        [String("off")]
        Off = 4
    }
}