using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SpotifyClient : ISpotifyClient
  {
    private readonly IAPIConnector _apiConnector;

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

    public Task<List<T>> PaginateAll<T>(Paging<T> firstPage)
    {
      return DefaultPaginator.PaginateAll(firstPage, _apiConnector);
    }

    public Task<List<T>> PaginateAll<T>(Paging<T> firstPage, IPaginator paginator)
    {
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return paginator.PaginateAll(firstPage, _apiConnector);
    }

    public async Task<List<T>> PaginateAll<T>(Func<Task<Paging<T>>> getFirstPage)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      return await DefaultPaginator.PaginateAll(
        await getFirstPage().ConfigureAwait(false), _apiConnector
      ).ConfigureAwait(false);
    }

    public async Task<List<T>> PaginateAll<T>(Func<Task<Paging<T>>> getFirstPage, IPaginator paginator)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return await paginator.PaginateAll(
        await getFirstPage().ConfigureAwait(false), _apiConnector
      ).ConfigureAwait(false);
    }

    public Task<List<T>> PaginateAll<T, TNext>(
      Paging<T, TNext> firstPage,
      Func<TNext, Paging<T, TNext>> mapper
    )
    {
      return DefaultPaginator.PaginateAll(firstPage, mapper, _apiConnector);
    }

    public async Task<List<T>> PaginateAll<T, TNext>(
      Func<Task<Paging<T, TNext>>> getFirstPage,
      Func<TNext, Paging<T, TNext>> mapper
    )
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      return await DefaultPaginator.PaginateAll(await getFirstPage().ConfigureAwait(false), mapper, _apiConnector).ConfigureAwait(false);
    }

    public Task<List<T>> PaginateAll<T, TNext>(
      Paging<T, TNext> firstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IPaginator paginator)
    {
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return paginator.PaginateAll(firstPage, mapper, _apiConnector);
    }

    public async Task<List<T>> PaginateAll<T, TNext>(
      Func<Task<Paging<T, TNext>>> getFirstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IPaginator paginator
    )
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return await paginator.PaginateAll(
        await getFirstPage().ConfigureAwait(false), mapper, _apiConnector
      ).ConfigureAwait(false);
    }


#if NETSTANDARD2_1
    public IAsyncEnumerable<T> Paginate<T>(Paging<T> firstPage)
    {
      return DefaultPaginator.Paginate(firstPage, _apiConnector);
    }

    public IAsyncEnumerable<T> Paginate<T>(Paging<T> firstPage, IPaginator paginator)
    {
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return paginator.Paginate(firstPage, _apiConnector);
    }

    public async IAsyncEnumerable<T> Paginate<T>(Func<Task<Paging<T>>> getFirstPage)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      await foreach (var item in DefaultPaginator.Paginate(firstPage, _apiConnector))
      {
        yield return item;
      }
    }

    public async IAsyncEnumerable<T> Paginate<T>(Func<Task<Paging<T>>> getFirstPage, IPaginator paginator)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      await foreach (var item in DefaultPaginator.Paginate(firstPage, _apiConnector))
      {
        yield return item;
      }
    }

    public IAsyncEnumerable<T> Paginate<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper)
    {
      return DefaultPaginator.Paginate(firstPage, mapper, _apiConnector);
    }

    public IAsyncEnumerable<T> Paginate<T, TNext>(
      Paging<T, TNext> firstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IPaginator paginator
    )
    {
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      return paginator.Paginate(firstPage, mapper, _apiConnector);
    }

    public async IAsyncEnumerable<T> Paginate<T, TNext>(
      Func<Task<Paging<T, TNext>>> getFirstPage,
      Func<TNext, Paging<T, TNext>> mapper
    )
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      await foreach (var item in DefaultPaginator.Paginate(firstPage, mapper, _apiConnector))
      {
        yield return item;
      }
    }

    public async IAsyncEnumerable<T> Paginate<T, TNext>(
      Func<Task<Paging<T, TNext>>> getFirstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IPaginator paginator
    )
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));
      Ensure.ArgumentNotNull(paginator, nameof(paginator));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      await foreach (var item in paginator.Paginate(firstPage, mapper, _apiConnector))
      {
        yield return item;
      }
    }
#endif
  }
}
