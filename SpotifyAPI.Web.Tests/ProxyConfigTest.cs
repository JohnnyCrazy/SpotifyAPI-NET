using System;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
    [TestFixture]
    public class ProxyConfigTest
    {
        #region GetUri

        [Test]
        public void GetUri_HostNameWithScheme()
        {
            ProxyConfig config = new ProxyConfig { Host = "https://test-host.com" };
            CheckUri(config.GetUri(), "https", "test-host.com", 80);
        }

        [Test]
        public void GetUri_HostNameWithoutScheme()
        {
            ProxyConfig config = new ProxyConfig { Host = "test-host.com" };
            CheckUri(config.GetUri(), "http", "test-host.com", 80);
        }

        [Test]
        public void GetUri_HostNameWithSchemeAndPort()
        {
            ProxyConfig config = new ProxyConfig
            {
                Host = "https://test-host.com",
                Port = 8080
            };
            CheckUri(config.GetUri(), "https", "test-host.com", 8080);
        }

        [Test]
        public void GetUri_HostAddressWithScheme()
        {
            ProxyConfig config = new ProxyConfig { Host = "https://192.168.0.1" };
            CheckUri(config.GetUri(), "https", "192.168.0.1", 80);
        }

        [Test]
        public void GetUri_HostAddressWithoutScheme()
        {
            ProxyConfig config = new ProxyConfig { Host = "192.168.0.1" };
            CheckUri(config.GetUri(), "http", "192.168.0.1", 80);
        }

        [Test]
        public void GetUri_HostAddressWithSchemeAndPort()
        {
            ProxyConfig config = new ProxyConfig
            {
                Host = "https://192.168.0.1",
                Port = 8080
            };
            CheckUri(config.GetUri(), "https", "192.168.0.1", 8080);
        }

        [Test]
        public void GetUri_NullHost()
        {
            ProxyConfig config = new ProxyConfig { Host = null };
            Assert.Throws<ArgumentNullException>(() => config.GetUri());
        }

        [Test]
        public void GetUri_EmptyHost()
        {
            ProxyConfig config = new ProxyConfig { Host = string.Empty };
            Assert.Throws<UriFormatException>(() => config.GetUri());
        }

        [Test]
        public void GetUri_NegativePort()
        {
            ProxyConfig config = new ProxyConfig
            {
                Host = "test-host.com",
                Port = -10
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => config.GetUri());
        }

        #endregion GetUri

        [Test]
        public void Set_Null()
        {
            ProxyConfig config = new ProxyConfig
            {
                Host = "https://test-host.com",
                Port = 1234,
                Username = "admin",
                Password = "password",
                BypassProxyOnLocal = true
            };
            config.Set(null);

            Assert.NotNull(config);
            Assert.Null(config.Host);
            Assert.AreEqual(80, config.Port);
            Assert.Null(config.Username);
            Assert.Null(config.Password);
            Assert.False(config.BypassProxyOnLocal);
        }

        private static void CheckUri(Uri uri, string expectedScheme, string expectedHost, int expectedPort)
        {
            Assert.AreEqual(expectedScheme, uri.Scheme);
            Assert.AreEqual(expectedHost, uri.Host);
            Assert.AreEqual(expectedPort, uri.Port);
        }
    }
}