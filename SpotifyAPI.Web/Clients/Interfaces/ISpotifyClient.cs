using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public interface ISpotifyClient
  {
    IPaginator DefaultPaginator { get; }

    IUserProfileClient UserProfile { get; }

    IBrowseClient Browse { get; }

    IShowsClient Shows { get; }

    IPlaylistsClient Playlists { get; }

    ISearchClient Search { get; }

    IFollowClient Follow { get; }

    ITracksClient Tracks { get; }

    IPlayerClient Player { get; }

    IAlbumsClient Albums { get; }

    IArtistsClient Artists { get; }

    IPersonalizationClient Personalization { get; }

    IEpisodesClient Episodes { get; }

    ILibraryClient Library { get; }

    IResponse? LastResponse { get; }

    Task<IList<T>> PaginateAll<T>(Paging<T> firstPage);
    Task<IList<T>> PaginateAll<T>(Paging<T> firstPage, IPaginator paginator);
    Task<IList<T>> PaginateAll<T>(Func<Task<Paging<T>>> getFirstPage);
    Task<IList<T>> PaginateAll<T>(Func<Task<Paging<T>>> getFirstPage, IPaginator paginator);

    Task<IList<T>> PaginateAll<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper);
    Task<IList<T>> PaginateAll<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper, IPaginator paginator);
    Task<IList<T>> PaginateAll<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper);
    Task<IList<T>> PaginateAll<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper, IPaginator paginator);

#if NETSTANDARD2_1
    IAsyncEnumerable<T> Paginate<T>(Paging<T> firstPage);
    IAsyncEnumerable<T> Paginate<T>(Paging<T> firstPage, IPaginator paginator);
    IAsyncEnumerable<T> Paginate<T>(Func<Task<Paging<T>>> getFirstPage);
    IAsyncEnumerable<T> Paginate<T>(Func<Task<Paging<T>>> getFirstPage, IPaginator paginator);

    IAsyncEnumerable<T> Paginate<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper);
    IAsyncEnumerable<T> Paginate<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper, IPaginator paginator);
    IAsyncEnumerable<T> Paginate<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper);
    IAsyncEnumerable<T> Paginate<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper, IPaginator paginator);
#endif
  }
}
