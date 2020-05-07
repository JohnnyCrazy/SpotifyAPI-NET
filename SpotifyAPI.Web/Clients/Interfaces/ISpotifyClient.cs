using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    Task<List<T>> Paginate<T>(Paging<T> firstPage);
    Task<List<T>> Paginate<T, TNext>(Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper);
    Task<List<T>> Paginate<T>(Func<Task<Paging<T>>> getFirstPage);
    Task<List<T>> Paginate<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper);
    Task<List<T>> Paginate<T>(Paging<T> firstPage, IPaginator paginator);
    Task<List<T>> Paginate<T>(Func<Task<Paging<T>>> getFirstPage, IPaginator paginator);
  }
}
