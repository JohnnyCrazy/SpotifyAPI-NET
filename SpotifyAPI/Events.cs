using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPIv1
{
    public class TrackChangeEventArgs
    {
        public Track old_track { get; set; }
        public Track new_track { get; set; }
    }
    public class PlayStateEventArgs
    {
        public Boolean playing { get; set; }
    }
    public class VolumeChangeEventArgs
    {
        public double old_volume { get; set; }
        public double new_volume { get; set; }
    }
    public class TrackTimeChangeEventArgs
    {
        public double track_time { get; set; }
    }
}
