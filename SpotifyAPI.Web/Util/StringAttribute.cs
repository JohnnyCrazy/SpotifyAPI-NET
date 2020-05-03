using System;

namespace SpotifyAPI.Web
{
  public class StringAttribute : Attribute
  {
    public StringAttribute(string value)
    {
      Value = value;
    }

    public string Value { get; set; }
  }
}
