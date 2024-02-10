using System;
using System.Collections.Generic;
#if !NETSTANDARD2_0
using System.Runtime.CompilerServices;
#endif
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SimplePaginator : IPaginator
  {
    protected virtual Task<bool> ShouldContinue<T>(List<T> results, IPaginatable<T> page)
    {
      return Task.FromResult(true);
    }
    protected virtual Task<bool> ShouldContinue<T, TNext>(List<T> results, IPaginatable<T, TNext> page)
    {
      return Task.FromResult(true);
    }

    public async Task<IList<T>> PaginateAll<T>(IPaginatable<T> firstPage, IAPIConnector connector, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(connector, nameof(connector));

      var page = firstPage;
      var results = new List<T>();
      if (page.Items != null)
      {
        results.AddRange(page.Items);
      }
      while (page.Next != null && await ShouldContinue(results, page).ConfigureAwait(false))
      {
        page = await connector.Get<Paging<T>>(new Uri(page.Next, UriKind.Absolute), cancel).ConfigureAwait(false);
        if (page.Items != null)
        {
          results.AddRange(page.Items);
        }
      }

      return results;
    }

    public async Task<IList<T>> PaginateAll<T, TNext>(
      IPaginatable<T, TNext> firstPage, Func<TNext, IPaginatable<T, TNext>> mapper, IAPIConnector connector,
      CancellationToken cancel = default
    )
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(mapper, nameof(mapper));
      Ensure.ArgumentNotNull(connector, nameof(connector));

      var page = firstPage;
      var results = new List<T>();
      if (page.Items != null)
      {
        results.AddRange(page.Items);
      }
      while (page.Next != null && await ShouldContinue(results, page).ConfigureAwait(false))
      {
        var next = await connector.Get<TNext>(new Uri(page.Next, UriKind.Absolute), cancel).ConfigureAwait(false);
        page = mapper(next);
        if (page.Items != null)
        {
          results.AddRange(page.Items);
        }
      }

      return results;
    }

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
    public async IAsyncEnumerable<T> Paginate<T>(
      IPaginatable<T> firstPage,
      IAPIConnector connector,
      [EnumeratorCancellation] CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(connector, nameof(connector));
      if (firstPage.Items == null)
      {
        throw new ArgumentException("The first page has to contain an Items list!", nameof(firstPage));
      }

      var page = firstPage;
      foreach (var item in page.Items)
      {
        yield return item;
      }
      while (page.Next != null)
      {
        page = await connector.Get<Paging<T>>(new Uri(page.Next, UriKind.Absolute), cancel).ConfigureAwait(false);
        foreach (var item in page.Items!)
        {
          yield return item;
        }
      }
    }

    public async IAsyncEnumerable<T> Paginate<T, TNext>(
      IPaginatable<T, TNext> firstPage,
      Func<TNext, IPaginatable<T, TNext>> mapper,
      IAPIConnector connector,
      [EnumeratorCancellation] CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(mapper, nameof(mapper));
      Ensure.ArgumentNotNull(connector, nameof(connector));
      if (firstPage.Items == null)
      {
        throw new ArgumentException("The first page has to contain an Items list!", nameof(firstPage));
      }

      var page = firstPage;
      foreach (var item in page.Items)
      {
        yield return item;
      }
      while (page.Next != null)
      {
        var next = await connector.Get<TNext>(new Uri(page.Next, UriKind.Absolute), cancel).ConfigureAwait(false);
        page = mapper(next);
        foreach (var item in page.Items!)
        {
          yield return item;
        }
      }
    }
#endif
  }
}
