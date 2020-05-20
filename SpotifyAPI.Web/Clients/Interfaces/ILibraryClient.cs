using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  public interface ILibraryClient
  {
    Task<bool> RemoveAlbums(LibraryRemoveAlbumsRequest request);
    Task<bool> RemoveTracks(LibraryRemoveTracksRequest request);
    Task<bool> RemoveShows(LibraryRemoveShowsRequest request);

    Task<bool> SaveTracks(LibrarySaveTracksRequest request);
    Task<bool> SaveAlbums(LibrarySaveAlbumsRequest request);
    Task<bool> SaveShows(LibrarySaveShowsRequest request);

    Task<List<bool>> CheckTracks(LibraryCheckTracksRequest request);
    Task<List<bool>> CheckAlbums(LibraryCheckAlbumsRequest request);
    Task<List<bool>> CheckShows(LibraryCheckShowsRequest request);

    Task<Paging<SavedTrack>> GetTracks();
    Task<Paging<SavedTrack>> GetTracks(LibraryTracksRequest request);
    Task<Paging<SavedAlbum>> GetAlbums();
    Task<Paging<SavedAlbum>> GetAlbums(LibraryAlbumsRequest request);
    Task<Paging<SavedShow>> GetShows();
    Task<Paging<SavedShow>> GetShows(LibraryShowsRequest request);
  }
}
