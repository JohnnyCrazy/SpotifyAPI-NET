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

      Assert.That(defaultConfig.DefaultPaginator, Is.InstanceOf(typeof(SimplePaginator)));
      Assert.That(defaultConfig.HTTPClient, Is.InstanceOf(typeof(NetHttpClient)));
      Assert.That(defaultConfig.JSONSerializer, Is.InstanceOf(typeof(NewtonsoftJSONSerializer)));
      Assert.That(SpotifyUrls.APIV1, Is.EqualTo(defaultConfig.BaseAddress));
      Assert.That(null, Is.EqualTo(defaultConfig.Authenticator));
      Assert.That(null, Is.EqualTo(defaultConfig.HTTPLogger));
      Assert.That(null, Is.EqualTo(defaultConfig.RetryHandler));
    }

    [Test]
    public void CreateDefault_CorrectDefaultsWithToken()
    {
      var token = "my-token";
      var tokenType = "Bearer";

      var defaultConfig = SpotifyClientConfig.CreateDefault(token, tokenType);

      Assert.That(defaultConfig.DefaultPaginator, Is.InstanceOf(typeof(SimplePaginator)));
      Assert.That(defaultConfig.HTTPClient, Is.InstanceOf(typeof(NetHttpClient)));
      Assert.That(defaultConfig.JSONSerializer, Is.InstanceOf(typeof(NewtonsoftJSONSerializer)));
      Assert.That(SpotifyUrls.APIV1, Is.EqualTo(defaultConfig.BaseAddress));
      Assert.That(null, Is.EqualTo(defaultConfig.HTTPLogger));
      Assert.That(null, Is.EqualTo(defaultConfig.RetryHandler));

      Assert.That(defaultConfig.Authenticator, Is.InstanceOf(typeof(TokenAuthenticator)));

      var tokenHeaderAuth = defaultConfig.Authenticator as TokenAuthenticator;
      Assert.That(token, Is.EqualTo(tokenHeaderAuth.Token));
      Assert.That(tokenType, Is.EqualTo(tokenHeaderAuth.TokenType));
    }

    [Test]
    public void WithToken_CreatesNewInstance()
    {
      var token = "my-token";
      var defaultConfig = SpotifyClientConfig.CreateDefault();
      var tokenConfig = defaultConfig.WithToken(token);

      Assert.That(token, Is.EqualTo((tokenConfig.Authenticator as TokenAuthenticator).Token));
      Assert.That(defaultConfig, Is.Not.EqualTo(tokenConfig));
      Assert.That(null, Is.EqualTo(defaultConfig.Authenticator));
    }
  }
}
