using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class SimplePaginator : IPaginator
  {
    protected bool ShouldContinue<T>(List<T> results, Paging<T> page)
    {
      return true;
    }

    public async Task<List<T>> Paginate<T>(Paging<T> firstPage, IAPIConnector connector)
    {
      Ensure.ArgumentNotNull(firstPage, nameof(firstPage));
      Ensure.ArgumentNotNull(connector, nameof(connector));

      var page = firstPage;
      var results = new List<T>();
      results.AddRange(firstPage.Items);
      while (page.Next != null && ShouldContinue(results, page))
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
  }
}
