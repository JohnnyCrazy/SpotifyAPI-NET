using System.Web;
using System;
namespace SpotifyAPI.Web
{
  public class URIParameterFormatProvider : IFormatProvider
  {
    private readonly URIParameterFormatter _formatter;

    public URIParameterFormatProvider()
    {
      _formatter = new URIParameterFormatter();
    }

    public object GetFormat(Type formatType)
    {
      if (formatType == typeof(ICustomFormatter))
        return _formatter;
      return null;
    }

    class URIParameterFormatter : ICustomFormatter
    {
      public string Format(string format, object arg, IFormatProvider formatProvider)
      {
        return HttpUtility.UrlEncode(arg.ToString());
      }
    }
  }
}
