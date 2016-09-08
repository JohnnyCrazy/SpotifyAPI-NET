using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    internal class SpotifyWebClient : IClient
    {
        public JsonSerializerSettings JsonSettings { get; set; }

        private readonly WebClient _webClient;
        private readonly Encoding _encoding = Encoding.UTF8;

        public SpotifyWebClient()
        {
            _webClient = new WebClient()
            {
                Proxy = null,
                Encoding = _encoding
            };
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public Tuple<ResponseInfo, string> Download(string url)
        {
            Tuple<ResponseInfo, string> response;
            try
            {
                Tuple<ResponseInfo, byte[]> raw = DownloadRaw(url);
                response = new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = new Tuple<ResponseInfo, string>(new ResponseInfo
                    {
                        Headers = _webClient.ResponseHeaders
                    }, reader.ReadToEnd());
                }
            }
            return response;
        }

        public async Task<Tuple<ResponseInfo, string>> DownloadAsync(string url)
        {
            Tuple<ResponseInfo, string> response;
            try
            {
                Tuple<ResponseInfo, byte[]> raw = await DownloadRawAsync(url).ConfigureAwait(false);
                response = new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = new Tuple<ResponseInfo, string>(new ResponseInfo
                    {
                        Headers = _webClient.ResponseHeaders
                    }, reader.ReadToEnd());
                }
            }
            return response;
        }

        public Tuple<ResponseInfo, byte[]> DownloadRaw(string url)
        {
            byte[] data = _webClient.DownloadData(url);
            ResponseInfo info = new ResponseInfo()
            {
                Headers = _webClient.ResponseHeaders
            };
            return new Tuple<ResponseInfo, byte[]>(info, data);
        }

        public async Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Proxy = null;
                webClient.Encoding = _encoding;
                webClient.Headers = _webClient.Headers;

                byte[] data = await _webClient.DownloadDataTaskAsync(url).ConfigureAwait(false);
                ResponseInfo info = new ResponseInfo()
                {
                    Headers = webClient.ResponseHeaders
                };
                return new Tuple<ResponseInfo, byte[]>(info, data);
            }
        }

        public Tuple<ResponseInfo, T> DownloadJson<T>(string url)
        {
            Tuple<ResponseInfo, string> response = Download(url);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public async Task<Tuple<ResponseInfo, T>> DownloadJsonAsync<T>(string url)
        {
            Tuple<ResponseInfo, string> response = await DownloadAsync(url).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public Tuple<ResponseInfo, string> Upload(string url, string body, string method)
        {
            Tuple<ResponseInfo, string> response;
            try
            {
                Tuple<ResponseInfo, byte[]> data = UploadRaw(url, body, method);
                response = new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = new Tuple<ResponseInfo, string>(new ResponseInfo
                    {
                        Headers = _webClient.ResponseHeaders
                    }, reader.ReadToEnd());
                }
            }
            return response;
        }

        public async Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method)
        {
            Tuple<ResponseInfo, string> response;
            try
            {
                Tuple<ResponseInfo, byte[]> data = await UploadRawAsync(url, body, method).ConfigureAwait(false);
                response = new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = new Tuple<ResponseInfo, string>(new ResponseInfo
                    {
                        Headers = _webClient.ResponseHeaders
                    }, reader.ReadToEnd());
                }
            }
            return response;
        }

        public Tuple<ResponseInfo, byte[]> UploadRaw(string url, string body, string method)
        {
            byte[] data = _webClient.UploadData(url, method, _encoding.GetBytes(body));
            ResponseInfo info = new ResponseInfo
            {
                Headers = _webClient.ResponseHeaders
            };
            return new Tuple<ResponseInfo, byte[]>(info, data);
        }

        public async Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Proxy = null;
                webClient.Encoding = _encoding;
                webClient.Headers = _webClient.Headers;
                byte[] data = await _webClient.UploadDataTaskAsync(url, method, _encoding.GetBytes(body)).ConfigureAwait(false);
                ResponseInfo info = new ResponseInfo
                {
                    Headers = _webClient.ResponseHeaders
                };
                return new Tuple<ResponseInfo, byte[]>(info, data);
            }
        }

        public Tuple<ResponseInfo, T> UploadJson<T>(string url, string body, string method)
        {
            Tuple<ResponseInfo, string> response = Upload(url, body, method);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public async Task<Tuple<ResponseInfo, T>> UploadJsonAsync<T>(string url, string body, string method)
        {
            Tuple<ResponseInfo, string> response = await UploadAsync(url, body, method).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public void SetHeader(string header, string value)
        {
            _webClient.Headers[header] = value;
        }

        public void RemoveHeader(string header)
        {
            if (_webClient.Headers[header] != null)
                _webClient.Headers.Remove(header);
        }

        public List<KeyValuePair<string, string>> GetHeaders()
        {
            return _webClient.Headers.AllKeys.Select(header => new KeyValuePair<string, string>(header, _webClient.Headers[header])).ToList();
        }
    }
}