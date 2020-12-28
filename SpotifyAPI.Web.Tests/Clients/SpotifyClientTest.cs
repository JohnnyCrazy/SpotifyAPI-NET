using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class SpotifyClientTest
  {
    [Test]
    public async Task NextPageForIPaginatable()
    {
      var api = new Mock<IAPIConnector>();
      var config = SpotifyClientConfig.CreateDefault("FakeToken").WithAPIConnector(api.Object);
      var spotify = new SpotifyClient(config);

      var response = new SearchResponse
      {
        Albums = new Paging<SimpleAlbum, SearchResponse>
        {
          Next = "https://next-url",
        }
      };

      await spotify.NextPage(response.Albums);
      api.Verify(a => a.Get<SearchResponse>(new System.Uri("https://next-url")), Times.Once);
    }

    [Test]
    public async Task NextPageForCursorPaging()
    {
      var api = new Mock<IAPIConnector>();
      var config = SpotifyClientConfig.CreateDefault("FakeToken").WithAPIConnector(api.Object);
      var spotify = new SpotifyClient(config);

      var response = new CursorPaging<PlayHistoryItem>
      {
        Next = "https://next-url"
      };

      await spotify.NextPage(response);
      api.Verify(a => a.Get<CursorPaging<PlayHistoryItem>>(new System.Uri("https://next-url")), Times.Once);
    }

    [Test]
    public async Task NextPageForPaging()
    {
      var api = new Mock<IAPIConnector>();
      var config = SpotifyClientConfig.CreateDefault("FakeToken").WithAPIConnector(api.Object);
      var spotify = new SpotifyClient(config);

      var response = new Paging<PlayHistoryItem>
      {
        Next = "https://next-url"
      };

      await spotify.NextPage(response);
      api.Verify(a => a.Get<Paging<PlayHistoryItem>>(new System.Uri("https://next-url")), Times.Once);
    }

    [Test]
    public async Task PreviousPageForPaging()
    {
      var api = new Mock<IAPIConnector>();
      var config = SpotifyClientConfig.CreateDefault("FakeToken").WithAPIConnector(api.Object);
      var spotify = new SpotifyClient(config);

      var response = new Paging<PlayHistoryItem>
      {
        Previous = "https://previous-url"
      };

      await spotify.PreviousPage(response);
      api.Verify(a => a.Get<Paging<PlayHistoryItem>>(new System.Uri("https://previous-url")), Times.Once);
    }

    [Test]
    public async Task PreviousPageForCustomPaging()
    {
      var api = new Mock<IAPIConnector>();
      var config = SpotifyClientConfig.CreateDefault("FakeToken").WithAPIConnector(api.Object);
      var spotify = new SpotifyClient(config);

      var response = new Paging<PlayHistoryItem, SearchResponse>
      {
        Previous = "https://previous-url"
      };

      await spotify.PreviousPage(response);
      api.Verify(a => a.Get<SearchResponse>(new System.Uri("https://previous-url")), Times.Once);
    }
  }
}
