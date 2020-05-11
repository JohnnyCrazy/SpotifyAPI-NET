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
      DefaultPaginator = paginator;
    }

    internal IAPIConnector CreateAPIConnector()
    {
      return new APIConnector(
        BaseAddress,
        Authenticator,
        JSONSerializer,
        HTTPClient,
        RetryHandler,
        HTTPLogger
      );
    }

    public void AddToken(string token, string tokenType = "Bearer")
    {
      Ensure.ArgumentNotNull(token, nameof(token));
      Authenticator = new TokenHeaderAuthenticator(token, tokenType);
    }

    public void AddRetryHandler(IRetryHandler retryHandler)
    {
      RetryHandler = retryHandler;
    }

    public void AddAuthenticator(IAuthenticator authenticator)
    {
      Ensure.ArgumentNotNull(authenticator, nameof(authenticator));

      Authenticator = authenticator;
    }

    public void AddHTTPLogger(IHTTPLogger httpLogger)
    {
      HTTPLogger = httpLogger;
    }

    public void AddHTTPClient(IHTTPClient httpClient)
    {
      Ensure.ArgumentNotNull(httpClient, nameof(httpClient));

      HTTPClient = httpClient;
    }

    public void AddJSONSerializer(IJSONSerializer jsonSerializer)
    {
      Ensure.ArgumentNotNull(jsonSerializer, nameof(jsonSerializer));

      JSONSerializer = jsonSerializer;
    }


    public void AddDefaultPaginator(IPaginator paginator)
    {
      DefaultPaginator = paginator;
    }

    public static SpotifyClientConfig CreateDefault(string token, string tokenType = "Bearer")
    {
      return CreateDefault(options =>
      {
        options.AddToken(token, tokenType);
      });
    }

    public static SpotifyClientConfig CreateDefault(Action<SpotifyClientConfig> optionsCallback)
    {
      Ensure.ArgumentNotNull(optionsCallback, nameof(optionsCallback));

      var config = new SpotifyClientConfig(
        SpotifyUrls.APIV1,
        null,
        new NewtonsoftJSONSerializer(),
        new NetHttpClient(),
        null,
        null,
        new SimplePaginator()
      );
      optionsCallback(config);

      if (config.Authenticator == null)
      {
        throw new NullReferenceException("The authenticator was not set after the options callback was run. Please specify a token with AddToken or AddAuthenticator");
      }
      return config;
    }
  }
}
