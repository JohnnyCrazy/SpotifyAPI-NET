using System;

namespace SpotifyAPI.Web
{
  public class ArtistsAlbumsRequest : RequestParams
  {
    [QueryParam("include_groups")]
    public IncludeGroups? IncludeGroupsParam { get; set; }

    [QueryParam("market")]
    public string Market { get; set; }

    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

    [Flags]
    public enum IncludeGroups
    {
      [String("album")]
      Album,

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
      [String("single")]
      Single,

      [String("appears_on")]
      AppearsOn,

      [String("compilation")]
      Compilation
    }
  }
}
