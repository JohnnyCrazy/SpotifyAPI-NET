using System;

namespace SpotifyAPI.Web
{
  public class SearchRequest : RequestParams
  {
    public SearchRequest(Types type, string query)
    {
      Ensure.ArgumentNotNull(type, nameof(type));
      Ensure.ArgumentNotNullOrEmptyString(query, nameof(query));

      Type = type;
      Query = query;
    }

    [QueryParam("type")]
    public Types Type { get; set; }

    [QueryParam("q")]
    public string Query { get; set; }

    [QueryParam("market")]
    public string? Market { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [QueryParam("include_external")]
    public IncludeExternals? IncludeExternal { get; set; }

    [Flags]
    public enum IncludeExternals
    {
      [String("audio")]
      Audio = 1,
    }

    [Flags]
    public enum Types
    {
      [String("album")]
      Album = 1,
      [String("artist")]
      Artist = 2,
      [String("playlist")]
      Playlist = 4,
      [String("track")]
      Track = 8,
      [String("show")]
      Show = 16,
      [String("episode")]
      Episode = 32,
      All = Album | Artist | Playlist | Track | Show | Episode
    }
  }
}

