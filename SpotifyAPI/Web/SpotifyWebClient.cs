using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public string Download(string url)
        {
            string response;
            try
            {
                response = _encoding.GetString(DownloadRaw(url));
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        public async Task<string> DownloadAsync(string url)
        {
            string response;
            try
            {
                response = _encoding.GetString(await DownloadRawAsync(url));
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        public byte[] DownloadRaw(string url)
        {
            return _webClient.DownloadData(url);
        }

        public async Task<byte[]> DownloadRawAsync(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Proxy = null;
                webClient.Encoding = _encoding;
                webClient.Headers = _webClient.Headers;
                return await _webClient.DownloadDataTaskAsync(url);
            }
        }

        public T DownloadJson<T>(string url)
        {
            string response = Download(url);
            return JsonConvert.DeserializeObject<T>(response, JsonSettings);
        }

        public async Task<T> DownloadJsonAsync<T>(string url)
        {
            string response = await DownloadAsync(url);
            return JsonConvert.DeserializeObject<T>(response, JsonSettings);
        }

        public string Upload(string url, string body, string method)
        {
            string response;
            try
            {
                byte[] data = UploadRaw(url, body, method);
                response = _encoding.GetString(data);
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        public async Task<string> UploadAsync(string url, string body, string method)
        {
            string response;
            try
            {
                byte[] data = await UploadRawAsync(url, body, method);
                response = _encoding.GetString(data);
            }
            catch (WebException e)
            {
                using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        public byte[] UploadRaw(string url, string body, string method)
        {
            return _webClient.UploadData(url, method, _encoding.GetBytes(body));
        }

        public async Task<byte[]> UploadRawAsync(string url, string body, string method)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Proxy = null;
                webClient.Encoding = _encoding;
                webClient.Headers = _webClient.Headers;
                return await _webClient.UploadDataTaskAsync(url, method, _encoding.GetBytes(body));
            }
        }

        public T UploadJson<T>(string url, string body, string method)
        {
            string response = Upload(url, body, method);
            return JsonConvert.DeserializeObject<T>(response, JsonSettings);
        }

        public async Task<T> UploadJsonAsync<T>(string url, string body, string method)
        {
            string response = await UploadAsync(url, body, method);
            return JsonConvert.DeserializeObject<T>(response, JsonSettings);
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