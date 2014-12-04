using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using SpotifyAPI.SpotifyWebAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class ImplicitGrantAuth
    {
        public String ClientId { get; set; }
        public String RedirectUri { get; set; }
        public String State { get; set; }
        public Scope Scope { get; set; }
        public Boolean ShowDialog { get; set; }

        Thread httpThread;
        SimpleHttpServer httpServer;

        public delegate void OnResponseReceived(Token token,String state,String error);
        public event OnResponseReceived OnResponseReceivedEvent;

        public void DoAuth()
        {
            String uri = GetUri();
            Process.Start(uri);
        }
        private String GetUri()
        {
            StringBuilder builder = new StringBuilder("https://accounts.spotify.com/authorize/?");
            builder.Append("client_id=" + ClientId);
            builder.Append("&response_type=token");
            builder.Append("&redirect_uri=" + RedirectUri);
            builder.Append("&state=" + State);
            builder.Append("&scope=" + Scope.GetScopeValue(" "));
            builder.Append("&show_dialog=" + ShowDialog.ToString());
            return builder.ToString();
        }
        public void StartHttpServer()
        {
            httpServer = new SimpleHttpServer(80, SetResponse, AuthType.IMPLICIT);
            httpThread = new Thread(httpServer.listen); ;
            httpThread.Start();
        }
        public void SetResponse(String accessToken, String tokenType, int expiresIn,String state, String error)
        {
            if (OnResponseReceivedEvent != null)
                OnResponseReceivedEvent(new Token()
                {
                    AccessToken = accessToken,
                    TokenType = tokenType,
                    ExpiresIn = expiresIn
                },state,error);
        }
        public void StopHttpServer()
        {
            httpServer.Dispose();
            httpServer = null;
        }
    }
}
