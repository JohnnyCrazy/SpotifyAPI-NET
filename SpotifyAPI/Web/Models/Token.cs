using Newtonsoft.Json;
using System;

namespace SpotifyAPI.Web.Models
{
    public class Token
    {
        public Token()
        {
            CreateDate = DateTime.Now;
        }

        [JsonProperty("access_token")]
        public String AccessToken { get; set; }

        [JsonProperty("token_type")]
        public String TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public String RefreshToken { get; set; }

        [JsonProperty("error")]
        public String Error { get; set; }

        [JsonProperty("error_description")]
        public String ErrorDescription { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Checks if the token has expired
        /// </summary>
        /// <returns></returns>
        public Boolean IsExpired()
        {
            return CreateDate.Add(TimeSpan.FromSeconds(ExpiresIn)) <= DateTime.Now;
        }
    }
}