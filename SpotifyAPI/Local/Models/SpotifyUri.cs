using SpotifyAPI.Local.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Local.Models
{
    public class SpotifyUri
    {
        private readonly Dictionary<UriType, string> _properties = new Dictionary<UriType, string>();

        public string Base { get; }
        public UriType Type => _properties?.LastOrDefault().Key ?? UriType.none;
        public string Id => _properties?.LastOrDefault().Value;

        public SpotifyUri(string uriBase, Dictionary<UriType, string> properties)
        {
            Base = uriBase;
            _properties = properties;
        }

        public SpotifyUri(string uriBase, UriType uriType, string uriId)
        {
            Base = uriBase;
            _properties.Add(uriType, uriId);
        }

        public string GetUriPropValue(UriType type)
        {
            return !_properties.ContainsKey(type) ? null : _properties[type];
        }

        public static SpotifyUri Parse(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException("Uri");

            string[] props = uri.Split(':');
            if (props.Length < 3 || !Enum.TryParse(props[1], out UriType uriType))
                throw new ArgumentException("Unexpected Uri");

            Dictionary<UriType, string> properties = new Dictionary<UriType, string> { { uriType, props[2] } };

            for (int index = 3; index < props.Length; index += 2)
            {
                if (Enum.TryParse(props[index], out UriType type))
                    properties.Add(type, props[index + 1]);
            }

            return new SpotifyUri(props[0], properties);
        }

        public override string ToString()
        {
            return $"{Base}:{string.Join(":", _properties.SelectMany(x => new[] { x.Key.ToString(), x.Value }))}";
        }
    }
}
