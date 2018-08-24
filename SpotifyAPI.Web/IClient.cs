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
        ///     Downloads data from an URL and returns it
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, string> Download(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, string>> DownloadAsync(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data from an URL and returns it
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data from an URL and converts it to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, T> DownloadJson<T>(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and converts it to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, T>> DownloadJsonAsync<T>(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, string> Upload(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, byte[]> UploadRaw(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and converts the response to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<ResponseInfo, T> UploadJson<T>(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and converts the response to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<ResponseInfo, T>> UploadJsonAsync<T>(string url, string body, string method, Dictionary<string, string> headers = null);
    }
}