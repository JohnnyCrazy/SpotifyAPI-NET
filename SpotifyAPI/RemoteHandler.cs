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

        public static RemoteHandler GetInstance()
        {
            return instance;
        }
  
        public RemoteHandler()
        {
            wc = new WebClient();
            wc.Headers.Add("Origin", "https://embed.spotify.com");
            wc.Headers.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
        }
        public void Init()
        {
            oauthKey = GetOAuthKey();
            cfidKey = GetCFID();
        }
        private String GetOAuthKey()
        {
            String raw = "";
            try
            {
                raw = new WebClient().DownloadString("https://embed.spotify.com/openplay/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
            }
            catch(WebException e)
            {
                
            }
            raw = raw.Replace(" ", "");
            string[] lines = raw.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.StartsWith("tokenData"))
                {
                    string[] l = line.Split(new string[] { "'" }, StringSplitOptions.None);
                    return l[1];
                }
            }
            throw new Exception("OAuth Token konnte nicht gefunden werden");
        }

        private String GetCFID()
        {
            string a = recv("simplecsrf/token.json", false, false, -1);
            List<CFID> d = (List<CFID>)JsonConvert.DeserializeObject(a, typeof(List<CFID>));
            if (d.Count != 1)
                throw new Exception("CFID konnte nicht geladen werden.");
            return d[0].token;
        }
        private string recv(string request, bool oauth, bool cfid, int wait)
        {
            string parameters = "?&ref=&cors=&_=" + "";
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
    }
}
