using Newtonsoft.Json;
using System;
using System.Net;

namespace SpotifyAPI.Web.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        private WebHeaderCollection _headers;

        public bool HasError() => Error != null;

        internal void AddResponseInfo(ResponseInfo info) => _headers = info.Headers;

        public string Header(string key) => _headers?.Get(key);

        public WebHeaderCollection Headers() => _headers;
    }
}