using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    public interface IClient : IDisposable
    {
        JsonSerializerSettings JsonSettings { get; set; }

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, string>> Download(string url, params KeyValuePair<string, string>[] headers);

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, byte[]>> DownloadRaw(string url, params KeyValuePair<string, string>[] headers);

        /// <summary>
        ///     Downloads data async from an URL and converts it to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, T>> DownloadJson<T>(string url, params KeyValuePair<string, string>[] headers);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, string>> Upload(string url, string body, string method, params KeyValuePair<string, string>[] headers);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, byte[]>> UploadRaw(string url, string body, string method, params KeyValuePair<string, string>[] headers);

        /// <summary>
        ///     Uploads data async from an URL and converts the response to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, T>> UploadJson<T>(string url, string body, string method, params KeyValuePair<string, string>[] headers);
    }
}