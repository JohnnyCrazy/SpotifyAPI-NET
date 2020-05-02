using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpotifyAPI.Web
{
  [TestFixture]
  public class Testing
  {

    [Test]
    public async Task TestingYo()
    {
      var config = SpotifyClientConfig.CreateDefault("");
      var spotify = new SpotifyClient(config);
    }
  }
}
