using System.Net.Http;
using System;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SpotifyClientConfig
  {
    public Uri BaseAddress { get; private set; }
    public IAuthenticator Authenticator { get; private set; }
    public IJSONSerializer JSONSerializer { get; private set; }
    public IHTTPClient HTTPClient { get; private set; }
    public IHTTPLogger HTTPLogger { get; private set; }
    public IRetryHandler RetryHandler { get; private set; }
    public IPaginator DefaultPaginator { get; private set; }

    /// <summary>
    ///   This config spefies the internal parts of the SpotifyClient.
    /// </summary>
    /// <param name="baseAddress"></param>
    /// <param name="authenticator"></param>
    /// <param name="jsonSerializer"></param>
    /// <param name="httpClient"></param>
    /// <param name="retryHandler"></param>
    /// <param name="httpLogger"></param>
    /// <param name="defaultPaginator"></param>
    public SpotifyClientConfig(
      Uri baseAddress,
      IAuthenticator authenticator,
      IJSONSerializer jsonSerializer,
      IHTTPClient httpClient,
      IRetryHandler retryHandler,
      IHTTPLogger httpLogger,
      IPaginator defaultPaginator
    )
    {
      BaseAddress = baseAddress;
      Authenticator = authenticator;
      JSONSerializer = jsonSerializer;
      HTTPClient = httpClient;
      RetryHandler = retryHandler;
      HTTPLogger = httpLogger;
      DefaultPaginator = defaultPaginator;
    }

    public SpotifyClientConfig WithToken(string token, string tokenType = "Bearer")
    {
      Ensure.ArgumentNotNull(token, nameof(token));

      return new SpotifyClientConfig(
        BaseAddress,
        new TokenHeaderAuthenticator(token, tokenType),
        JSONSerializer,
        HTTPClient,
        RetryHandler,
        HTTPLogger,
        DefaultPaginator
      );
    }

    public SpotifyClientConfig WithRetryHandler(IRetryHandler retryHandler)
    {
      return new SpotifyClientConfig(
        BaseAddress,
        Authenticator,
        JSONSerializer,
        HTTPClient,
        retryHandler,
        HTTPLogger,
        DefaultPaginator
      );
    }

    public SpotifyClientConfig WithAuthenticator(IAuthenticator authenticator)
    {
      Ensure.ArgumentNotNull(authenticator, nameof(authenticator));

      return new SpotifyClientConfig(
        BaseAddress,
        authenticator,
        JSONSerializer,
        HTTPClient,
        RetryHandler,
        HTTPLogger,
        DefaultPaginator
      );
    }

    public SpotifyClientConfig WithHTTPLogger(IHTTPLogger httpLogger)
    {
      return new SpotifyClientConfig(
        BaseAddress,
        Authenticator,
        JSONSerializer,
        HTTPClient,
        RetryHandler,
        httpLogger,
        DefaultPaginator
      );
    }

    public SpotifyClientConfig WithHTTPClient(IHTTPClient httpClient)
    {
      Ensure.ArgumentNotNull(httpClient, nameof(httpClient));

      return new SpotifyClientConfig(
        BaseAddress,
        Authenticator,
        JSONSerializer,
        httpClient,
        RetryHandler,
        HTTPLogger,
        DefaultPaginator
      );
    }

    public SpotifyClientConfig WithJSONSerializer(IJSONSerializer jsonSerializer)
    {
      Ensure.ArgumentNotNull(jsonSerializer, nameof(jsonSerializer));

      return new SpotifyClientConfig(
        BaseAddress,
        Authenticator,
        jsonSerializer,
        HTTPClient,
        RetryHandler,
        HTTPLogger,
        DefaultPaginator
      );
    }


    public SpotifyClientConfig WithDefaultPaginator(IPaginator defaultPaginator)
    {
      Ensure.ArgumentNotNull(defaultPaginator, nameof(defaultPaginator));

      return new SpotifyClientConfig(
        BaseAddress,
        Authenticator,
        JSONSerializer,
        HTTPClient,
        RetryHandler,
        HTTPLogger,
        defaultPaginator
      );
    }

    public static SpotifyClientConfig CreateDefault(string token, string tokenType = "Bearer")
    {
      return CreateDefault().WithAuthenticator(new TokenHeaderAuthenticator(token, tokenType));
    }

    public static SpotifyClientConfig CreateDefault()
    {
      return new SpotifyClientConfig(
        SpotifyUrls.APIV1,
        null,
        new NewtonsoftJSONSerializer(),
        new NetHttpClient(),
        null,
        null,
        new SimplePaginator()
      );
    }
  }
}
