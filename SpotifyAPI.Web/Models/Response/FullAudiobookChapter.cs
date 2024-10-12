namespace SpotifyAPI.Web
{
  public class FullAudiobookChapter : SimpleAudiobookChapter
  {
    public SimpleAudiobook Audiobook { get; set; } = default!;
  }
}
