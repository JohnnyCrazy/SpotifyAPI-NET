using System;
using System.Net;

namespace SpotifyAPI.Web
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
            Host = proxyConfig?.Host;
            Port = proxyConfig?.Port ?? 80;
            Username = proxyConfig?.Username;
            Password = proxyConfig?.Password;
            BypassProxyOnLocal = proxyConfig?.BypassProxyOnLocal ?? false;
        }

        /// <summary>
        /// Whether both <see cref="Host"/> and <see cref="Port"/> have valid values.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Host) && Port > 0;
        }

        /// <summary>
        /// Create a <see cref="Uri"/> from the host and port number
        /// </summary>
        /// <returns>A URI</returns>
        public Uri GetUri()
        {
            UriBuilder uriBuilder = new UriBuilder(Host)
            {
                Port = Port
            };
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Creates a <see cref="WebProxy"/> from the proxy details of this object.
        /// </summary>
        /// <returns>A <see cref="WebProxy"/> or <code>null</code> if the proxy details are invalid.</returns>
        public WebProxy CreateWebProxy()
        {
            if (!IsValid())
                return null;

            WebProxy proxy = new WebProxy
            {
                Address = GetUri(),
                UseDefaultCredentials = true,
                BypassProxyOnLocal = BypassProxyOnLocal
            };

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) 
                return proxy;
            
            proxy.UseDefaultCredentials = false;
            proxy.Credentials = new NetworkCredential(Username, Password);

            return proxy;
        }
    }
}