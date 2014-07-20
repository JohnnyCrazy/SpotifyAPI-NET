using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Specialized;
using Newtonsoft.Json;
using SpotifyAPI.SpotifyWebAPI.Models;
using System.IO;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class AutorizationCodeAuth
    {
        public String ClientId { get; set; }
        public String RedirectUri { get; set; }
        public String State { get; set; }
        public Scope Scope { get; set; }
        public Boolean ShowDialog { get; set; }

        Thread httpThread;
        SimpleHttpServer httpServer;

        public delegate void OnResponseReceived(AutorizationCodeAuthResponse response);
        public event OnResponseReceived OnResponseReceivedEvent;

        public void DoAuth()
        {
            String uri = GetUri();
            Process.Start(uri);
        }
        /// <summary>
        /// Also don't use this, you would need to provide your clientSecretKey
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public Token RefreshToken(String refreshToken,String clientSecret)
        {
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                wc.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + clientSecret)));
                NameValueCollection col = new NameValueCollection();
                col.Add("grant_type", "refresh_token");
                col.Add("refresh_token", refreshToken);

                String response = "";
                try
                {
                    byte[] data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                    response = Encoding.UTF8.GetString(data);
                }catch(WebException e)
                {
                    response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                }
                return JsonConvert.DeserializeObject<Token>(response);
            }
        }
        private String GetUri()
        {
            StringBuilder builder = new StringBuilder("https://accounts.spotify.com/authorize/?");
            builder.Append("client_id=" + ClientId);
            builder.Append("&response_type=code");
            builder.Append("&redirect_uri=" + RedirectUri);
            builder.Append("&state=" + State);
            builder.Append("&scope=" + Scope.GetScopeValue(" "));
            builder.Append("&show_dialog=" + ShowDialog.ToString());
            return builder.ToString();
        }
        public void StartHttpServer()
        {
            httpServer = new SimpleHttpServer(80, SetResponse,AuthType.AUTHORIZATION);
            httpThread = new Thread(httpServer.listen); ;
            httpThread.Start();
        }
        public void SetResponse(String code,String state,String error)
        {
            if (OnResponseReceivedEvent != null)
                OnResponseReceivedEvent(new AutorizationCodeAuthResponse() { Code = code, State = state, Error = error });
        }
        public void StopHttpServer()
        {
            httpServer = null;
        }
        /// <summary>
        /// Don't use this!!! Use a PHP-Script or sth...
        /// </summary>
        public Token ExchangeAuthCode(String code,String clientSecret)
        {
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;

                NameValueCollection col = new NameValueCollection();
                col.Add("grant_type","authorization_code");
                col.Add("code",code);
                col.Add("redirect_uri", RedirectUri);
                col.Add("client_id", ClientId);
                col.Add("client_secret", clientSecret);

                String response = "";
                try
                {
                    byte[] data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                    response = Encoding.UTF8.GetString(data);
                }catch(WebException e)
                {
                    response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                }
                return JsonConvert.DeserializeObject<Token>(response);
            }
        }
    }
    public struct AutorizationCodeAuthResponse
    {
        public String Code { get; set; }
        public String State { get; set; }
        public String Error { get; set; }
    }
}
