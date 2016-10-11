using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        private HttpHeaders _headers;

        public bool HasError() => Error != null;

        internal void AddResponseInfo(ResponseInfo info) => _headers = info.Headers;

        /// <summary>
        ///     Returns the first header matching the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Header(string key) => _headers?.GetValues(key).FirstOrDefault();

        /// <summary>
        ///     Returns all headers
        /// </summary>
        /// <returns></returns>
        public HttpHeaders Headers() => _headers;

        /// <summary>
        ///     Returns all headers matching the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<string> Headers(string key) => _headers?.GetValues(key);
    }
}