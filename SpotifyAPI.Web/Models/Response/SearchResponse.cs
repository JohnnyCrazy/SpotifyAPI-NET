namespace SpotifyAPI.Web
{
  public class SearchResponse
  {
    public Paging<FullArtist, SearchResponse> Artists { get; set; } = default!;
    public Paging<SimpleAlbum, SearchResponse> Albums { get; set; } = default!;
    public Paging<FullTrack, SearchResponse> Tracks { get; set; } = default!;
    public Paging<SimpleShow, SearchResponse> Shows { get; set; } = default!;
    public Paging<SimpleEpisode, SearchResponse> Episodes { get; set; } = default!;
    public Paging<FullPlaylist, SearchResponse> Playlists { get; set; } = default!;
  }
}

