using Newtonsoft.Json;
using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;

[assembly: InternalsVisibleTo("SpotifyAPI.Tests")]


namespace SpotifyAPI.Local
{

    internal class RemoteHandler
    {
        public string OauthKey { get; private set; }
        public string CfidKey { get; private set; }

        private SpotifyLocalAPIConfig _config;

        public RemoteHandler(SpotifyLocalAPIConfig config)
        {
            _config = config;
        }

        internal Boolean Init()
        {
            OauthKey = GetOAuthKey();
            CfidKey = GetCfid();
            return !string.IsNullOrEmpty(CfidKey);
        }

        internal async Task SendPauseRequest()
        {
            var @params = new NameValueCollection() { { "pause", "true" } };
            await QueryAsync("remote/pause.json", true, true, -1, @params).ConfigureAwait(false);
        }

        internal async Task SendPlayRequest()
        {
            var @params = new NameValueCollection() { { "pause", "false" } };
            await QueryAsync("remote/pause.json", true, true, -1, @params).ConfigureAwait(false);
        }

        internal async Task SendPlayRequest(string url, string context = "")
        {

            // TODO: instead of having an empty context, one way to fix the bug with the playback time beyond the length of a song would be to provide a 1-song context, and it would be fixed.
            var @params = new NameValueCollection() { {"uri", url },
                { "context", context} };
            await QueryAsync($"remote/play.json", true, true, -1, @params).ConfigureAwait(false);

        }

        internal async Task SendQueueRequest(string url)
        {
            var @params = new NameValueCollection() { {"uri", url },
                { "action", "queue"} };
            await QueryAsync("remote/play.json", true, true, -1, @params).ConfigureAwait(false);

        }

        internal StatusResponse GetNewStatus()
        {
            string response = Query("remote/status.json", true, true, -1);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            response = response.Replace("\\n", "");
            List<StatusResponse> raw = JsonConvert.DeserializeObject<List<StatusResponse>>(response);
            return raw[0];
        }

        internal string GetOAuthKey()
        {
            string raw;
            using (WebClient wc = GetWebClientWithUserAgentHeader())
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

        internal string BuildQueryString(bool oauth, bool cfid, int wait, NameValueCollection @params = null)
        {
            if (@params == null)
            {
                @params = new NameValueCollection();
            }
            var queryParameter = HttpUtility.ParseQueryString(string.Empty);
            queryParameter.Add(@params);
            queryParameter.Add(new NameValueCollection() {
                { "ref", string.Empty},
                { "cors", string.Empty},
                { "_", GetTimestamp().ToString()}
            });
            if (oauth)
            {
                queryParameter.Add("oauth", OauthKey);
            }
            if (cfid)
            {
                queryParameter.Add("csrf", CfidKey);
            }

            if (wait != -1)
            {
                queryParameter.Add("returnafter", wait.ToString());
                queryParameter.Add("returnon", "login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap");
            }

            return queryParameter.ToString();
        }
        internal string Query(string baseUrl, bool oauth, bool cfid, int wait, NameValueCollection @params = null)
        {
            string parameters = BuildQueryString(oauth, cfid, wait, @params);
            string address = $"{_config.HostUrl}:{_config.Port}/{baseUrl}?{parameters}";
            string response = string.Empty;
            try
            {
                using (var wc = new ExtendedWebClient())
                {
                    if (SpotifyLocalAPI.IsSpotifyRunning())
                    {
                        response = "[ " + wc.DownloadString(address) + " ]";
                    }
                }
            }
            catch
            {
                return string.Empty;
            }

            return response;
        }

        internal async Task<string> QueryAsync(string baseUrl, bool oauth, bool cfid, int wait, NameValueCollection @params = null)
        {
            string parameters = BuildQueryString(oauth, cfid, wait, @params);
            string address = $"{_config.HostUrl}:{_config.Port}/{baseUrl}?{parameters}";
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

        internal WebClient GetWebClientWithUserAgentHeader()
        {
            var wc = new WebClient();

            wc.Headers.Add(HttpRequestHeader.UserAgent, "Spotify (1.0.50.41368.gbd68dbef)");

            return wc;
        }
    }
}