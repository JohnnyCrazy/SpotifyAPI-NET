using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.SpotifyWebAPI
{
    [Flags]
    public enum AlbumType
    {
        [StringAttribute("album")]
        ALBUM = 1,
        [StringAttribute("single")]
        SINGLE = 2,
        [StringAttribute("compilation")]
        COMPILATION = 4,
        [StringAttribute("appears_on")]
        APPEARS_ON = 8,
        [StringAttribute("album,single,compilation,appears_on")]
        ALL = 16
    }
}
