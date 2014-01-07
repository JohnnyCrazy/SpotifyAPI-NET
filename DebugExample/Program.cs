using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPIv1;
using System.Threading;

namespace DebugExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SpotifyAPI test = new SpotifyAPI();
            test.Connect();
            Thread.Sleep(-1);
        }
    }
}
