using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class TokenHeaderAuthenticatorTest
  {
    [Test]
    public void Apply_AddsCorrectHeader()
    {
      var authenticator = new TokenHeaderAuthenticator("MyToken", "Bearer");
      var request = new Mock<IRequest>();
      request.SetupGet(r => r.Headers).Returns(new Dictionary<string, string>());

      authenticator.Apply(request.Object);
      Assert.AreEqual(request.Object.Headers["Authorization"], "Bearer MyToken");
    }
  }
}
