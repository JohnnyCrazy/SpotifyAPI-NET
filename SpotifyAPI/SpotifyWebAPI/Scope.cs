using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.SpotifyWebAPI
{
    [Flags]
    public enum Scope
    {
        [StringAttribute("")]
        NONE = 1,
        [StringAttribute("playlist-modify-public")]
        PLAYLIST_MODIFY_PUBLIC = 2,
        [StringAttribute("playlist-modify-private")]
        PLAYLIST_MODIFY_PRIVATE = 4, 
        [StringAttribute("playlist-read-private")]
        PLAYLIST_READ_PRIVATE = 8,
        [StringAttribute("streaming")]
        STREAMING = 16,
        [StringAttribute("user-read-private")]
        USER_READ_PRIVATE = 32,
        [StringAttribute("user-read-email")]
        USER_READ_EMAIL = 64,
        [StringAttribute("user-library-read")]
        USER_LIBRARAY_READ = 128,
        [StringAttribute("user-library-modify")]
        USER_LIBRARY_MODIFY = 256
    }
}
