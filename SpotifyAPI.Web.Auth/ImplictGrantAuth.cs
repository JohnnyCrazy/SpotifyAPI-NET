using System;
using System.Net;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace SpotifyAPI.Web.Auth
{
    public class ImplictGrantAuth : SpotifyAuthServer<Token>
    {
        public ImplictGrantAuth(string clientId, string redirectUri, string serverUri, Scope scope = Scope.None, string state = "") :
            base("token", "ImplicitGrantAuth", redirectUri, serverUri, scope, state)
        {
            ClientId = clientId;
        }

        protected override WebServer AdaptWebServer(WebServer webServer)
        {
            Console.WriteLine("Hello");
            webServer.Module<WebApiModule>().RegisterController<ImplictGrantAuthController>();
            return webServer;
        }
    }

    public class ImplictGrantAuthController : WebApiController
    {
        [WebApiHandler(HttpVerbs.Get, "/authe")]
        public bool GetAuth(WebServer server, HttpListenerContext context)
        {
            string state = context.Request.QueryString["state"];
            SpotifyAuthServer<Token> auth = ImplictGrantAuth.GetByState(state);
            if (auth == null)
                return true; /*context.StringResponseAsync(
                    $"Failed - Unable to find auth request with state \"{state}\" - Please retry");*/

            Token token;
            string error = context.Request.QueryString["error"];
            if (error == null)
            {
                string accessToken = context.Request.QueryString["access_token"];
                string tokenType = context.Request.QueryString["token_type"];
                string expiresIn = context.Request.QueryString["expires_in"];
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

            Task.Factory.StartNew(() => auth?.TriggerAuth(token));
            return true;
            // return context.StringResponseAsync("OK - This window can be closed now");
        }
    }
}
