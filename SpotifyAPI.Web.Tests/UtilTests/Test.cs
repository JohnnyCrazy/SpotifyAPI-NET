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
      var config = SpotifyClientConfig.CreateDefault("BQAODnY4uqYj_KCddlDm10KLPDZSpZhVUtMDjdh1zfG-xd5pAV3htRjnaGfO7ob92HHzNP05a-4mDnts337gdnZlRtjrDPnuWNFx75diY540H0cD1bS9UzI5cfO27N2O6lmzKb_jAYTaRoqPKHoG93KGiXxwg4vblGKSBY1vIloP");
      var spotify = new SpotifyClient(config);

      var playlists = await spotify.Browse.GetCategoryPlaylists("toplists", new CategoriesPlaylistsRequest() { Offset = 1 });
      Console.WriteLine(playlists.Playlists.Items[0].Name);
    }
  }
}
