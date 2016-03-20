using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Local.Models
{
    public class SpotifyUri
    {
        public string Base { get; internal set; }
        public string Type { get; internal set; }
        public string Id { get; internal set; }

        public SpotifyUri(string Uri)
        {
            string[] props = Uri.Split(':');
            this.Base = props[0];
            this.Type = props[1];
            this.Id = props[2];
        }
    }
}
