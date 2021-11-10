using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using SpotifyAPI.Web;

namespace SpotifyAPI.Web
{
  /// <summary>
  /// A paginator allows to cycle through all resources of the spotify API
  /// </summary>
  public interface IPaginator
  {
    /// <summary>
    /// Fetches all pages and returns them grouped in a list
    /// </summary>
    /// <param name="firstPage">The first page. Will be included in the result list!</param>
    /// <param name="connector">An API Connector to make requests to spotify</param>
    /// <typeparam name="T">Paging Type</typeparam>
    /// <returns>A list containing all pages, including the firstPage</returns>
    Task<IList<T>> PaginateAll<T>(IPaginatable<T> firstPage, IAPIConnector connector);

    /// <summary>
    /// Fetches all pages and returns them grouped in a list.
    /// Supports a mapping method which takes care of JSON mapping problems.
    /// To give an example, the Search method always returns the paging objects nested in a key. The mapper functions
    /// tells the paginate function where to find the actual paging object in the response.
    /// </summary>
    /// <param name="firstPage">The first page. Will be included in the result list!</param>
    /// <param name="mapper">A function which returns the actual paging object in another response object</param>
    /// <param name="connector">An API Connector to make requests to spotify</param>
    /// <typeparam name="T">Paging Type</typeparam>
    /// <typeparam name="TNext">Outer response Type</typeparam>
    /// <returns>A list containing all pages, including the firstPage</returns>
    Task<IList<T>> PaginateAll<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IAPIConnector connector
    );

    /// <summary>
    /// Fetches all pages and returns one by one using IAsyncEnumerable
    /// </summary>
    /// <param name="firstPage">The first page. Will be included in the result list!</param>
    /// <param name="connector">An API Connector to make requests to spotify</param>
    /// <param name="cancel">A CancellationToken</param>
    /// <typeparam name="T">Paging Type</typeparam>
    /// <returns></returns>
    IAsyncEnumerable<T> Paginate<T>(IPaginatable<T> firstPage, IAPIConnector connector, CancellationToken cancel = default);

    /// <summary>
    /// Fetches all pages and returns them grouped in a list.
    /// Supports a mapping method which takes care of JSON mapping problems.
    /// To give an example, the Search method always returns the paging objects nested in a key. The mapper functions
    /// tells the paginate function where to find the actual paging object in the response.
    /// </summary>
    /// <param name="firstPage">The first page. Will be included in the result list!</param>
    /// <param name="mapper">A function which returns the actual paging object in another response object</param>
    /// <param name="connector">An API Connector to make requests to spotify</param>
    /// <param name="cancel">A CancellationToken</param>
    /// <typeparam name="T">Paging Type</typeparam>
    /// <typeparam name="TNext">Outer response Type</typeparam>
    /// <returns></returns>
    IAsyncEnumerable<T> Paginate<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IAPIConnector connector,
      CancellationToken cancel = default
    );
  }
}
