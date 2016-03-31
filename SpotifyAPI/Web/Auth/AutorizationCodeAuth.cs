using Newtonsoft.Json;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace SpotifyAPI.Web.Auth
{
    public class AutorizationCodeAuth
    {
        public delegate void OnResponseReceived(AutorizationCodeAuthResponse response);

        private SimpleHttpServer _httpServer;
        private Thread _httpThread;
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
        public Scope Scope { get; set; }
        public Boolean ShowDialog { get; set; }

        /// <summary>
        ///     Will be fired once the user authenticated
        /// </summary>
        public event OnResponseReceived OnResponseReceivedEvent;

        /// <summary>
        ///     Start the auth process (Make sure the internal HTTP-Server ist started)
        /// </summary>
        public void DoAuth()
        {
            string uri = GetUri();
            Process.Start(uri);
        }

        /// <summary>
        ///     Refreshes auth by providing the clientsecret (Don't use this if you're on a client)
        /// </summary>
        /// <param name="refreshToken">The refresh-token of the earlier gathered token</param>
        /// <param name="clientSecret">Your Client-Secret, don't provide it if this is running on a client!</param>
        public Token RefreshToken(string refreshToken, string clientSecret)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                wc.Headers.Add("Authorization",
                    "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + clientSecret)));
                NameValueCollection col = new NameValueCollection
                {
                    {"grant_type", "refresh_token"},
                    {"refresh_token", refreshToken}
                };

                string response;
                try
                {
                    byte[] data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                    response = Encoding.UTF8.GetString(data);
                }
                catch (WebException e)
                {
                    using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }
                }
                return JsonConvert.DeserializeObject<Token>(response);
            }
        }

        private string GetUri()
        {
            StringBuilder builder = new StringBuilder("https://accounts.spotify.com/authorize/?");
            builder.Append("client_id=" + ClientId);
            builder.Append("&response_type=code");
            builder.Append("&redirect_uri=" + RedirectUri);
            builder.Append("&state=" + State);
            builder.Append("&scope=" + Scope.GetStringAttribute(" "));
            builder.Append("&show_dialog=" + ShowDialog);
            return builder.ToString();
        }

        /// <summary>
        ///     Start the internal HTTP-Server
        /// </summary>
        public void StartHttpServer(int port = 80)
        {
            _httpServer = new SimpleHttpServer(port, AuthType.Authorization);
            _httpServer.OnAuth += HttpServerOnOnAuth;

            _httpThread = new Thread(_httpServer.Listen);
            _httpThread.Start();
        }

        private void HttpServerOnOnAuth(AuthEventArgs e)
        {
            OnResponseReceivedEvent?.Invoke(new AutorizationCodeAuthResponse()
            {
                Code = e.Code,
                State = e.State,
                Error = e.Error
            });
        }

        /// <summary>
        ///     This will stop the internal HTTP-Server (Should be called after you got the Token)
        /// </summary>
        public void StopHttpServer()
        {
            _httpServer.Dispose();
            _httpServer = null;
        }

        /// <summary>
        ///     Exchange a code for a Token (Don't use this if you're on a client)
        /// </summary>
        /// <param name="code">The gathered code from the response</param>
        /// <param name="clientSecret">Your Client-Secret, don't provide it if this is running on a client!</param>
        /// <returns></returns>
        public Token ExchangeAuthCode(string code, string clientSecret)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;

                NameValueCollection col = new NameValueCollection
                {
                    {"grant_type", "authorization_code"},
                    {"code", code},
                    {"redirect_uri", RedirectUri},
                    {"client_id", ClientId},
                    {"client_secret", clientSecret}
                };

                string response;
                try
                {
                    byte[] data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                    response = Encoding.UTF8.GetString(data);
                }
                catch (WebException e)
                {
                    using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }
                }
                return JsonConvert.DeserializeObject<Token>(response);
            }
        }
    }

    public struct AutorizationCodeAuthResponse
    {
        public string Code { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
    }
}
