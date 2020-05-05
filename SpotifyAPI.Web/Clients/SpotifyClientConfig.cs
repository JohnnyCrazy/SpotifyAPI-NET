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
    public IHTTPLogger HTTPLogger { get; }
    public IPaginator Paginator { get; set; }

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
    /// <param name="httpLogger"></param>
    /// <param name="paginator"></param>
    public SpotifyClientConfig(
      Uri baseAddress,
      IAuthenticator authenticator,
      IJSONSerializer jsonSerializer,
      IHTTPClient httpClient,
      IRetryHandler retryHandler,
      IHTTPLogger httpLogger,
      IPaginator paginator
    )
    {
      BaseAddress = baseAddress;
      Authenticator = authenticator;
      JSONSerializer = jsonSerializer;
      HTTPClient = httpClient;
      RetryHandler = retryHandler;
      HTTPLogger = httpLogger;
      Paginator = paginator;
    }

    internal IAPIConnector CreateAPIConnector()
    {
      Ensure.ArgumentNotNull(BaseAddress, nameof(BaseAddress));
      Ensure.ArgumentNotNull(Authenticator, nameof(Authenticator));
      Ensure.ArgumentNotNull(JSONSerializer, nameof(JSONSerializer));
      Ensure.ArgumentNotNull(HTTPClient, nameof(HTTPClient));

      return new APIConnector(BaseAddress, Authenticator, JSONSerializer, HTTPClient, RetryHandler, HTTPLogger);
    }

    public SpotifyClientConfig WithToken(string token, string tokenType = "Bearer")
    {
      Ensure.ArgumentNotNull(token, nameof(token));

      return WithAuthenticator(new TokenHeaderAuthenticator(token, tokenType));
    }

    public SpotifyClientConfig WithRetryHandler(IRetryHandler retryHandler)
    {
      return new SpotifyClientConfig(
        BaseAddress, Authenticator, JSONSerializer, HTTPClient, retryHandler, HTTPLogger, Paginator);
    }

    public SpotifyClientConfig WithAuthenticator(IAuthenticator authenticator)
    {
      return new SpotifyClientConfig(
        BaseAddress, authenticator, JSONSerializer, HTTPClient, RetryHandler, HTTPLogger, Paginator);
    }

    public SpotifyClientConfig WithHTTPLogger(IHTTPLogger httpLogger)
    {
      return new SpotifyClientConfig(
        BaseAddress, Authenticator, JSONSerializer, HTTPClient, RetryHandler, httpLogger, Paginator);
    }

    public SpotifyClientConfig WithPaginator(IPaginator paginator)
    {
      return new SpotifyClientConfig(
        BaseAddress, Authenticator, JSONSerializer, HTTPClient, RetryHandler, HTTPLogger, paginator);
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
        null,
        null,
        new SimplePaginator()
      );
    }
  }
}
