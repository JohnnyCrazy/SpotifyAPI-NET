using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SpotifyAPI.Web
{
    public static class Util
    {
        public static string GetStringAttribute<T>(this T en, string separator) where T : struct, IConvertible
        {
            Enum e = (Enum)(object)en;
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(T))
            .Cast<T>()
            .Where(v => e.HasFlag((Enum)(object)v))
            .Select(v => typeof(T).GetField(v.ToString(CultureInfo.InvariantCulture)))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<string> list = new List<string>();
            attributes.ToList().ForEach(element => list.Add(element.Text));
            return string.Join(separator, list);
        }
    }

    public sealed class StringAttribute : Attribute
    {
        public string Text { get; set; }

        public StringAttribute(string text)
        {
            Text = text;
        }
    }
}
