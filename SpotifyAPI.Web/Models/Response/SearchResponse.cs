namespace SpotifyAPI.Web
{
  public class SearchResponse
  {
    public Paging<FullArtist> Artists { get; set; }
    public Paging<SimpleAlbum> Albums { get; set; }
    public Paging<FullTrack> Tracks { get; set; }
    public Paging<SimpleShow> Shows { get; set; }
    public Paging<SimpleEpisode> Episodes { get; set; }
  }
}
