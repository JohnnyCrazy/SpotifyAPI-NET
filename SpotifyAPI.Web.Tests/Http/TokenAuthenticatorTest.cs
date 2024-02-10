
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class TokenAuthenticatorTest
  {
    [Test]
    public void Apply_AddsCorrectHeader()
    {
      var authenticator = new TokenAuthenticator("MyToken", "Bearer");
      var request = new Mock<IRequest>();
      var apiConnector = new Mock<IAPIConnector>();

      request.SetupGet(r => r.Headers).Returns(new Dictionary<string, string>());

      authenticator.Apply(request.Object, apiConnector.Object);
      Assert.That(request.Object.Headers["Authorization"], Is.EqualTo("Bearer MyToken"));
    }
  }
}
