using Newtonsoft.Json;
using SpotifyAPI.Web.Enums;
using System;
using System.Net;

namespace SpotifyAPI.Web.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        private ResponseInfo _info;

        public bool HasError() => Error != null;

        internal void AddResponseInfo(ResponseInfo info) => _info = info;

        public string Header(string key) => _info.Headers?.Get(key);

        public WebHeaderCollection Headers() => _info.Headers;

        public HttpStatusCode StatusCode() => _info.StatusCode;
    }
}