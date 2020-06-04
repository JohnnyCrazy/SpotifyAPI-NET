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
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });

      var retryCalled = 0;
      setup.Retry = (IRequest request) =>
      {
        retryCalled++;
        return Task.FromResult(setup.Response.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 2
      };
      var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);

      Assert.AreEqual(2, retryCalled);
      Assert.AreEqual(setup.Response.Object, response);
      setup.Sleep.Verify(s => s(TimeSpan.FromSeconds(50)), Times.Exactly(2));
    }

    [Test]
    public async Task HandleRetry_TooManyRetriesWithSuccess()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });

      var successResponse = new Mock<IResponse>();
      successResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      setup.Retry = (request) =>
      {
        retryCalled++;
        return Task.FromResult(successResponse.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10
      };
      var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);

      Assert.AreEqual(1, retryCalled);
      Assert.AreEqual(successResponse.Object, response);
      setup.Sleep.Verify(s => s(TimeSpan.FromSeconds(50)), Times.Once);
    }

    [Test]
    public async Task HandleRetry_TooManyRetriesWithSuccessNoConsume()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });
      var successResponse = new Mock<IResponse>();
      successResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      setup.Retry = (IRequest request) =>
      {
        retryCalled++;
        return Task.FromResult(successResponse.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = false,
        RetryTimes = 0
      };
      var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);

      Assert.AreEqual(1, retryCalled);
      Assert.AreEqual(successResponse.Object, response);
      setup.Sleep.Verify(s => s(TimeSpan.FromSeconds(50)), Times.Once);
    }

    [Test]
    public async Task HandleRetry_ServerErrors()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.BadGateway);

      var retryCalled = 0;
      setup.Retry = (request) =>
      {
        retryCalled++;
        return Task.FromResult(setup.Response.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10,
        RetryAfter = TimeSpan.FromMilliseconds(50)
      };
      var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);

      Assert.AreEqual(10, retryCalled);
      Assert.AreEqual(setup.Response.Object, response);
      setup.Sleep.Verify(s => s(TimeSpan.FromMilliseconds(50)), Times.Exactly(10));
    }

    [Test]
    public async Task HandleRetry_DirectSuccess()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      setup.Retry = (request) =>
      {
        retryCalled++;
        return Task.FromResult(setup.Response.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 10,
        RetryAfter = TimeSpan.FromMilliseconds(50)
      };
      var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);

      Assert.AreEqual(0, retryCalled);
      Assert.AreEqual(setup.Response.Object, response);
      setup.Sleep.Verify(s => s(TimeSpan.FromMilliseconds(50)), Times.Exactly(0));
    }

    private class Setup
    {
      public Mock<Func<TimeSpan, Task>> Sleep { get; set; } = new Mock<Func<TimeSpan, Task>>();
      public Mock<IResponse> Response { get; set; } = new Mock<IResponse>();
      public Mock<IRequest> Request { get; set; } = new Mock<IRequest>();
      public IRetryHandler.RetryFunc Retry { get; set; }
    }
  }
}
