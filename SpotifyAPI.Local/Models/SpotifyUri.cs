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

        public SpotifyUri(string uriBase, string uriType, string uriId)
        {
            Base = uriBase;
            Type = uriType;
            Id = uriId;
        }

        public static SpotifyUri Parse(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException("Uri");

            string[] props = uri.Split(':');
            if (props.Length != 3)
                throw new ArgumentException("Unexpected Uri");

            return new SpotifyUri(props[0], props[1], props[2]);
        }

        public override string ToString()
        {
            return $"{Base}:{Type}:{Id}";
        }
    }
}
