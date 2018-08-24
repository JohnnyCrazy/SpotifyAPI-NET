using System;
using NUnit.Framework;
using SpotifyAPI.Web;

namespace SpotifyAPI.Tests
{
    [TestFixture]
    public class UtilTest
    {
        [Test]
        public void TimestampShouldBeNoFloatingPoint()
        {
            string timestamp = DateTime.Now.ToUnixTimeMillisecondsPoly().ToString();

            StringAssert.DoesNotContain(".", timestamp);
            StringAssert.DoesNotContain(",", timestamp);
        }
    }
}