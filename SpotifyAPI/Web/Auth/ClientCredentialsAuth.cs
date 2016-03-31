using Newtonsoft.Json;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace SpotifyAPI.Web.Auth
{
    public class ClientCredentialsAuth
    {
        public Scope Scope { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Starts the auth process and
        /// </summary>
        /// <returns>A new Token</returns>
        public Token DoAuth()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                wc.Headers.Add("Authorization",
                    "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret)));

                NameValueCollection col = new NameValueCollection
                {
                    {"grant_type", "client_credentials"},
                    {"scope", Scope.GetStringAttribute(" ")}
                };

                byte[] data;
                try
                {
                    data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                }
                catch (WebException e)
                {
                    using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                    {
                        data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                    }
                }
                return JsonConvert.DeserializeObject<Token>(Encoding.UTF8.GetString(data));
            }
        }
    }
}