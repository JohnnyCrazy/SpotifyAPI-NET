using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class FollowedArtists : BasicModel
    {
        [JsonProperty("artists")]
        CursorPaging<FullArtist> Artists { get; set; }  
    }
}