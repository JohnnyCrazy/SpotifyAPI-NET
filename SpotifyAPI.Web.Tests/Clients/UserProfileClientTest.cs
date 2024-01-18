using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;
using SpotifyAPI.Web.Models.Request;

namespace SpotifyAPI.Web
{
  [TestFixture]
  public class UserProfileClientTest
  {
    [Test]
    public async Task Current()
    {
      var api = new Mock<IAPIConnector>();
      var client = new UserProfileClient(api.Object);

      await client.Current();

      api.Verify(a => a.Get<PrivateUser>(SpotifyUrls.Me(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task Get()
    {
      var userId = "johnnycrazy";
      var api = new Mock<IAPIConnector>();
      var client = new UserProfileClient(api.Object);

      await client.Get(userId);

      api.Verify(a => a.Get<PublicUser>(SpotifyUrls.User(userId), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Test]
    public async Task GetTopTracks()
    {

      var request = new UsersTopItemsRequest(TimeRange.LongTerm);
      var api = new Mock<IAPIConnector>();
      var client = new UserProfileClient(api.Object);

      var res =  await client.GetTopTracks(request);

      api.Verify(a => a.Get<UsersTopTracksResponse>(SpotifyUrls.TopTracks(), request.BuildQueryParams(), It.IsAny<CancellationToken>()), Times.Once);
    }    
    [Test]
    public async Task GetTopArtists()
    {

      var request = new UsersTopItemsRequest(TimeRange.LongTerm);
      var api = new Mock<IAPIConnector>();
      var client = new UserProfileClient(api.Object);

      await client.GetTopArtists(request);

      api.Verify(a => a.Get<UsersTopArtistsResponse>(SpotifyUrls.TopArtists(),request.BuildQueryParams(), It.IsAny<CancellationToken>()), Times.Once);
    }
  }
}
