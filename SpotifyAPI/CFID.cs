using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPIv1
{
    class CFID
    {
        public Error error { get; set; }
        public String token { get; set; }
        public String version { get; set; }
        public String client_version { get; set; }
        public Boolean running { get; set; }
    }
    class Error
    {
        public String type { get; set; }
        public String message { get; set; }
    }
}
