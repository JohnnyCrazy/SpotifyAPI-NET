using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;
using SpotifyAPI.Web.Models;
using Newtonsoft.Json;
#if NETSTANDARD2_0
using System.Net.Http;
#endif
#if NET46
using System.Net.Http;
using HttpListenerContext = Unosquare.Net.HttpListenerContext;
#endif

namespace SpotifyAPI.Web.Auth
{
    /// <summary>
    /// <para>
    /// A version of <see cref="AuthorizationCodeAuth"/> that does not store your client secret, client ID or redirect URI, enforcing a secure authorization flow. Requires an exchange server that will return the authorization code to its callback server via GET request.
    /// </para>
    /// <para>
    /// It's recommended that you use <see cref="SecureWebAPIFactory"/> if you would like to use the SecureAuthorizationCodeAuth method.
    /// </para>
    /// <para>
    /// If you are unsure what the exchange server is or how to make one, see <see href="https://johnnycrazy.github.io/SpotifyAPI-NET/SpotifyWebAPI/auth/#secureauthorizationcodeauth"/> (the SecureAuthorizationCodeAuth page on the SpotifyAPI-NET documentation).
    /// </para>
    /// </summary>
    public class SecureAuthorizationCodeAuth : SpotifyAuthServer<AuthorizationCode>
    {
        string exchangeServerUri;

        /// <summary>
        /// The HTML to respond with when the callback server (serverUri) is reached. The default value will close the window on arrival.
        /// </summary>
        public string HtmlResponse { get; set; } = "<script>window.close();</script>";

        /// <summary>
        /// <para>
        /// A version of <see cref="AuthorizationCodeAuth"/> that does not store your client secret, client ID or redirect URI, enforcing a secure authorization flow. Requires an exchange server that will return the authorization code to its callback server via GET request.
        /// </para>
        /// <para>
        /// If you are unsure what the exchange server is or how to make one, see <see href="https://johnnycrazy.github.io/SpotifyAPI-NET/SpotifyWebAPI/auth/#secureauthorizationcodeauth"/> (the SecureAuthorizationCodeAuth page on the SpotifyAPI-NET documentation).
        /// </para>
        /// </summary>
        /// <param name="exchangeServerUri">The URI to an exchange server that will perform the key exchange.</param>
        /// <param name="serverUri">The URI to host the server at that your exchange server should return the authorization code to by GET request. (e.g. http://localhost:4002)</param>
        /// <param name="scope"></param>
        /// <param name="state">Stating none will randomly generate a state parameter.</param>
        /// <param name="htmlResponse">The HTML to respond with when the callback server (serverUri) is reached. The default value will close the window on arrival.</param>
        public SecureAuthorizationCodeAuth(string exchangeServerUri, string serverUri, Scope scope = Scope.None, string state = "", string htmlResponse = "") : base("code", "", "", serverUri, scope, state)
        {
            if (!string.IsNullOrEmpty(htmlResponse))
            {
                HtmlResponse = htmlResponse;
            }

            this.exchangeServerUri = exchangeServerUri;
        }

        protected override WebServer AdaptWebServer(WebServer webServer) => webServer.WithWebApiController<SecureAuthorizationCodeAuthController>();

        public override string GetUri()
        {
            StringBuilder builder = new StringBuilder(exchangeServerUri);
            builder.Append("?");
            builder.Append("response_type=code");
            builder.Append("&state=" + State);
            builder.Append("&scope=" + Scope.GetStringAttribute(" "));
            builder.Append("&show_dialog=" + ShowDialog);
            return Uri.EscapeUriString(builder.ToString());
        }

        static readonly HttpClient httpClient = new HttpClient();

        const int MAX_GET_TOKEN_RETRIES = 10;

        /// <summary>
        /// Creates a HTTP request to obtain a token object.<para/>
        /// Parameter grantType can only be "refresh_token" or "authorization_code". authorizationCode and refreshToken are not mandatory, but at least one must be provided for your desired grant_type request otherwise an invalid response will be given and an exception is likely to be thrown.
        /// <para>
        /// Will re-attempt on error or null <see cref="MAX_GET_TOKEN_RETRIES"/> times before finally returning null.
        /// </para>
        /// </summary>
        /// <param name="grantType">Can only be "refresh_token" or "authorization_code".</param>
        /// <param name="authorizationCode">This needs to be defined if "grantType" is "authorization_code".</param>
        /// <param name="refreshToken">This needs to be defined if "grantType" is "refresh_token".</param>
        /// <param name="currentRetries">Does not need to be defined. Used internally for retry attempt recursion.</param>
        /// <returns></returns>
        async Task<Token> GetToken(string grantType, string authorizationCode = "", string refreshToken = "", int currentRetries = 0)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", grantType },
                    { "code", authorizationCode },
                    { "refresh_token", refreshToken }
                });

            try
            {
                var siteResponse = await httpClient.PostAsync(exchangeServerUri, content);
                Token token = JsonConvert.DeserializeObject<Token>(await siteResponse.Content.ReadAsStringAsync());
                if (!token.HasError())
                {
                    return token;
                }
            }
            catch { }

            if (currentRetries >= MAX_GET_TOKEN_RETRIES)
            {
                return null;
            }
            else
            {
                currentRetries++;
                // The reason I chose to implement the retries system this way is because a static or instance
                // variable keeping track would inhibit parallelism i.e. using this function on multiple threads/tasks.
                // It's not clear why someone would like to do that, but it's better to cater for all kinds of uses.
                return await GetToken(grantType, authorizationCode, refreshToken, currentRetries);
            }
        }

        System.Timers.Timer accessTokenExpireTimer;
        public event EventHandler OnAccessTokenExpired;

        void SetAccessExpireTimer(Token token)
        {
            if (accessTokenExpireTimer != null)
            {
                accessTokenExpireTimer.Stop();
                accessTokenExpireTimer.Dispose();
            }

            accessTokenExpireTimer = new System.Timers.Timer
            {
                Enabled = true,
                Interval = token.ExpiresIn * 1000,
                AutoReset = false
            };
            accessTokenExpireTimer.Elapsed += (sender, e) => OnAccessTokenExpired?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Uses the authorization code to silently (doesn't open a browser) obtain both an access token and refresh token, where the refresh token would be required for you to use <see cref="RefreshAuthAsync(string)"/>.
        /// </summary>
        /// <param name="authorizationCode"></param>
        /// <returns></returns>
        public async Task<Token> ExchangeCodeAsync(string authorizationCode)
        {
            Token token = await GetToken("authorization_code", authorizationCode: authorizationCode);
            if (token != null && !token.HasError())
            {
                SetAccessExpireTimer(token);
            }
            return token;
        }

        /// <summary>
        /// Uses the refresh token to silently (doesn't open a browser) obtain a fresh access token, no refresh token is given however (as it does not change).
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<Token> RefreshAuthAsync(string refreshToken)
        {
            Token token = await GetToken("refresh_token", refreshToken: refreshToken);
            if (token != null && !token.HasError())
            {
                SetAccessExpireTimer(token);
            }
            return token;
        }
    }

    internal class SecureAuthorizationCodeAuthController : WebApiController
    {
        [WebApiHandler(HttpVerbs.Get, "/")]
        public Task<bool> GetEmpty(WebServer server, HttpListenerContext context)
        {
            string state = context.Request.QueryString["state"];
            SecureAuthorizationCodeAuth.Instances.TryGetValue(state, out SpotifyAuthServer<AuthorizationCode> auth);

            string code = null;
            string error = context.Request.QueryString["error"];
            if (error == null)
            {
                code = context.Request.QueryString["code"];
            }

            Task.Factory.StartNew(() => auth?.TriggerAuth(new AuthorizationCode
            {
                Code = code,
                Error = error
            }));

            SecureAuthorizationCodeAuth secureAuth = (SecureAuthorizationCodeAuth)auth;
            return context.HtmlResponseAsync(secureAuth.HtmlResponse);
        }
    }
}
