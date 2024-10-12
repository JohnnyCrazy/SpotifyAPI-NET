using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class LibraryClient : APIClient, ILibraryClient
  {
    public LibraryClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<List<bool>> CheckAlbums(LibraryCheckAlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryAlbumsContains(), request.BuildQueryParams(), cancel);
    }

    public Task<List<bool>> CheckShows(LibraryCheckShowsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryShowsContains(), request.BuildQueryParams(), cancel);
    }

    public Task<List<bool>> CheckTracks(LibraryCheckTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryTracksContains(), request.BuildQueryParams(), cancel);
    }

    public Task<List<bool>> CheckEpisodes(LibraryCheckEpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryEpisodesContains(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SavedAlbum>> GetAlbums(CancellationToken cancel = default)
    {
      return API.Get<Paging<SavedAlbum>>(SpotifyUrls.LibraryAlbums(), cancel);
    }

    public Task<Paging<SavedAlbum>> GetAlbums(LibraryAlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedAlbum>>(SpotifyUrls.LibraryAlbums(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SavedShow>> GetShows(CancellationToken cancel = default)
    {
      return API.Get<Paging<SavedShow>>(SpotifyUrls.LibraryShows(), cancel);
    }

    public Task<Paging<SavedShow>> GetShows(LibraryShowsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedShow>>(SpotifyUrls.LibraryShows(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SavedTrack>> GetTracks(CancellationToken cancel = default)
    {
      return API.Get<Paging<SavedTrack>>(SpotifyUrls.LibraryTracks(), cancel);
    }

    public Task<Paging<SavedTrack>> GetTracks(LibraryTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedTrack>>(SpotifyUrls.LibraryTracks(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SavedEpisodes>> GetEpisodes(CancellationToken cancel = default)
    {
      return API.Get<Paging<SavedEpisodes>>(SpotifyUrls.LibraryEpisodes(), cancel);
    }

    public Task<Paging<SavedEpisodes>> GetEpisodes(LibraryEpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SavedEpisodes>>(SpotifyUrls.LibraryEpisodes(), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<SimpleAudiobook>> GetAudiobooks(LibraryAudiobooksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<SimpleAudiobook>>(SpotifyUrls.LibraryAudiobooks(), request.BuildQueryParams(), cancel);
    }

    public async Task<bool> RemoveAlbums(LibraryRemoveAlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryAlbums(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> RemoveShows(LibraryRemoveShowsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryShows(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> RemoveTracks(LibraryRemoveTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryTracks(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> RemoveEpisodes(LibraryRemoveEpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryEpisodes(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SaveAlbums(LibrarySaveAlbumsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryAlbums(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SaveShows(LibrarySaveShowsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryShows(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SaveTracks(LibrarySaveTracksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryTracks(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SaveEpisodes(LibrarySaveEpisodesRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryEpisodes(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> SaveAudiobooks(LibrarySaveAudiobooksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Put(SpotifyUrls.LibraryAudiobooks(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public async Task<bool> RemoveAudiobooks(LibraryRemoveAudiobooksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var statusCode = await API.Delete(SpotifyUrls.LibraryAudiobooks(), request.BuildQueryParams(), null, cancel).ConfigureAwait(false);
      return HTTPUtil.StatusCodeIsSuccess(statusCode);
    }

    public Task<List<bool>> CheckAudiobooks(LibraryCheckAudiobooksRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<List<bool>>(SpotifyUrls.LibraryAudiobooksContains(), request.BuildQueryParams(), cancel);
    }
  }
}
