using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class Test
  {
    [Test]
    public async Task Testing()
    {
      var token = "";

      var spotify = new SpotifyClient(token);

      var categories = await spotify.Browse.GetCategories();
      var playlists = await spotify.Browse.GetCategoryPlaylists(categories.Categories.Items[0].Id);
    }
  }
}
