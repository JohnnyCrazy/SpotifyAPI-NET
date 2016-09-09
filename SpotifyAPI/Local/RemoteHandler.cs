using Newtonsoft.Json;
using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Local
{
    internal class RemoteHandler
    {
        public string OauthKey { get; private set; }
        public string CfidKey { get; private set; }

        public const string Host = "SpotifyAPI.spotilocal.com";

        internal Boolean Init()
        {
            OauthKey = GetOAuthKey();
            CfidKey = GetCfid();
            return !string.IsNullOrEmpty(CfidKey);
        }

        internal async Task SendPauseRequest()
        {
            await QueryAsync("remote/pause.json?pause=true", true, true, -1).ConfigureAwait(false);
        }

        internal async Task SendPlayRequest()
        {
            await QueryAsync("remote/pause.json?pause=false", true, true, -1).ConfigureAwait(false);
        }

        internal async Task SendPlayRequest(string url, string context = "")
        {
            // TODO: instead of having an empty context, one way to fix the bug with the playback time beyond the length of a song would be to provide a 1-song context, and it would be fixed.
            await QueryAsync($"remote/play.json?uri={url}&context={context}", true, true, -1).ConfigureAwait(false);
        }

        internal async Task SendQueueRequest(string url)
        {
            await QueryAsync("remote/play.json?uri=" + url + "?action=queue", true, true, -1).ConfigureAwait(false);
        }

        internal StatusResponse GetNewStatus()
        {
            string response = Query("remote/status.json", true, true, -1);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            response = response.Replace("\\n", "");
            byte[] bytes = Encoding.Default.GetBytes(response);
            response = Encoding.UTF8.GetString(bytes);
            List<StatusResponse> raw = JsonConvert.DeserializeObject<List<StatusResponse>>(response);
            return raw[0];
        }

        internal string GetOAuthKey()
        {
            string raw;
            using (WebClient wc = new WebClient())
            {
                raw = wc.DownloadString("http://open.spotify.com/token");
            }
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw);
            return dic == null ? "" : (string)dic["t"];
        }

        internal string GetCfid()
        {
            string response = Query("simplecsrf/token.json", false, false, -1);
            response = response.Replace(@"\", "");
            List<Cfid> cfidList = (List<Cfid>)JsonConvert.DeserializeObject(response, typeof(List<Cfid>));
            if (cfidList == null)
                return "";
            if (cfidList.Count != 1)
                throw new Exception("CFID could not be loaded");
            return cfidList[0].Error == null ? cfidList[0].Token : "";
        }

        internal string Query(string request, bool oauth, bool cfid, int wait)
        {
            string parameters = "?&ref=&cors=&_=" + GetTimestamp();
            if (request.Contains("?"))
            {
                parameters = parameters.Substring(1);
            }

            if (oauth)
            {
                parameters += "&oauth=" + OauthKey;
            }
            if (cfid)
            {
                parameters += "&csrf=" + CfidKey;
            }

            if (wait != -1)
            {
                parameters += "&returnafter=" + wait;
                parameters += "&returnon=login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap";
            }

            string address = "https://" + Host + ":4371/" + request + parameters;
            string response = "";
            try
            {
                using (var wc = new ExtendedWebClient())
                {
                    if (SpotifyLocalAPI.IsSpotifyRunning())
                        response = "[ " + wc.DownloadString(address) + " ]";
                }
            }
            catch
            {
                return string.Empty;
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
                parameters += "&oauth=" + OauthKey;
            }
            if (cfid)
            {
                parameters += "&csrf=" + CfidKey;
            }

            if (wait != -1)
            {
                parameters += "&returnafter=" + wait;
                parameters += "&returnon=login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap";
            }

            string address = "https://" + Host + ":4371/" + request + parameters;
            string response = "";
            try
            {
                using (var wc = new ExtendedWebClient())
                {
                    if (SpotifyLocalAPI.IsSpotifyRunning())
                        response = "[ " + await wc.DownloadStringTaskAsync(new Uri(address)).ConfigureAwait(false) + " ]";
                }
            }
            catch
            {
                return string.Empty;
            }

            return response;
        }

        internal int GetTimestamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }
    }
}