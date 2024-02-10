using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class BrowseClientTest
  {
    [Test]
    public async Task GetRecommendationGenres_UsesCorrectURL()
    {
      var api = new Mock<IAPIConnector>();
      var client = new BrowseClient(api.Object);

      await client.GetRecommendationGenres();

      api.Verify(a => a.Get<RecommendationGenresResponse>(
        It.Is<Uri>((uri) => uri.ToString().Contains("recommendations/available-genre-seeds")),
        It.IsAny<CancellationToken>()
      ));
    }
  }
}
