using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetItemsRequest : RequestParams
  {
    public PlaylistGetItemsRequest(AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNull(types, nameof(types));

      AdditionalTypesParam = types;
      Fields = new List<string>();
    }

    [QueryParam("fields")]
    public IList<string> Fields { get; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    /// <summary>
    ///   This is set to `"track", "episode"` by default.
    /// </summary>
    /// <value></value>
    [QueryParam("additional_types")]
    public AdditionalTypes AdditionalTypesParam { get; set; }

    [Flags]
    public enum AdditionalTypes
    {
      [String("track")]
      Track = 1,
      [String("episode")]
      Episode = 2,
      All = Track | Episode
    }
  }
}
