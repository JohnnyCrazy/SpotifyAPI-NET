namespace SpotifyAPI.Web
{
  public class FullAudiobook : SimpleAudiobook
  {
    public Paging<SimpleAudiobookChapter> Chapters { get; set; } = default!;
  }
}

