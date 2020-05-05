using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SimplePaginator : IPaginator
  {
    protected virtual Task<bool> ShouldContinue<T>(List<T> results, Paging<T> page)
    {
      return Task.FromResult(true);
    }
    protected virtual Task<bool> ShouldContinue<T, TNext>(List<T> results, Paging<T, TNext> page)
    {
      return Task.FromResult(true);
    }

    public async Task<List<T>> Paginate<T>(Paging<T> firstPage, IAPIConnector connector)
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(connector, nameof(connector));

      var page = firstPage;
      var results = new List<T>();
      results.AddRange(firstPage.Items);
      while (page.Next != null && await ShouldContinue(results, page).ConfigureAwait(false))
      {
        page = await connector.Get<Paging<T>>(new Uri(page.Next, UriKind.Absolute)).ConfigureAwait(false);
        results.AddRange(page.Items);
      }

      return results;
    }

    public async Task<List<T>> Paginate<T>(Func<Task<Paging<T>>> getFirstPage, IAPIConnector connector)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      return await Paginate(firstPage, connector).ConfigureAwait(false);
    }

    public async Task<List<T>> Paginate<T, TNext>(
      Paging<T, TNext> firstPage, Func<TNext, Paging<T, TNext>> mapper, IAPIConnector connector
    )
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(mapper, nameof(mapper));
      Ensure.ArgumentNotNull(connector, nameof(connector));

      var page = firstPage;
      var results = new List<T>();
      results.AddRange(firstPage.Items);
      while (page.Next != null && await ShouldContinue(results, page).ConfigureAwait(false))
      {
        var next = await connector.Get<TNext>(new Uri(page.Next, UriKind.Absolute)).ConfigureAwait(false);
        page = mapper(next);
        results.AddRange(page.Items);
      }

      return results;
    }

    public async Task<List<T>> Paginate<T, TNext>(Func<Task<Paging<T, TNext>>> getFirstPage, Func<TNext, Paging<T, TNext>> mapper, IAPIConnector connector)
    {
      Ensure.ArgumentNotNull(getFirstPage, nameof(getFirstPage));

      var firstPage = await getFirstPage().ConfigureAwait(false);
      return await Paginate(firstPage, mapper, connector).ConfigureAwait(false);
    }
  }
}
