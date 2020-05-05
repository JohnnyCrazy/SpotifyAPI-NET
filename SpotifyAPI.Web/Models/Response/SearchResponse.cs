namespace SpotifyAPI.Web
{
  public class SearchResponse
  {
    public Paging<FullArtist> Artists { get; private set; }
    public Paging<SimpleAlbum> Albums { get; private set; }
    public Paging<FullTrack> Tracks { get; private set; }
    public Paging<SimpleShow> Shows { get; private set; }
    public Paging<SimpleEpisode> Episodes { get; private set; }
  }
}
