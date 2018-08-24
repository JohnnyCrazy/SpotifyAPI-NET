using System;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
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