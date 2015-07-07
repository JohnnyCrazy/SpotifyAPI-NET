using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SpotifyAPI.Web
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
            .Select(v => typeof(T).GetField(v.ToString(CultureInfo.InvariantCulture)))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach(element => list.Add(element.Text));
            return string.Join(" ", list);
        }
    }

    public class StringAttribute : Attribute
    {
        public String Text { get; set; }
        public StringAttribute(String text)
        {
            Text = text;
        }
    }
}
