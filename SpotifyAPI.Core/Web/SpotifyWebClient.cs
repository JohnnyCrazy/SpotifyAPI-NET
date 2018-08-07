﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    internal class SpotifyWebClient : IClient
    {
        public JsonSerializerSettings JsonSettings { get; set; }

        public ProxyConfig ProxyConfig { get; set; }

        private readonly Encoding _encoding = Encoding.UTF8;

        public Tuple<ResponseInfo, string> Download(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = DownloadRaw(url, headers);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }

        public async Task<Tuple<ResponseInfo, string>> DownloadAsync(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = await DownloadRawAsync(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }

        public Tuple<ResponseInfo, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null)
        {
            HttpClientHandler clientHandler = CreateClientHandler(ProxyConfig);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> headerPair in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
                    }
                }
                using (HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result)
                {
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = response.StatusCode,
                        Headers = ConvertHeaders(response.Headers)
                    }, Task.Run(() => response.Content.ReadAsByteArrayAsync()).Result);
                }
            }
        }

        public async Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null)
        {
            HttpClientHandler clientHandler = CreateClientHandler(ProxyConfig);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> headerPair in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
                    }
                }
                using (HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false))
                {
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = response.StatusCode,
                        Headers = ConvertHeaders(response.Headers)
                    }, await response.Content.ReadAsByteArrayAsync());
                }
            }
        }

        public Tuple<ResponseInfo, T> DownloadJson<T>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = Download(url, headers);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public async Task<Tuple<ResponseInfo, T>> DownloadJsonAsync<T>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await DownloadAsync(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public Tuple<ResponseInfo, string> Upload(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> data = UploadRaw(url, body, method, headers);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
        }

        public async Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> data = await UploadRawAsync(url, body, method, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
        }

        public Tuple<ResponseInfo, byte[]> UploadRaw(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            HttpClientHandler clientHandler = CreateClientHandler(ProxyConfig);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> headerPair in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
                    }
                }

                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url)
                {
                    Content = new StringContent(body, _encoding)
                };
                using (HttpResponseMessage response = Task.Run(() => client.SendAsync(message)).Result)
                {
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = response.StatusCode,
                        Headers = ConvertHeaders(response.Headers)
                    }, Task.Run(() => response.Content.ReadAsByteArrayAsync()).Result);
                }
            }
        }

        public async Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            HttpClientHandler clientHandler = CreateClientHandler(ProxyConfig);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> headerPair in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
                    }
                }

                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url)
                {
                    Content = new StringContent(body, _encoding)
                };
                using (HttpResponseMessage response = await client.SendAsync(message))
                {
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = response.StatusCode,
                        Headers = ConvertHeaders(response.Headers)
                    }, await response.Content.ReadAsByteArrayAsync());
                }
            }
        }

        public Tuple<ResponseInfo, T> UploadJson<T>(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = Upload(url, body, method, headers);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public async Task<Tuple<ResponseInfo, T>> UploadJsonAsync<T>(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await UploadAsync(url, body, method, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private static WebHeaderCollection ConvertHeaders(HttpResponseHeaders headers)
        {
            WebHeaderCollection newHeaders = new WebHeaderCollection();
            foreach (KeyValuePair<string, IEnumerable<string>> headerPair in headers)
            {
                foreach (string headerValue in headerPair.Value)
                {
                    newHeaders.Add(headerPair.Key, headerValue);
                }
            }
            return newHeaders;
        }

        private static HttpClientHandler CreateClientHandler(ProxyConfig proxyConfig = null)
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                PreAuthenticate = false,
                UseDefaultCredentials = true,
                UseProxy = false
            };

            if (!string.IsNullOrWhiteSpace(proxyConfig?.Host))
            {
                WebProxy proxy = proxyConfig.CreateWebProxy();
                clientHandler.UseProxy = true;
                clientHandler.Proxy = proxy;
                clientHandler.UseDefaultCredentials = proxy.UseDefaultCredentials;
                clientHandler.PreAuthenticate = proxy.UseDefaultCredentials;
            }

            return clientHandler;
        }
    }
}