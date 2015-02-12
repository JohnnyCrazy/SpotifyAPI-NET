using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.SpotifyWebAPI
{
    [Flags]
    public enum FollowType
    {
        [StringAttribute("artist")]
        ARTIST = 1,
        [StringAttribute("user")]
        USER = 2
    }
}
