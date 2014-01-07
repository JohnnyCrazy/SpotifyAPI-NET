using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPIv1
{
    class Track
    {
        public String titel { get; private set; }
        public String artist { get; private set; }

        public Track(String titel,String artist)
        {
            this.titel = titel;
            this.artist = artist;
        }
    }
}
