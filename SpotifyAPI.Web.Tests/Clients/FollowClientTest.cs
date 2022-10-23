using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class FollowClientTest
  {
    [Test]
    public async Task OfCurrentUser_PassesQueryParams()
    {
      var api = new Mock<IAPIConnector>();
      var client = new FollowClient(api.Object);

      var request = new FollowOfCurrentUserRequest(FollowOfCurrentUserRequest.Type.Artist);
      await client.OfCurrentUser(request);

      api.Verify(a => a.Get<FollowedArtistsResponse>(
        SpotifyUrls.CurrentUserFollower(),
        It.Is<Dictionary<string, string>>(val => val.ContainsKey("type")),
        It.IsAny<CancellationToken>()
      ));
    }
  }
}
