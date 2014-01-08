using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPIv1
{
    public class MusicHandler
    {
        RemoteHandler rh;
        StatusResponse sr;
        public MusicHandler()
        {
            rh = RemoteHandler.GetInstance();
        }
        public Boolean IsPlaying()
        {
            return sr.playing;
        }

        public Track GetCurrentTrack()
        {
            return sr.track;
        }

        public StatusResponse GetStatusResponse()
        {
            return sr;
        }

        internal void Update(StatusResponse sr)
        {
            this.sr = sr;
        }
    }
}
