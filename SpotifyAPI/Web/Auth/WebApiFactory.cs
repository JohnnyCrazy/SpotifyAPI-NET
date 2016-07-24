using System;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Auth
{
    public class WebApiFactory
    {
        private readonly string m_RedirectUrl;
        private readonly int m_ListeningPort;
        private readonly string m_ClientId;
        private readonly TimeSpan m_Timeout;
        private Scope m_Scope;

        public WebApiFactory(string redirectUrl, int listeningPort, string clientId, Scope scope, TimeSpan timeout)
        {
            m_RedirectUrl = redirectUrl;
            m_ListeningPort = listeningPort;
            m_ClientId = clientId;
            m_Scope = scope;
            m_Timeout = timeout;
        }

        public Task<SpotifyWebAPI> GetWebApi()
        {
            var authentication = new ImplicitGrantAuth
            {
                RedirectUri = $"{m_RedirectUrl}:{m_ListeningPort}",
                ClientId = m_ClientId,
                Scope = m_Scope,
                State = "XSS"
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
                authentication.StartHttpServer(m_ListeningPort);

                authentication.DoAuth();

                authenticationWaitFlag.WaitOne(m_Timeout);
                if (spotifyWebApi == null)
                    throw new TimeoutException($"No valid response received for the last {m_Timeout.TotalSeconds} seconds");
            }
            finally
            {
                authentication.StopHttpServer();
            }

            return Task.FromResult(spotifyWebApi);
        }

        private static SpotifyWebAPI HandleSpotifyResponse(string state, Token token)
        {
            if (state != "XSS")
                throw new SpotifyWebApiException($"Wrong state '{state}' received.");

            if (token.Error != null)
                throw new SpotifyWebApiException($"Error: {token.Error}");
            
            var spotifyWebApi = new SpotifyWebAPI
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
