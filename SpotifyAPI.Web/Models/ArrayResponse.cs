using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class ListResponse<T> : BasicModel
    {
        public List<T> List { get; set; }
    }
}