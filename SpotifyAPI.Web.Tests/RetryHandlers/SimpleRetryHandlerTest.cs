using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
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
    public void HandleRetry_WorksWithLowerCaseHeader()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "retry-after", "50" }
      });

      var retryCalled = 0;
      setup.Retry = (IRequest request, CancellationToken ct) =>
      {
        retryCalled++;
        return Task.FromResult(setup.Response.Object);
      };

      var handler = new SimpleRetryHandler(setup.Sleep.Object)
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 1
      };
      Assert.DoesNotThrowAsync(async () =>
      {
        var response = await handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry);
      });

      Assert.That(1, Is.EqualTo(retryCalled));
    }

    [Test]
    public async Task HandleRetry_TooManyRequestsWithNoSuccess()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "50" }
      });

      var retryCalled = 0;
      setup.Retry = (IRequest request, CancellationToken ct) =>
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

      Assert.That(2, Is.EqualTo(retryCalled));
      Assert.That(setup.Response.Object, Is.EqualTo(response));
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
      setup.Retry = (request, ct) =>
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

      Assert.That(1, Is.EqualTo(retryCalled));
      Assert.That(successResponse.Object, Is.EqualTo(response));
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
      setup.Retry = (IRequest request, CancellationToken ct) =>
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

      Assert.That(1, Is.EqualTo(retryCalled));
      Assert.That(successResponse.Object, Is.EqualTo(response));
      setup.Sleep.Verify(s => s(TimeSpan.FromSeconds(50)), Times.Once);
    }

    [Test]
    public async Task HandleRetry_ServerErrors()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.BadGateway);

      var retryCalled = 0;
      setup.Retry = (request, ct) =>
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

      Assert.That(10, Is.EqualTo(retryCalled));
      Assert.That(setup.Response.Object, Is.EqualTo(response));
      setup.Sleep.Verify(s => s(TimeSpan.FromMilliseconds(50)), Times.Exactly(10));
    }

    [Test]
    public async Task HandleRetry_DirectSuccess()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);

      var retryCalled = 0;
      setup.Retry = (request, ct) =>
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

      Assert.That(0, Is.EqualTo(retryCalled));
      Assert.That(setup.Response.Object, Is.EqualTo(response));
      setup.Sleep.Verify(s => s(TimeSpan.FromMilliseconds(50)), Times.Exactly(0));
    }

    [Test]
    public async Task HandleRetry_CancellationTokenHonoredInSleep()
    {
      var setup = new Setup();
      setup.Response.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.TooManyRequests);
      setup.Response.SetupGet(r => r.Headers).Returns(new Dictionary<string, string> {
        { "Retry-After", "5" }
      });

      var retryCalled = 0;
      setup.Retry = (request, ct) =>
      {
        retryCalled++;
        return Task.FromResult(setup.Response.Object);
      };

      var handler = new SimpleRetryHandler()
      {
        TooManyRequestsConsumesARetry = true,
        RetryTimes = 0,
        RetryAfter = TimeSpan.FromSeconds(1)
      };

      var cancellationTokenSource = new CancellationTokenSource();

      var startTime = DateTimeOffset.UtcNow;
      try
      {
        var attemptTask = handler.HandleRetry(setup.Request.Object, setup.Response.Object, setup.Retry, cancellationTokenSource.Token);

        // Wait enough that we're probably in the sleep
        await Task.Delay(TimeSpan.FromMilliseconds(100));

        cancellationTokenSource.Cancel();

        await attemptTask;
      }
      catch (OperationCanceledException)
      {
        //Expected
      }

      Assert.That(DateTimeOffset.UtcNow - startTime, Is.LessThan(TimeSpan.FromSeconds(4)));
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
