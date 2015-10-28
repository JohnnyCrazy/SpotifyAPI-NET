using Newtonsoft.Json;
using System;

namespace SpotifyAPI.Local.Models
{
    public class OpenGraphState
    {
        [JsonProperty("private_session")]
        public Boolean PrivateSession { get; set; }

        [JsonProperty("posting_disabled")]
        public Boolean PostingDisabled { get; set; }
    }
}