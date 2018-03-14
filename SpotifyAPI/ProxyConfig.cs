using System;

namespace SpotifyAPI
{
    public class ProxyConfig
    {
        public string Host { get; set; }

        public int Port { get; set; } = 80;

        public string Username { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Whether to bypass the proxy server for local addresses.
        /// </summary>
        public bool BypassProxyOnLocal { get; set; }

        public void Set(ProxyConfig proxyConfig)
        {
            this.Host = proxyConfig?.Host;
            this.Port = proxyConfig?.Port ?? 80;
            this.Username = proxyConfig?.Username;
            this.Password = proxyConfig?.Password;
            this.BypassProxyOnLocal = proxyConfig?.BypassProxyOnLocal ?? false;
        }

        public Uri GetUri()
        {
            UriBuilder uriBuilder = new UriBuilder(Host)
            {
                Port = Port
            };
            return uriBuilder.Uri;
        }
    }
}