using System;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public class Snapshot : BasicModel
    {
        [JsonProperty("snapshot_id")]
        public String SnapshotId { get; set; }
    }
}