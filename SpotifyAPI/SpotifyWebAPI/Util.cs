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
        public static string GetStringAttribute<T>(this T en, String separator) where T : struct, IConvertible
        {
            Enum e = (Enum)(object)en;
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(T))
            .Cast<T>()
            .Where(v => e.HasFlag((Enum)(object)v))
            .Select(v => typeof(T).GetField(v.ToString()))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach((element) => list.Add(element.Text));
            return string.Join(" ", list);
        }
    }
}
