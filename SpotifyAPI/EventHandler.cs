using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPIv1
{
    public class EventHandler
    {
        private Boolean listen = false;
        private Boolean blocked = false;
        private System.Timers.Timer timer;
        private SpotifyAPI api;
        private MusicHandler mh;

        private StatusResponse response;

        public delegate void NameChangeEventHandler(NameChangeEventArgs e);
        public delegate void PlayStateEventHandler(PlayStateEventArgs e);
        public delegate void VolumeChangeEventHandler(VolumeChangeEventArgs e);
        public event NameChangeEventHandler OnTrackNameChange;
        public event PlayStateEventHandler OnPlayStateChange;
        public event VolumeChangeEventHandler OnVolumeChange;

        public EventHandler(SpotifyAPI api, MusicHandler mh)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += tick;
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();

            this.api = api;
            this.mh = mh;
        }

        public void ListenForEvents(Boolean listen)
        {
            this.listen = listen;
        }

        public void tick(object sender, EventArgs e)
        {
            if (!listen || blocked)
            {
                timer.Start();
                return;
            }
            api.Update();
            if (response == null)
            {
                response = mh.GetStatusResponse();
                timer.Start();
                return;
            }
            StatusResponse new_response = mh.GetStatusResponse();
            if (new_response.track.GetName() != response.track.GetName() && OnTrackNameChange != null)
            {
                OnTrackNameChange(new NameChangeEventArgs()
                {
                    old_track = response.track,
                    new_track = new_response.track
                });
            }
            if (new_response.playing != response.playing && OnPlayStateChange != null)
            {
                OnPlayStateChange(new PlayStateEventArgs()
                {
                    playing = new_response.playing
                });
            }
            if (new_response.volume != response.volume && OnVolumeChange != null)
            {
                OnVolumeChange(new VolumeChangeEventArgs()
                {
                    old_volume = response.volume,
                    new_volume = new_response.volume
                });
            }
            response = new_response;
            timer.Start();
        }
    }
}
