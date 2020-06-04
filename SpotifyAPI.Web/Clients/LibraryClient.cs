using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class LibraryClient : APIClient, ILibraryClient
  {
    public LibraryClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<List<bool>> CheckAlbums(LibraryCheckAlbumsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryAlbumsContains(), request.BuildQueryParams());
    }

    public Task<List<bool>> CheckShows(LibraryCheckShowsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryShowsContains(), request.BuildQueryParams());
    }

    public Task<List<bool>> CheckTracks(LibraryCheckTracksRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryTracksContains(), request.BuildQueryParams());
    }

    public Task<Paging<SavedAlbum>> GetAlbums()
    {
      return API.Get<Paging<SavedAlbum>>(SpotifyUrls.LibraryAlbums());
    }

    public Task<Paging<SavedAlbum>> GetAlbums(LibraryAlbumsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedAlbum>>(SpotifyUrls.LibraryAlbums(), request.BuildQueryParams());
    }

    public Task<Paging<SavedShow>> GetShows()
    {
      return API.Get<Paging<SavedShow>>(SpotifyUrls.LibraryShows());
    }

    public Task<Paging<SavedShow>> GetShows(LibraryShowsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedShow>>(SpotifyUrls.LibraryShows(), request.BuildQueryParams());
    }

    public Task<Paging<SavedTrack>> GetTracks()
    {
      return API.Get<Paging<SavedTrack>>(SpotifyUrls.LibraryTracks());
    }

    public Task<Paging<SavedTrack>> GetTracks(LibraryTracksRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedTrack>>(SpotifyUrls.LibraryTracks(), request.BuildQueryParams());
    }

    public async Task<bool> RemoveAlbums(LibraryRemoveAlbumsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryAlbums(), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public async Task<bool> RemoveShows(LibraryRemoveShowsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryShows(), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public async Task<bool> RemoveTracks(LibraryRemoveTracksRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryTracks(), null, request.BuildBodyParams()).ConfigureAwait(false);
      return statusCode == HttpStatusCode.OK;
    }

    public async Task<bool> SaveAlbums(LibrarySaveAlbumsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryAlbums(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Created;
    }

    public async Task<bool> SaveShows(LibrarySaveShowsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryShows(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Created;
    }

    public async Task<bool> SaveTracks(LibrarySaveTracksRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryTracks(), request.BuildQueryParams(), null).ConfigureAwait(false);
      return statusCode == HttpStatusCode.Created;
    }
  }
}
