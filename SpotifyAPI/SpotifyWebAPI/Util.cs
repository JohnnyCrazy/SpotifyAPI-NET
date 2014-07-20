using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SpotifyAPI.SpotifyWebAPI.Models;

namespace SpotifyAPI.SpotifyWebAPI
{
    public static class Util
    {
        public static string GetScopeValue(this Scope en,String separator)
        {
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(Scope))
            .Cast<Scope>()
            .Where(v => en.HasFlag(v))
            .Select(v => typeof(Scope).GetField(v.ToString()))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach((element) => list.Add(element.Text));
            return string.Join(" ", list);
        }
        public static string GetSearchValue(this SearchType en, String separator)
        {
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(SearchType))
            .Cast<SearchType>()
            .Where(v => en.HasFlag(v))
            .Select(v => typeof(SearchType).GetField(v.ToString()))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach((element) => list.Add(element.Text));
            return string.Join(" ", list);
        }
        public static string GetAlbumValue(this AlbumType en, String separator)
        {
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(AlbumType))
            .Cast<AlbumType>()
            .Where(v => en.HasFlag(v))
            .Select(v => typeof(AlbumType).GetField(v.ToString()))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach((element) => list.Add(element.Text));
            return string.Join(" ", list);
        }
    }
}
