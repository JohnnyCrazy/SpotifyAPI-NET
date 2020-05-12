using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [TestFixture]
  public class SimpleRetryHandlerTest
  {
    [Test]
    public async Task HandleRetry_TooManyRequestsWithNoSuccess()
    {
      var sleep = new Mock<Func<int, Task>>();

      var request = new Mock<IRequest>();
      var initialResponse = new Mock<IResponse>();
      initialResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      initialResponse.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });

      var retryCalled = 0;
      Task<IResponse> retry(IRequest request)
      {
        retryCalled++;
        return Task.FromResult(initialResponse.Object);
      }

      var handler = new SimpleRetryHandler(sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 2
      };
      var response = await handler.HandleRetry(request.Object, initialResponse.Object, retry);

      Assert.AreEqual(2, retryCalled);
      Assert.AreEqual(initialResponse.Object, response);
      sleep.Verify(s => s(50000), Times.Exactly(2));

    }

    [Test]
    public async Task HandleRetry_TooManyRetriesWithSuccess()
    {
      var sleep = new Mock<Func<int, Task>>();

      var request = new Mock<IRequest>();
      var initialResponse = new Mock<IResponse>();
      initialResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      initialResponse.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });
      var successResponse = new Mock<IResponse>();
      successResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      Task<IResponse> retry(IRequest request)
      {
        retryCalled++;
        return Task.FromResult(successResponse.Object);
      }

      var handler = new SimpleRetryHandler(sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10
      };
      var response = await handler.HandleRetry(request.Object, initialResponse.Object, retry);

      Assert.AreEqual(1, retryCalled);
      Assert.AreEqual(successResponse.Object, response);
      sleep.Verify(s => s(50000), Times.Once);
    }

    [Test]
    public async Task HandleRetry_TooManyRetriesWithSuccessNoConsume()
    {
      var sleep = new Mock<Func<int, Task>>();

      var request = new Mock<IRequest>();
      var initialResponse = new Mock<IResponse>();
      initialResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      initialResponse.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });
      var successResponse = new Mock<IResponse>();
      successResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      Task<IResponse> retry(IRequest request)
      {
        retryCalled++;
        return Task.FromResult(successResponse.Object);
      }

      var handler = new SimpleRetryHandler(sleep.Object)
      {
        TooManyRequestsConsumesARetry = false,
        RetryTimes = 0
      };
      var response = await handler.HandleRetry(request.Object, initialResponse.Object, retry);

      Assert.AreEqual(1, retryCalled);
      Assert.AreEqual(successResponse.Object, response);
      sleep.Verify(s => s(50000), Times.Once);
    }

    [Test]
    public async Task HandleRetry_ServerErrors()
    {
      var sleep = new Mock<Func<int, Task>>();

      var request = new Mock<IRequest>();
      var initialResponse = new Mock<IResponse>();
      initialResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.BadGateway);

      var retryCalled = 0;
      Task<IResponse> retry(IRequest request)
      {
        retryCalled++;
        return Task.FromResult(initialResponse.Object);
      }

      var handler = new SimpleRetryHandler(sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10,
        RetryAfter = 50
      };
      var response = await handler.HandleRetry(request.Object, initialResponse.Object, retry);

      Assert.AreEqual(10, retryCalled);
      Assert.AreEqual(initialResponse.Object, response);
      sleep.Verify(s => s(50), Times.Exactly(10));
    }

    [Test]
    public async Task HandleRetry_DirectSuccess()
    {
      var sleep = new Mock<Func<int, Task>>();

      var request = new Mock<IRequest>();
      var initialResponse = new Mock<IResponse>();
      initialResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      Task<IResponse> retry(IRequest request)
      {
        retryCalled++;
        return Task.FromResult(initialResponse.Object);
      }

      var handler = new SimpleRetryHandler(sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10,
        RetryAfter = 50
      };
      var response = await handler.HandleRetry(request.Object, initialResponse.Object, retry);

      Assert.AreEqual(0, retryCalled);
      Assert.AreEqual(initialResponse.Object, response);
      sleep.Verify(s => s(50), Times.Exactly(0));
    }
  }
}
