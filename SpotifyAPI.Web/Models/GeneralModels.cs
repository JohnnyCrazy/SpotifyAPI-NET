using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyAPI.Web.Models
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class ErrorResponse : BasicModel
    {
    }

    public class Error
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class PlaylistTrackCollection
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class PlaylistTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("added_by")]
        public PublicProfile AddedBy { get; set; }

        [JsonProperty("track")]
        public FullTrack Track { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }
    }

    public class DeleteTrackUri
    {
        /// <summary>
        ///     Delete-Track Wrapper
        /// </summary>
        /// <param name="uri">An Spotify-URI</param>
        /// <param name="positions">Optional positions</param>
        public DeleteTrackUri(string uri, params int[] positions)
        {
            Positions = positions.ToList();
            Uri = uri;
        }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("positions")]
        public List<int> Positions { get; set; }

        public bool ShouldSerializePositions()
        {
            return Positions.Count > 0;
        }
    }

    public class Copyright
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class LinkedFrom
    {
        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class SavedTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("track")]
        public FullTrack Track { get; set; }
    }

    public class SavedAlbum
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("album")]
        public FullAlbum Album { get; set; }
    }

    public class Cursor
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }

    public class Context
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}