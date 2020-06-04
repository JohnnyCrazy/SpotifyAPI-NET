using System;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  [TestFixture]
  public class SpotifyClientConfigTest
  {
    [Test]
    public void CreateDefault_CorrectDefaults()
    {
      var defaultConfig = SpotifyClientConfig.CreateDefault();

      Assert.IsInstanceOf(typeof(SimplePaginator), defaultConfig.DefaultPaginator);
      Assert.IsInstanceOf(typeof(NetHttpClient), defaultConfig.HTTPClient);
      Assert.IsInstanceOf(typeof(NewtonsoftJSONSerializer), defaultConfig.JSONSerializer);
      Assert.AreEqual(SpotifyUrls.APIV1, defaultConfig.BaseAddress);
      Assert.AreEqual(null, defaultConfig.Authenticator);
      Assert.AreEqual(null, defaultConfig.HTTPLogger);
      Assert.AreEqual(null, defaultConfig.RetryHandler);
    }

    [Test]
    public void CreateDefault_CorrectDefaultsWithToken()
    {
      var token = "my-token";
      var tokenType = "Bearer";

      var defaultConfig = SpotifyClientConfig.CreateDefault(token, tokenType);

      Assert.IsInstanceOf(typeof(SimplePaginator), defaultConfig.DefaultPaginator);
      Assert.IsInstanceOf(typeof(NetHttpClient), defaultConfig.HTTPClient);
      Assert.IsInstanceOf(typeof(NewtonsoftJSONSerializer), defaultConfig.JSONSerializer);
      Assert.AreEqual(SpotifyUrls.APIV1, defaultConfig.BaseAddress);
      Assert.AreEqual(null, defaultConfig.HTTPLogger);
      Assert.AreEqual(null, defaultConfig.RetryHandler);

      Assert.IsInstanceOf(typeof(TokenAuthenticator), defaultConfig.Authenticator);

      var tokenHeaderAuth = defaultConfig.Authenticator as TokenAuthenticator;
      Assert.AreEqual(token, tokenHeaderAuth.Token);
      Assert.AreEqual(tokenType, tokenHeaderAuth.TokenType);
    }

    [Test]
    public void WithToken_CreatesNewInstance()
    {
      var token = "my-token";
      var defaultConfig = SpotifyClientConfig.CreateDefault();
      var tokenConfig = defaultConfig.WithToken(token);

      Assert.AreEqual(token, (tokenConfig.Authenticator as TokenAuthenticator).Token);
      Assert.AreNotEqual(defaultConfig, tokenConfig);
      Assert.AreEqual(null, defaultConfig.Authenticator);
    }
  }
}
