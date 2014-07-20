using System;
using System.Text;

namespace SpotifyAPI.SpotifyLocalAPI
{
    /// <summary>
    /// Event gets triggered, when the Track is changed
    /// </summary>
    public class TrackChangeEventArgs
    {
        public Track old_track { get; set; }
        public Track new_track { get; set; }
    }
    /// <summary>
    /// Event gets triggered, when the Playin-state is changed (e.g Play --> Pause)
    /// </summary>
    public class PlayStateEventArgs
    {
        public Boolean playing { get; set; }
    }
    /// <summary>
    /// Event gets triggered, when the volume changes
    /// </summary>
    public class VolumeChangeEventArgs
    {
        public double old_volume { get; set; }
        public double new_volume { get; set; }
    }
    /// <summary>
    /// Event gets triggered, when the tracktime changes
    /// </summary>
    public class TrackTimeChangeEventArgs
    {
        public double track_time { get; set; }
    }
}
