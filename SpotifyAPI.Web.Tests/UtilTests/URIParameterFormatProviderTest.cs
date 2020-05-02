using System.Collections.Generic;
using System;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class URIParameterFormatProviderTest
  {
    [Test]
    public void Format_NormalParameters()
    {
      var expected = "/users/wizzler";

      var user = "wizzler";
      var formatter = new URIParameterFormatProvider();
      string func(FormattableString str) => str.ToString(formatter);

      Assert.AreEqual(expected, func($"/users/{user}"));
    }

    [Test]
    public void Format_EscapedParameters()
    {
      var expected = "/users/++wizzler";

      var user = "  wizzler";
      var formatter = new URIParameterFormatProvider();
      string func(FormattableString str) => str.ToString(formatter);

      Assert.AreEqual(expected, func($"/users/{user}"));
    }
  }
}
