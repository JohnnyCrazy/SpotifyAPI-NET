using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using System.Runtime.CompilerServices;

namespace SpotifyAPI.Web
{
  public class SpotifyClient : ISpotifyClient
  {
    private readonly IAPIConnector _apiConnector;

    public SpotifyClient(IToken token) :
      this(SpotifyClientConfig.CreateDefault(token?.AccessToken ?? throw new ArgumentNullException(nameof(token)), token.TokenType))
    { }

    public SpotifyClient(string token, string tokenType = "Bearer") :
      this(SpotifyClientConfig.CreateDefault(token, tokenType))
    { }

    public SpotifyClient(SpotifyClientConfig config)
    {
      Ensure.ArgumentNotNull(config, nameof(config));
      if (config.Authenticator == null)
      {
        throw new NullReferenceException("Authenticator in config is null. Please supply it via `WithAuthenticator` or `WithToken`");
      }

      _apiConnector = new APIConnector(
        config.BaseAddress,
        config.Authenticator,
        config.JSONSerializer,
        config.HTTPClient,
        config.RetryHandler,
        config.HTTPLogger
      );
      _apiConnector.ResponseReceived += (sender, response) =>
      {
        LastResponse = response;
      };

      DefaultPaginator = config.DefaultPaginator;
      UserProfile = new UserProfileClient(_apiConnector);
      Browse = new BrowseClient(_apiConnector);
      Shows = new ShowsClient(_apiConnector);
      Playlists = new PlaylistsClient(_apiConnector);
      Search = new SearchClient(_apiConnector);
      Follow = new FollowClient(_apiConnector);
      Tracks = new TracksClient(_apiConnector);
      Player = new PlayerClient(_apiConnector);
      Albums = new AlbumsClient(_apiConnector);
      Artists = new ArtistsClient(_apiConnector);
      Personalization = new PersonalizationClient(_apiConnector);
      Episodes = new EpisodesClient(_apiConnector);
      Library = new LibraryClient(_apiConnector);
    }

    public IPaginator DefaultPaginator { get; }

    public IUserProfileClient UserProfile { get; }

    public IBrowseClient Browse { get; }

    public IShowsClient Shows { get; }

    public IPlaylistsClient Playlists { get; }

    public ISearchClient Search { get; }

    public IFollowClient Follow { get; }

    public ITracksClient Tracks { get; }

    public IPlayerClient Player { get; }

    public IAlbumsClient Albums { get; }

    public IArtistsClient Artists { get; }

    public IPersonalizationClient Personalization { get; }

    public IEpisodesClient Episodes { get; }

    public ILibraryClient Library { get; }

    public IResponse? LastResponse { get; private set; }

    /// <summary>
    /// Fetches all pages and returns them grouped in a list.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">The first page, will be included in the output list!</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <returns>A list containing all fetched pages</returns>
    public Task<IList<T>> PaginateAll<T>(IPaginatable<T> firstPage, IPaginator? paginator = null)
    {
      return (paginator ?? DefaultPaginator).PaginateAll(firstPage, _apiConnector);
    }

    /// <summary>
    /// Fetches all pages and returns them grouped in a list.
    /// Some responses (e.g search response) have the pagination nested in a JSON Property.
    /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">A first page, will be included in the output list!</param>
    /// <param name="mapper">A function which maps response objects to the next paging object</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <typeparam name="TNext">The Response-Type</typeparam>
    /// <returns>A list containing all fetched pages</returns>
    public Task<IList<T>> PaginateAll<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = null
    )
    {
      return (paginator ?? DefaultPaginator).PaginateAll(firstPage, mapper, _apiConnector);
    }

#if NETSTANDARD2_1

    /// <summary>
    /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">A first page, will be included in the output list!</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <param name="cancellationToken">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <returns>An iterable IAsyncEnumerable</returns>
    public IAsyncEnumerable<T> Paginate<T>(
      IPaginatable<T> firstPage,
      IPaginator? paginator = null,
      CancellationToken cancellationToken = default
    )
    {
      return (paginator ?? DefaultPaginator).Paginate(firstPage, _apiConnector, cancellationToken);
    }

    /// <summary>
    /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
    /// Some responses (e.g search response) have the pagination nested in a JSON Property.
    /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">A first page, will be included in the output list!</param>
    /// <param name="mapper">A function which maps response objects to the next paging object</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <param name="cancellationToken">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <typeparam name="TNext">The Response-Type</typeparam>
    /// <returns></returns>
    public IAsyncEnumerable<T> Paginate<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = null,
      CancellationToken cancellationToken = default
    )
    {
      return (paginator ?? DefaultPaginator).Paginate(firstPage, mapper, _apiConnector, cancellationToken);
    }

    /// <summary>
    /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
    /// Some responses (e.g search response) have the pagination nested in a JSON Property.
    /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="getFirstPage">A Function to retrive the first page, will be included in the output list!</param>
    /// <param name="mapper">A function which maps response objects to the next paging object</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <param name="cancellationToken">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <typeparam name="TNext">The Response-Type</typeparam>
    /// <returns></returns>
    public async IAsyncEnumerable<T> Paginate<T, TNext>(
      Func<Task<IPaginatable<T, TNext>>> getFirstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = null,
      [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      await foreach (var item in (paginator ?? DefaultPaginator)
        .Paginate(firstPage, mapper, _apiConnector, cancellationToken)
        .WithCancellation(cancellationToken)
      )
      {
        yield return item;
      }
    }

    /// <summary>
    /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
    /// Some responses (e.g search response) have the pagination nested in a JSON Property.
    /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPageTask">A Task to retrive the first page, will be included in the output list!</param>
    /// <param name="mapper">A function which maps response objects to the next paging object</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <param name="cancellationToken">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <typeparam name="TNext">The Response-Type</typeparam>
    /// <returns></returns>
    public async IAsyncEnumerable<T> Paginate<T, TNext>(
      Task<IPaginatable<T, TNext>> firstPageTask,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = null,
      [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      Ensure.ArgumentNotNull(firstPageTask, nameof(firstPageTask));

      var firstPage = await firstPageTask.ConfigureAwait(false);
      await foreach (var item in (paginator ?? DefaultPaginator)
        .Paginate(firstPage, mapper, _apiConnector, cancellationToken)
        .WithCancellation(cancellationToken)
      )
      {
        yield return item;
      }
    }
#endif
  }
}
