namespace SpotifyAPI.Web
{
  public class SearchResponse
  {
    public Paging<FullArtist, SearchResponse> Artists { get; set; }
    public Paging<SimpleAlbum, SearchResponse> Albums { get; set; }
    public Paging<FullTrack, SearchResponse> Tracks { get; set; }
    public Paging<SimpleShow, SearchResponse> Shows { get; set; }
    public Paging<SimpleEpisode, SearchResponse> Episodes { get; set; }
  }
}
