using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public interface IPaginator
  {
    Task<List<T>> Paginate<T>(Paging<T> firstPage, IAPIConnector connector);
    Task<List<T>> Paginate<T>(Func<Task<Paging<T>>> getFirstPage, IAPIConnector connector);
  }
}
