using System;

namespace SpotifyAPI.Web.Enums
{
    [Flags]
    public enum Scope
    {
        [String("")]
        None = 1,

        [String("playlist-modify-public")]
        PlaylistModifyPublic = 2,

        [String("playlist-modify-private")]
        PlaylistModifyPrivate = 4,

        [String("playlist-read-private")]
        PlaylistReadPrivate = 8,

        [String("streaming")]
        Streaming = 16,

        [String("user-read-private")]
        UserReadPrivate = 32,

        [String("user-read-email")]
        UserReadEmail = 64,

        [String("user-library-read")]
        UserLibraryRead = 128,

        [String("user-library-modify")]
        UserLibraryModify = 256,

        [String("user-follow-modify")]
        UserFollowModify = 512,

        [String("user-follow-read")]
        UserFollowRead = 1024,

        [String("user-read-birthdate")]
        UserReadBirthdate = 2048,

        [String("user-top-read")]
        UserTopRead = 4096,

        [String("playlist-read-collaborative")]
        PlaylistReadCollaborative = 8192
    }
}