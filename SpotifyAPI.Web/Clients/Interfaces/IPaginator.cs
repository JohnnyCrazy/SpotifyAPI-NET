using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public interface IPaginator
  {
    Task<List<T>> PaginateAll<T>(Paging<T> firstPage, IAPIConnector connector);
    Task<List<T>> PaginateAll<T, TNext>(
      Paging<T, TNext> firstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IAPIConnector connector
    );

#if NETSTANDARD2_1
    IAsyncEnumerable<T> Paginate<T>(Paging<T> firstPage, IAPIConnector connector, CancellationToken cancel = default);
    IAsyncEnumerable<T> Paginate<T, TNext>(
      Paging<T, TNext> firstPage,
      Func<TNext, Paging<T, TNext>> mapper,
      IAPIConnector connector,
      CancellationToken cancel = default
    );
#endif
  }
}
