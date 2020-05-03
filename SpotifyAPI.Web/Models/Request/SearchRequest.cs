using System;

namespace SpotifyAPI.Web
{
  public class SearchRequest : RequestParams
  {
    [QueryParam("type")]
    public Type? Types { get; set; }

    [QueryParam("q")]
    public string Query { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [QueryParam("include_external")]
    public External? IncludeExternal { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNull(Types, nameof(Types));
      Ensure.ArgumentNotNullOrEmptyString(Query, nameof(Query));
    }

    [Flags]
    public enum External
    {
      [String("audio")]
      Audio = 0,
    }

    [Flags]
    public enum Type
    {
      [String("album")]
      Album = 0,
      [String("artist")]
      Artist = 1,
      [String("playlist")]
      Playlist = 2,
      [String("track")]
      Track = 4,
      [String("show")]
      Show = 8,
      [String("episode")]
      Episode = 16,
      All = Album | Artist | Playlist | Track | Show | Episode
    }
  }
}
