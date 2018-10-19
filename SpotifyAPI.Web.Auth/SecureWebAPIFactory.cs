using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Auth
{
    /// <summary>
    /// Returns a SpotifyWebAPI using the SecureAuthorizationCodeAuth process.
    /// <para/>
    /// For more information, see <see href="https://johnnycrazy.github.io/SpotifyAPI-NET/SpotifyWebAPI/auth/#secureauthorizationcodeauth"/> (the SecureAuthorizationCodeAuth page on the SpotifyAPI-Net documentation).
    /// </summary>
    public class SecureWebAPIFactory
    {
        /// <summary>
        /// Access provided by Spotify expires after 1 hour. If true, access will attempt to be silently (without opening a browser) refreshed automatically.
        /// </summary>
        public bool AutoRefresh { get; set; }
        /// <summary>
        /// The maximum time in seconds to wait for a SpotifyWebAPI to be returned. The timeout is cancelled early regardless if an auth success or failure occured.
        /// </summary>
        public int Timeout { get; set; }
        public Scope Scope { get; set; }
        /// <summary>
        /// The URI (or URL) of the exchange server which exchanges the auth code for access and refresh tokens.
        /// </summary>
        public string ExchangeServerUri { get; set; }
        /// <summary>
        /// The URI (or URL) of where a callback server to receive the auth code will be hosted. e.g. http://localhost:4002
        /// </summary>
        public string HostServerUri { get; set; }

        /// <summary>
        /// Returns a SpotifyWebAPI using the SecureAuthorizationCodeAuth process. This will not work unless you implement an exchange server.
        /// <para/>
        /// For more information, see <see href="https://johnnycrazy.github.io/SpotifyAPI-NET/SpotifyWebAPI/auth/#secureauthorizationcodeauth"/> (the SecureAuthorizationCodeAuth page on the SpotifyAPI-Net documentation).
        /// </summary>
        /// <param name="exchangeServerUri">The URI (or URL) of the exchange server which exchanges the auth code for access and refresh tokens.</param>
        /// <param name="scope"></param>
        /// <param name="hostServerUri">The URI (or URL) of where a callback server to receive the auth code will be hosted. e.g. http://localhost:4002</param>
        /// <param name="timeout">The maximum time in seconds to wait for a SpotifyWebAPI to be returned. The timeout is cancelled early regardless if an auth success or failure occured.</param>
        /// <param name="autoRefresh">Access provided by Spotify expires after 1 hour. If true, access will attempt to be silently (without opening a browser) refreshed automatically.</param>
        public SecureWebAPIFactory(string exchangeServerUri, Scope scope = Scope.None, string hostServerUri = "http://localhost:4002", int timeout = 10, bool autoRefresh = false)
        {
            AutoRefresh = autoRefresh;
            Timeout = timeout;
            Scope = scope;
            ExchangeServerUri = exchangeServerUri;
            HostServerUri = hostServerUri;

            OnAccessTokenExpired += async (sender, e) =>
            {
                if (AutoRefresh)
                {
                    Token token = await lastAuth.RefreshAuthAsync(lastToken.RefreshToken);
                    if (token == null)
                    {
                        OnAuthFailure?.Invoke(this, new AuthFailureEventArgs($"Token not returned by server."));
                    }
                    else if (token.HasError())
                    {
                        OnAuthFailure?.Invoke(this, new AuthFailureEventArgs($"{token.Error} {token.ErrorDescription}"));
                    }
                    else
                    {
                        lastWebApi.AccessToken = token.AccessToken;
                    }
                }
            };
        }

        Token lastToken;
        SpotifyWebAPI lastWebApi;
        SecureAuthorizationCodeAuth lastAuth;

        /// <summary>
        /// Refreshes the access for a SpotifyWebAPI returned by this factory.
        /// </summary>
        /// <returns></returns>
        public async Task RefreshAuthAsync()
        {
            Token token = await lastAuth.RefreshAuthAsync(lastToken.RefreshToken);
            if (token != null)
            {
                lastWebApi.AccessToken = token.AccessToken;
            }
        }

        // By defining empty EventArgs objects, you can specify additional information later on as you see fit and it won't
        // be considered a breaking change to consumers of this API.
        //
        // They don't even need to be constructed for their associated events to be invoked - just pass the static Empty property.
        public class AccessTokenExpiredEventArgs : EventArgs
        {
            public static new AccessTokenExpiredEventArgs Empty { get; } = new AccessTokenExpiredEventArgs();

            public AccessTokenExpiredEventArgs()
            {
            }
        }
        public event EventHandler<AccessTokenExpiredEventArgs> OnAccessTokenExpired;

        public class AuthSuccessEventArgs : EventArgs
        {
            public static new AuthSuccessEventArgs Empty { get; } = new AuthSuccessEventArgs();

            public AuthSuccessEventArgs()
            {
            }
        }
        public event EventHandler<AuthSuccessEventArgs> OnAuthSuccess;

        public class AuthFailureEventArgs : EventArgs
        {
            public static new AuthFailureEventArgs Empty { get; } = new AuthFailureEventArgs("");

            public string Error { get; }

            public AuthFailureEventArgs(string error)
            {
                Error = error;
            }
        }
        public event EventHandler<AuthFailureEventArgs> OnAuthFailure;

        /// <summary>
        /// Gets an authorized and ready to use SpotifyWebAPI by following the SecureAuthorizationCodeAuth process with its current settings.
        /// </summary>
        /// <returns></returns>
        public async Task<SpotifyWebAPI> GetWebApiAsync()
        {
            return await Task<SpotifyWebAPI>.Factory.StartNew(() =>
            {
                bool currentlyAuthorizing = true;

                lastAuth = new SecureAuthorizationCodeAuth(
                    exchangeServerUri: ExchangeServerUri,
                    serverUri: HostServerUri,
                    scope: Scope);
                lastAuth.AuthReceived += async (sender, response) =>
                {
                    if (!string.IsNullOrEmpty(response.Error) || string.IsNullOrEmpty(response.Code))
                    {
                        OnAuthFailure?.Invoke(this, new AuthFailureEventArgs(response.Error));
                        currentlyAuthorizing = false;
                        return;
                    }

                    lastToken = await lastAuth.ExchangeCodeAsync(response.Code);

                    if (lastToken == null)
                    {
                        OnAuthFailure?.Invoke(this, new AuthFailureEventArgs("Exchange token not returned by server."));
                        currentlyAuthorizing = false;
                        return;
                    }

                    if (lastWebApi != null)
                    {
                        lastWebApi.Dispose();
                    }
                    lastWebApi = new SpotifyWebAPI()
                    {
                        TokenType = lastToken.TokenType,
                        AccessToken = lastToken.AccessToken
                    };

                    lastAuth.Stop();

                    OnAuthSuccess?.Invoke(this, AuthSuccessEventArgs.Empty);
                    currentlyAuthorizing = false;
                };
                lastAuth.OnAccessTokenExpired += (sender, e) => OnAccessTokenExpired?.Invoke(sender, AccessTokenExpiredEventArgs.Empty);
                lastAuth.Start();
                lastAuth.OpenBrowser();

                System.Timers.Timer timeout = new System.Timers.Timer
                {
                    AutoReset = false,
                    Enabled = true,
                    Interval = Timeout * 1000
                };

                while (currentlyAuthorizing && timeout.Enabled) ;

                return lastWebApi;
            });
        }
    }
}
