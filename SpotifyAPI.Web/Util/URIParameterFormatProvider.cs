using System;
using System.Web;
namespace SpotifyAPI.Web
{
  public class URIParameterFormatProvider : IFormatProvider
  {
    private readonly URIParameterFormatter _formatter;

    public URIParameterFormatProvider()
    {
      _formatter = new URIParameterFormatter();
    }

    public object? GetFormat(Type? formatType)
    {
      return formatType == typeof(ICustomFormatter) ? _formatter : null;
    }

    private class URIParameterFormatter : ICustomFormatter
    {
      public string Format(string? format, object? arg, IFormatProvider? formatProvider)
      {
        return HttpUtility.UrlEncode(arg?.ToString()) ?? string.Empty;
      }
    }
  }
}
