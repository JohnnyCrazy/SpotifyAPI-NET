using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using SpotifyAPI.Web;

namespace Example.UWP.ViewModels
{
  /// <summary>
  ///   Spotify Token is the parameter
  /// </summary>
  public class PlaylistsListViewModel : MvxViewModel<string>
  {
    private SpotifyClient _spotify;

    private List<SimplePlaylist> _playlists;
    public List<SimplePlaylist> Playlists
    {
      get => _playlists ?? (_playlists = new List<SimplePlaylist>());
      set => SetProperty(ref _playlists, value);
    }

    public override void Prepare(string token)
    {
      _spotify = new SpotifyClient(SpotifyClientConfig.CreateDefault(token));
    }

    public override async Task Initialize()
    {
      await base.Initialize();

      Playlists = await _spotify.PaginateAll(() => _spotify.Playlists.CurrentUsers());
    }
  }
}
