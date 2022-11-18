using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public interface ISpotifyClient
  {
    /// <summary>
    /// The default paginator used by the Paginator methods
    /// </summary>
    /// <value></value>
    IPaginator DefaultPaginator { get; }

    /// <summary>
    /// Operations related to Spotify User Profiles
    /// </summary>
    /// <value></value>
    IUserProfileClient UserProfile { get; }

    /// <summary>
    /// Operations related to Spotify Browse Endpoints
    /// </summary>
    /// <value></value>
    IBrowseClient Browse { get; }

    /// <summary>
    /// Operations related to Spotify Shows
    /// </summary>
    /// <value></value>
    IShowsClient Shows { get; }

    /// <summary>
    /// Operations related to Spotify Playlists
    /// </summary>
    /// <value></value>
    IPlaylistsClient Playlists { get; }

    /// <summary>
    /// Operations related to Spotify Search
    /// </summary>
    /// <value></value>
    ISearchClient Search { get; }

    /// <summary>
    /// Operations related to Spotify Follows
    /// </summary>
    /// <value></value>
    IFollowClient Follow { get; }

    /// <summary>
    /// Operations related to Spotify Tracks
    /// </summary>
    /// <value></value>
    ITracksClient Tracks { get; }

    /// <summary>
    /// Operations related to Spotify Player Endpoints
    /// </summary>
    /// <value></value>
    IPlayerClient Player { get; }

    /// <summary>
    /// Operations related to Spotify Albums
    /// </summary>
    /// <value></value>
    IAlbumsClient Albums { get; }

    /// <summary>
    /// Operations related to Spotify Artists
    /// </summary>
    /// <value></value>
    IArtistsClient Artists { get; }

    /// <summary>
    /// Operations related to Spotify Personalization Endpoints
    /// </summary>
    /// <value></value>
    IPersonalizationClient Personalization { get; }

    /// <summary>
    /// Operations related to Spotify Podcast Episodes
    /// </summary>
    /// <value></value>
    IEpisodesClient Episodes { get; }

    /// <summary>
    /// Operations related to Spotify User Library
    /// </summary>
    /// <value></value>
    ILibraryClient Library { get; }

    /// <summary>
    /// Returns the last response received by an API call.
    /// </summary>
    /// <value></value>
    IResponse? LastResponse { get; }

    /// <summary>
    /// Fetches all pages and returns them grouped in a list.
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">The first page, will be included in the output list!</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <returns>A list containing all fetched pages</returns>
    Task<IList<T>> PaginateAll<T>(IPaginatable<T> firstPage, IPaginator? paginator = default!);

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
    Task<IList<T>> PaginateAll<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = default!
    );

    /// <summary>
    /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
    /// The default paginator will fetch all available resources without a delay between requests.
    /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
    /// </summary>
    /// <param name="firstPage">A first page, will be included in the output list!</param>
    /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
    /// <param name="cancel">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <returns>An iterable IAsyncEnumerable</returns>
    IAsyncEnumerable<T> Paginate<T>(
      IPaginatable<T> firstPage,
      IPaginator? paginator = default!,
      CancellationToken cancel = default!
    );

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
    /// <param name="cancel">An optional Cancellation Token</param>
    /// <typeparam name="T">The Paging-Type</typeparam>
    /// <typeparam name="TNext">The Response-Type</typeparam>
    /// <returns></returns>
    IAsyncEnumerable<T> Paginate<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IPaginator? paginator = default!,
      CancellationToken cancel = default!
    );

    public Task<Paging<T>> NextPage<T>(Paging<T> paging);

    public Task<CursorPaging<T>> NextPage<T>(CursorPaging<T> cursorPaging);

    public Task<TNext> NextPage<T, TNext>(IPaginatable<T, TNext> paginatable);

    public Task<Paging<T>> PreviousPage<T>(Paging<T> paging);

    public Task<TNext> PreviousPage<T, TNext>(Paging<T, TNext> paging);
  }
}
