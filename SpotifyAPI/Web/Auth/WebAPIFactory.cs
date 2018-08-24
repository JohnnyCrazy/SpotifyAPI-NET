using System;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Auth
{
    public class WebAPIFactory
    {
        private readonly string _redirectUrl;
        private readonly int _listeningPort;
        private readonly string _clientId;
        private readonly TimeSpan _timeout;
        private readonly Scope _scope;
        private readonly ProxyConfig _proxyConfig;
        private readonly string _xss;

        public WebAPIFactory(string redirectUrl, int listeningPort, string clientId, Scope scope)
            : this(redirectUrl, listeningPort, clientId, scope, null)
        {
        }

        public WebAPIFactory(string redirectUrl, int listeningPort, string clientId, Scope scope, ProxyConfig proxyConfig)
            : this(redirectUrl, listeningPort, clientId, scope, TimeSpan.FromSeconds(20), proxyConfig)
        {
        }

        public WebAPIFactory(string redirectUrl, int listeningPort, string clientId, Scope scope, TimeSpan timeout, string xss = "XSS")
            : this(redirectUrl, listeningPort, clientId, scope, timeout, null, xss)
        {
        }

        public WebAPIFactory(string redirectUrl, int listeningPort, string clientId, Scope scope, TimeSpan timeout, ProxyConfig proxyConfig, string xss = "XSS")
        {
            _redirectUrl = redirectUrl;
            _listeningPort = listeningPort;
            _clientId = clientId;
            _scope = scope;
            _timeout = timeout;
            _proxyConfig = proxyConfig;
            _xss = xss;
        }

        public Task<SpotifyWebAPI> GetWebApi(bool showDialog = false)
        {
            var authentication = new ImplicitGrantAuth
            {
                RedirectUri = new UriBuilder(_redirectUrl) { Port = _listeningPort }.Uri.OriginalString.TrimEnd('/'),
                ClientId = _clientId,
                Scope = _scope,
                ShowDialog = showDialog,
                State = _xss
            };

            AutoResetEvent authenticationWaitFlag = new AutoResetEvent(false);
            SpotifyWebAPI spotifyWebApi = null;
            authentication.OnResponseReceivedEvent += (token, state) =>
            {
                spotifyWebApi = HandleSpotifyResponse(state, token);
                authenticationWaitFlag.Set();
            };

            try
            {
                authentication.StartHttpServer(_listeningPort);

                authentication.DoAuth();

                authenticationWaitFlag.WaitOne(_timeout);
                if (spotifyWebApi == null)
                    throw new TimeoutException($"No valid response received for the last {_timeout.TotalSeconds} seconds");
            }
            finally
            {
                authentication.StopHttpServer();
            }

            return Task.FromResult(spotifyWebApi);
        }

        private SpotifyWebAPI HandleSpotifyResponse(string state, Token token)
        {
            if (state != _xss)
                throw new SpotifyWebApiException($"Wrong state '{state}' received.");

            if (token.Error != null)
                throw new SpotifyWebApiException($"Error: {token.Error}");
            
            var spotifyWebApi = new SpotifyWebAPI(_proxyConfig)
            {
                UseAuth = true,
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };

            return spotifyWebApi;
        }
    }

    [Serializable]
    public class SpotifyWebApiException : Exception
    {
        public SpotifyWebApiException(string message) : base(message)
        { }
    }
}
