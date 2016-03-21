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

        public SpotifyUri(string uri)
        {
            if (String.IsNullOrEmpty(uri))
                throw new ArgumentNullException("Uri");

            string[] props = uri.Split(':');

            if (props.Length != 3)
                throw new ArgumentException("Unexpected Uri");

            Base = props[0];
            Type = props[1];
            Id = props[2];
        }
    }
}
