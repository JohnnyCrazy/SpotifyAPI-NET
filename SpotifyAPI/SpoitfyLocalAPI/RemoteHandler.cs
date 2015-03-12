using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyLocalAPI
{
    class RemoteHandler
    {
        private static RemoteHandler instance = new RemoteHandler();

        public String oauthKey { get; private set; }
        public String cfidKey { get; private set; }

        public String host = "SpotifyAPI.spotilocal.com";

        private class ExtendedWebClientInstance : ExtendedWebClient
        {
            internal ExtendedWebClientInstance()
            {
                Timeout = 2000;
                Proxy = null;
                Headers.Add("Origin", "https://embed.spotify.com");
                Headers.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
            }
        }

        internal static RemoteHandler GetInstance()
        {
            // Is this supposed to return the current instance?
            return instance;
        }

        internal RemoteHandler()
        {

        }

        internal Boolean Init()
        {
            oauthKey = GetOAuthKey();
            cfidKey = GetCFID();
            if (cfidKey == "")
                return false;
            return true;
        }

        internal async void SendPauseRequest()
        {
            await QueryAsync("remote/pause.json?pause=true", true, true, -1);
        }

        internal async void SendPlayRequest()
        {
            await QueryAsync("remote/pause.json?pause=false", true, true, -1);
        }

        internal async void SendPlayRequest(String url, String context = "")
        {
            // TODO: instead of having an empty context, one way to fix the bug with the playback time beyond the length of a song would be to provide a 1-song context, and it would be fixed.
            await QueryAsync(string.Format("remote/play.json?uri={0}&context={1}", url, context), true, true, -1);
        }

        internal async void SendQueueRequest(String url)
        {
            await QueryAsync("remote/play.json?uri=" + url + "?action=queue", true, true, -1);
        }

        internal StatusResponse Update()
        {
            String response = query("remote/status.json", true, true, -1);
            if (response == "")
            {
                return null;
            }
            response = response.Replace("\\n", "");
            byte[] bytes = Encoding.Default.GetBytes(response);
            response = Encoding.UTF8.GetString(bytes);
            List<StatusResponse> raw = (List<StatusResponse>)JsonConvert.DeserializeObject(response, typeof(List<StatusResponse>));
            return raw[0];
        }

        internal String GetOAuthKey()
        {
            String raw = "";
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                raw = wc.DownloadString("http://open.spotify.com/token");
            }
            Dictionary<String, object> lol = (Dictionary<String, object>)JsonConvert.DeserializeObject<Dictionary<String, object>>(raw);
            return (String)lol["t"];
        }

        internal string GetCFID()
        {
            string a = query("simplecsrf/token.json", false, false, -1);
            a = a.Replace(@"\", "");
            List<CFID> d = (List<CFID>)JsonConvert.DeserializeObject(a, typeof(List<CFID>));
            if (d == null)
                return "";
            if (d.Count != 1)
                throw new Exception("CFID couldn't be loaded");
            if (d[0].error != null)
                return "";
            return d[0].token;
        }

        internal string query(string request, bool oauth, bool cfid, int wait)
        {
            string parameters = "?&ref=&cors=&_=" + GetTimestamp();
            if (request.Contains("?"))
            {
                parameters = parameters.Substring(1);
            }

            if (oauth)
            {
                parameters += "&oauth=" + oauthKey;
            }
            if (cfid)
            {
                parameters += "&csrf=" + cfidKey;
            }

            if (wait != -1)
            {
                parameters += "&returnafter=" + wait;
                parameters += "&returnon=login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap";
            }

            string a = "http://" + host + ":4380/" + request + parameters;
            string response = "";
            try
            {
                //Need to find a better solution
                using (var wc = new ExtendedWebClientInstance())
                {
                    if (SpotifyLocalAPIClass.IsSpotifyRunning())
                        response = "[ " + wc.DownloadString(a) + " ]";
                }
            }
            catch (Exception z)
            {
                Console.WriteLine(z.Message);
                return "";
            }
            return response;
        }

        internal async Task<string> QueryAsync(string request, bool oauth, bool cfid, int wait)
        {
            string parameters = "?&ref=&cors=&_=" + GetTimestamp();
            if (request.Contains("?"))
            {
                parameters = parameters.Substring(1);
            }

            if (oauth)
            {
                parameters += "&oauth=" + oauthKey;
            }
            if (cfid)
            {
                parameters += "&csrf=" + cfidKey;
            }

            if (wait != -1)
            {
                parameters += "&returnafter=" + wait;
                parameters += "&returnon=login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap";
            }

        

            string a = "http://" + host + ":4380/" + request + parameters ;
            string response = "";
            try
            {
                //Need to find a better solution
                using (var wc = new ExtendedWebClientInstance())
                {
                    if (SpotifyLocalAPIClass.IsSpotifyRunning())
                        response = "[ " + await wc.DownloadStringTaskAsync(new Uri(a)) + " ]";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

            return response;
        }

        internal int GetTimestamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }
    }
}
