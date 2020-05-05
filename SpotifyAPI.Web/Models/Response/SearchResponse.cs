namespace SpotifyAPI.Web
{
  public class SearchResponse
  {
    public Paging<FullArtist, SearchResponse> Artists { get; private set; }
    public Paging<SimpleAlbum, SearchResponse> Albums { get; private set; }
    public Paging<FullTrack, SearchResponse> Tracks { get; private set; }
    public Paging<SimpleShow, SearchResponse> Shows { get; private set; }
    public Paging<SimpleEpisode, SearchResponse> Episodes { get; private set; }
  }
}
