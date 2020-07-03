using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class APIConnectorTest
  {
    [Test]
    public async Task RetryHandler_IsUsed()
    {
      var apiResponse = new Mock<IAPIResponse<string>>();
      apiResponse.SetupGet(a => a.Body).Returns("Hello World");

      var response = new Mock<IResponse>();
      response.SetupGet(r => r.ContentType).Returns("application/json");
      response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
      response.SetupGet(r => r.Body).Returns("\"Hello World\"");

      var authenticator = new Mock<IAuthenticator>();
      var serializer = new Mock<IJSONSerializer>();
      serializer.Setup(s => s.DeserializeResponse<string>(It.IsAny<IResponse>())).Returns(apiResponse.Object);

      var httpClient = new Mock<IHTTPClient>();
      var retryHandler = new Mock<IRetryHandler>();
      retryHandler.Setup(r =>
        r.HandleRetry(
          It.IsAny<IRequest>(),
          It.IsAny<IResponse>(),
          It.IsAny<IRetryHandler.RetryFunc>()
        )
      ).Returns(Task.FromResult(response.Object));

      var apiConnector = new APIConnector(
        new Uri("https://spotify.com"),
        authenticator.Object,
        serializer.Object,
        httpClient.Object,
        retryHandler.Object,
        null
      );
      await apiConnector.SendAPIRequest<string>(new Uri("/me", UriKind.Relative), HttpMethod.Get).ConfigureAwait(false);

      authenticator.Verify(a => a.Apply(It.IsAny<IRequest>(), It.IsAny<IAPIConnector>()), Times.Once);
      httpClient.Verify(h => h.DoRequest(It.IsAny<IRequest>()), Times.Once);
      serializer.Verify(s => s.DeserializeResponse<string>(response.Object), Times.Once);
    }

    [Test]
    public async Task RetryHandler_CanRetry()
    {
      var apiResponse = new Mock<IAPIResponse<string>>();
      apiResponse.SetupGet(a => a.Body).Returns("Hello World");

      var response = new Mock<IResponse>();
      response.SetupGet(r => r.ContentType).Returns("application/json");
      response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
      response.SetupGet(r => r.Body).Returns("\"Hello World\"");

      var authenticator = new Mock<IAuthenticator>();
      var serializer = new Mock<IJSONSerializer>();
      serializer.Setup(s => s.DeserializeResponse<string>(It.IsAny<IResponse>())).Returns(apiResponse.Object);

      var httpClient = new Mock<IHTTPClient>();
      httpClient.Setup(h => h.DoRequest(It.IsAny<IRequest>())).Returns(Task.FromResult(response.Object));

      var retryHandler = new Mock<IRetryHandler>();
      retryHandler.Setup(r =>
        r.HandleRetry(
          It.IsAny<IRequest>(),
          It.IsAny<IResponse>(),
          It.IsAny<IRetryHandler.RetryFunc>()
        )
      ).Returns((IRequest request, IResponse _, IRetryHandler.RetryFunc retry) => retry(request));

      var apiConnector = new APIConnector(
        new Uri("https://spotify.com"),
        authenticator.Object,
        serializer.Object,
        httpClient.Object,
        retryHandler.Object,
        null
      );
      await apiConnector.SendAPIRequest<string>(new Uri("/me", UriKind.Relative), HttpMethod.Get).ConfigureAwait(false);

      serializer.Verify(s => s.SerializeRequest(It.IsAny<IRequest>()), Times.Once);
      authenticator.Verify(a => a.Apply(It.IsAny<IRequest>(), It.IsAny<IAPIConnector>()), Times.Exactly(2));
      httpClient.Verify(h => h.DoRequest(It.IsAny<IRequest>()), Times.Exactly(2));
      serializer.Verify(s => s.DeserializeResponse<string>(response.Object), Times.Once);
    }
  }
}
