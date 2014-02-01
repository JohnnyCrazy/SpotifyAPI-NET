using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace SpotifyAPIv1
{
    class RemoteHandler
    {
        private static RemoteHandler instance = new RemoteHandler();

        public String oauthKey {get;private set;}
        public String cfidKey {get;private set;}

        public String host = "127.0.0.1";

        WebClient wc;
        SpotifyMusicHandler mh;
        internal static RemoteHandler GetInstance()
        {
            return instance;
        }

        internal RemoteHandler()
        {
            
            wc = new WebClient();
            wc.Proxy = null;
            wc.Headers.Add("Origin", "https://embed.spotify.com");
            wc.Headers.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
        }
        internal void Init()
        {
            oauthKey = GetOAuthKey();
            cfidKey = GetCFID();
        }
        internal void SendPauseRequest()
        {
            query("remote/pause.json?pause=true", true, true, -1);
        }
        internal void SendPlayRequest()
        {
            query("remote/pause.json?pause=false", true, true, -1);
        }
        internal void SendPlayRequest(String url)
        {
            query("remote/play.json?uri=" + url, true, true, -1);
        }
        public void SendVolumeRequest()
        {
            String s = query("remote/volume.json?volume=" + 50, false, false, -1);
        }
        internal StatusResponse Update()
        {
            String response = query("remote/status.json", true, true, -1);
            if(response == "")
            {
                return Update();
            }
            response = response.Replace("\\n", "");
            byte[] bytes = Encoding.Default.GetBytes(response);
            response = Encoding.UTF8.GetString(bytes);
            List<StatusResponse> raw = (List<StatusResponse>)JsonConvert.DeserializeObject(response,typeof(List<StatusResponse>));
            return raw[0];
        }
        private String GetOAuthKey()
        {
            String raw = "";
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                raw = wc.DownloadString("http://open.spotify.com/token");
            }
            Dictionary<String, object> lol = (Dictionary<String, object>)JsonConvert.DeserializeObject<Dictionary<String, object>>(raw);
            return (String)lol["t"];
        }

        private String GetCFID()
        {
            string a = query("simplecsrf/token.json", false, false, -1);
            a = a.Replace(@"\", "");
            List<CFID> d = (List<CFID>)JsonConvert.DeserializeObject(a, typeof(List<CFID>));
            if (d.Count != 1)
                throw new Exception("CFID couldn't be loaded");
            if (d[0].error != null)
                throw new Exception("SpotifyWebHelper Error: " + d[0].error.message);
            return d[0].token;
        }
        private string query(string request, bool oauth, bool cfid, int wait)
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
            string derp = "";
            try
            {
                derp = wc.DownloadString(a);
                derp = "[ " + derp + " ]";
            }
            catch (Exception z)
            {

            }
            return derp;
        }
        private int GetTimestamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }
    }
}
