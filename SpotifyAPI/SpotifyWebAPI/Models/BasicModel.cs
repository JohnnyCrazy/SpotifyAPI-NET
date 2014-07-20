using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        public Boolean HasError()
        {
            return Error != null;
        }
    }
}
