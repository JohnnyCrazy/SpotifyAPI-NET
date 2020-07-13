using System;

namespace SpotifyAPI.Web
{
  public class ArtistsAlbumsRequest : RequestParams
  {
    /// <summary>
    /// A comma-separated list of keywords that will be used to filter the response.
    /// If not supplied, all album types will be returned.
    /// </summary>
    /// <value></value>
    [QueryParam("include_groups")]
    public IncludeGroups? IncludeGroupsParam { get; set; }

    /// <summary>
    /// Synonym for country. An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Supply this parameter to limit the response to one particular geographical market.
    /// For example, for albums available in Sweden: market=SE.
    /// If not given, results will be returned for all markets and you are likely to get duplicate results per album,
    /// one for each market in which the album is available!
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }

    /// <summary>
    /// The number of album objects to return. Default: 20. Minimum: 1. Maximum: 50. For example: limit=2
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first album to return. Default: 0 (i.e., the first album). Use with limit to get the next set of albums.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    [Flags]
    public enum IncludeGroups
    {
      [String("album")]
      Album = 1,

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
      [String("single")]
      Single = 2,

      [String("appears_on")]
      AppearsOn = 4,

      [String("compilation")]
      Compilation = 8,
    }
  }
}

