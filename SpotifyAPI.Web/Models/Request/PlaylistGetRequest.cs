using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetRequest : RequestParams
  {
    public PlaylistGetRequest()
    {
      AdditionalTypes = AdditionalType.All;
    }

    /// <summary>
    ///   This is set to `"track", "episode"` by default.
    /// </summary>
    /// <value></value>
    [QueryParam("additional_types")]
    public AdditionalType AdditionalTypes { get; set; }

    [Flags]
    public enum AdditionalType
    {
      [String("track")]
      Track = 0,
      [String("episode")]
      Episode = 1,
      All = Track | Episode
    }
  }
}
