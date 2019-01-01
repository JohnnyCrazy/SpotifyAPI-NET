using System;
using System.Net;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;
#if NETSTANDARD2_0
using System.Net.Http;
#endif
#if NET46
using System.Net.Http;
using HttpListenerContext = Unosquare.Net.HttpListenerContext;
#endif

namespace SpotifyAPI.Web.Auth
{
    public class ImplictGrantAuth : SpotifyAuthServer<Token>
    {
        public ImplictGrantAuth(string clientId, string redirectUri, string serverUri, Scope scope = Scope.None, string state = "") :
            base("token", "ImplicitGrantAuth", redirectUri, serverUri, scope, state)
        {
            ClientId = clientId;
        }

        protected override void AdaptWebServer(WebServer webServer)
        {
            webServer.Module<WebApiModule>().RegisterController<ImplictGrantAuthController>();
        }
    }

    public class ImplictGrantAuthController : WebApiController
    {
        [WebApiHandler(HttpVerbs.Get, "/auth")]
        public Task<bool> GetAuth()
        {
            string state = Request.QueryString["state"];
            SpotifyAuthServer<Token> auth = ImplictGrantAuth.GetByState(state);
            if (auth == null)
                return this.StringResponseAsync(
                    $"Failed - Unable to find auth request with state \"{state}\" - Please retry");

            Token token;
            string error = Request.QueryString["error"];
            if (error == null)
            {
                string accessToken = Request.QueryString["access_token"];
                string tokenType = Request.QueryString["token_type"];
                string expiresIn = Request.QueryString["expires_in"];
                token = new Token
                {
                    AccessToken = accessToken,
                    ExpiresIn = double.Parse(expiresIn),
                    TokenType = tokenType
                };
            }
            else
            {
                token = new Token()
                {
                    Error = error
                };
            }

            Task.Factory.StartNew(() => auth.TriggerAuth(token));
            return this.StringResponseAsync("OK - This window can be closed now");
        }

        public ImplictGrantAuthController(IHttpContext context) : base(context)
        {
        }
    }
}
