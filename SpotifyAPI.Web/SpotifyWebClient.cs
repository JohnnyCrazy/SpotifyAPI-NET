using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    public class SpotifyWebClient : IClient
    {
        public JsonSerializerSettings JsonSettings { get; set; }

        private static readonly Encoding Encoding = Encoding.UTF8;

        private HttpClient _httpClient;

        public SpotifyWebClient()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<Tuple<ResponseInfo, string>> Download(string url, params KeyValuePair<string, string>[] headers)
        {
            Tuple<ResponseInfo, byte[]> raw = await DownloadRaw(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? Encoding.GetString(raw.Item2) : "{}");
        }


        public async Task<Tuple<ResponseInfo, byte[]>> DownloadRaw(string url, params KeyValuePair<string, string>[] headers)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            foreach (KeyValuePair<string, string> header in headers)
                request.Headers.Add(header.Key, header.Value);

            HttpResponseMessage result = await _httpClient.SendAsync(request).ConfigureAwait(false);
            ResponseInfo info = new ResponseInfo
            {
                Headers = result.Headers
            };
            return new Tuple<ResponseInfo, byte[]>(info, await result.Content.ReadAsByteArrayAsync());
        }

        public async Task<Tuple<ResponseInfo, T>> DownloadJson<T>(string url, params KeyValuePair<string, string>[] headers)
        {
            Tuple<ResponseInfo, string> response = await Download(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public async Task<Tuple<ResponseInfo, string>> Upload(string url, string body, string method, params KeyValuePair<string, string>[] headers)
        {
            Tuple<ResponseInfo, byte[]> data = await UploadRaw(url, body, method).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? Encoding.GetString(data.Item2) : "{}");
        }

        public async Task<Tuple<ResponseInfo, byte[]>> UploadRaw(string url, string body, string method, params KeyValuePair<string, string>[] headers)
        {
            var httpRequest = new HttpRequestMessage(new HttpMethod(method), url)
            {
                Content = new StringContent(url, Encoding)
            };
            foreach (KeyValuePair<string, string> header in headers)
            {
                httpRequest.Headers.Add(header.Key, header.Value);
            }

            HttpResponseMessage result = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            ResponseInfo info = new ResponseInfo
            {
                Headers = result.Headers
            };
            return new Tuple<ResponseInfo, byte[]>(info, await result.Content.ReadAsByteArrayAsync());
        }

        public async Task<Tuple<ResponseInfo, T>> UploadJson<T>(string url, string body, string method, params KeyValuePair<string, string>[] headers)
        {
            Tuple<ResponseInfo, string> response = await Upload(url, body, method).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }
    }
}