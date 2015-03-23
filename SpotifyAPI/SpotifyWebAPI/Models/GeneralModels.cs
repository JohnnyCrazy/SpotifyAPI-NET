using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
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
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
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
    public class CreatePlaylistArgs
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("public")]
        public Boolean Public { get; set; }
    }
    public class DeleteTrackArg
    {
        [JsonProperty("uri")]
        public String Uri { get; set; }
        [JsonProperty("positions")]
        public List<int> Positions { get; set; }

        public DeleteTrackArg(String uri, params int[] positions)
        {
            this.Positions = positions.ToList();
            this.Uri = uri;
        }
        public bool ShouldSerializePositions()
        {
            // don't serialize the Manager property if an employee is their own manager
            return (Positions.Count > 0);
        }
    }
    public class SeveralTracks
    {
        [JsonProperty("tracks")]
        public List<FullTrack> Tracks { get; set; }
    }
    public class SeveralArtists
    {
        [JsonProperty("artists")]
        public List<FullArtist> Artists { get; set; }
    }
    public class SeveralAlbums
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
}
