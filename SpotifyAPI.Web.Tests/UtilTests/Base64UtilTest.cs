using System.Text;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class Base64UtilTest
  {
    [Test]
    public void Base64UrlDecode_Works()
    {
      var encoded = "SGVsbG9Xb3JsZA";

      Assert.That("HelloWorld", Is.EqualTo(Encoding.UTF8.GetString(Base64Util.UrlDecode(encoded))));
    }

    [Test]
    public void Base64UrlEncode_Works()
    {
      var decoded = "HelloWorld";

      Assert.That("SGVsbG9Xb3JsZA", Is.EqualTo(Base64Util.UrlEncode(Encoding.UTF8.GetBytes(decoded))));
    }

    [Test]
    public void Base64UrlEncode_WorksSpecialChars()
    {
      var bytes = new byte[] { 0x04, 0x9f, 0x9c, 0xff, 0x3f, 0x0a };

      // normal base64: BJ+c/z8K
      Assert.That("BJ-c_z8K", Is.EqualTo(Base64Util.UrlEncode(bytes)));
    }

    [Test]
    public void Base64UrlDecode_WorksSpecialChars()
    {
      var bytes = new byte[] { 0x04, 0x9f, 0x9c, 0xff, 0x3f, 0x0a };

      // normal base64: BJ+c/z8K
      Assert.That(bytes, Is.EqualTo(Base64Util.UrlDecode("BJ-c_z8K")));
    }
  }
}
