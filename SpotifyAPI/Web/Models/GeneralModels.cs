using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyAPI.Web.Models
{
    public class Image
    {
        [JsonProperty("url")]
        public String Url { get; set; }

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
        public String Message { get; set; }
    }

    public class PlaylistTrackCollection
    {
        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")]
        public String Href { get; set; }

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
        public Boolean IsLocal { get; set; }
    }

    public class DeleteTrackUri
    {
        /// <summary>
        ///     Delete-Track Wrapper
        /// </summary>
        /// <param name="uri">An Spotify-URI</param>
        /// <param name="positions">Optional positions</param>
        public DeleteTrackUri(String uri, params int[] positions)
        {
            Positions = positions.ToList();
            Uri = uri;
        }

        [JsonProperty("uri")]
        public String Uri { get; set; }

        [JsonProperty("positions")]
        public List<int> Positions { get; set; }

        public bool ShouldSerializePositions()
        {
            return (Positions.Count > 0);
        }
    }

    public class SeveralTracks : BasicModel
    {
        [JsonProperty("tracks")]
        public List<FullTrack> Tracks { get; set; }
    }

    public class SeveralArtists : BasicModel
    {
        [JsonProperty("artists")]
        public List<FullArtist> Artists { get; set; }
    }

    public class SeveralAlbums : BasicModel
    {
        [JsonProperty("albums")]
        public List<FullAlbum> Albums { get; set; }
    }

    public class Copyright
    {
        [JsonProperty("text")]
        public String Text { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }
    }

    public class LinkedFrom
    {
        [JsonProperty("external_urls")]
        public Dictionary<String, String> ExternalUrls { get; set; }

        [JsonProperty("href")]
        public String Href { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }
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
        public SavedAlbum Album { get; set; }
    }

    public class Cursor
    {
        [JsonProperty("after")]
        public String After { get; set; }
    }
}