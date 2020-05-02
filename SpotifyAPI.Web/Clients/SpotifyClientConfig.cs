using System;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SpotifyClientConfig
  {
    public Uri BaseAddress { get; }
    public IAuthenticator Authenticator { get; }
    public IJSONSerializer JSONSerializer { get; }
    public IHTTPClient HTTPClient { get; }
    public IRetryHandler RetryHandler { get; }

    /// <summary>
    ///   This config spefies the internal parts of the SpotifyClient.
    ///   In apps where multiple different access tokens are used, one should create a default config and then use
    ///   <see cref="WithToken" /> or <see cref="WithAuthenticator" /> to specify the auth details.
    /// </summary>
    /// <param name="baseAddress"></param>
    /// <param name="authenticator"></param>
    /// <param name="jsonSerializer"></param>
    /// <param name="httpClient"></param>
    /// <param name="retryHandler"></param>
    public SpotifyClientConfig(
      Uri baseAddress,
      IAuthenticator authenticator,
      IJSONSerializer jsonSerializer,
      IHTTPClient httpClient,
      IRetryHandler retryHandler
    )
    {
      BaseAddress = baseAddress;
      Authenticator = authenticator;
      JSONSerializer = jsonSerializer;
      HTTPClient = httpClient;
      RetryHandler = retryHandler;
    }

    internal IAPIConnector CreateAPIConnector()
    {
      Ensure.PropertyNotNull(BaseAddress, nameof(BaseAddress));
      Ensure.PropertyNotNull(Authenticator, nameof(Authenticator),
        ". Use WithToken or WithAuthenticator to specify a authentication");
      Ensure.PropertyNotNull(JSONSerializer, nameof(JSONSerializer));
      Ensure.PropertyNotNull(HTTPClient, nameof(HTTPClient));

      return new APIConnector(BaseAddress, Authenticator, JSONSerializer, HTTPClient, RetryHandler);
    }

    public SpotifyClientConfig WithToken(string token, string tokenType = "Bearer")
    {
      Ensure.ArgumentNotNull(token, nameof(token));

      return WithAuthenticator(new TokenHeaderAuthenticator(token, tokenType));
    }

    public SpotifyClientConfig WithRetryHandler(IRetryHandler retryHandler)
    {
      return new SpotifyClientConfig(BaseAddress, Authenticator, JSONSerializer, HTTPClient, retryHandler);
    }

    public SpotifyClientConfig WithAuthenticator(IAuthenticator authenticator)
    {
      return new SpotifyClientConfig(BaseAddress, authenticator, JSONSerializer, HTTPClient, RetryHandler);
    }

    public static SpotifyClientConfig CreateDefault(string token, string tokenType = "Bearer")
    {
      Ensure.ArgumentNotNull(token, nameof(token));

      return CreateDefault(new TokenHeaderAuthenticator(token, tokenType));
    }

    /// <summary>
    ///   Creates a default configuration, which is not useable without calling <see cref="WithToken" /> or
    /// <see cref="WithAuthenticator" />
    /// </summary>
    public static SpotifyClientConfig CreateDefault()
    {
      return CreateDefault(null);
    }

    public static SpotifyClientConfig CreateDefault(IAuthenticator authenticator)
    {
      return new SpotifyClientConfig(
        SpotifyUrls.API_V1,
        authenticator,
        new NewtonsoftJSONSerializer(),
        new NetHttpClient(),
        null
      );
    }
  }
}
