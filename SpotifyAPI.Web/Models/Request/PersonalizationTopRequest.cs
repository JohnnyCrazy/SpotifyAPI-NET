namespace SpotifyAPI.Web
{
  public class PersonalizationTopRequest : RequestParams
  {
    /// <summary>
    /// The number of entities to return. Default: 20. Minimum: 1. Maximum: 50. For example: limit=2
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// Over what time frame the affinities are computed. Valid values: long_term
    /// (calculated from several years of data and including all new data as it becomes available),
    /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). Default: medium_term
    /// </summary>
    /// <value></value>
    [QueryParam("time_range")]
    public TimeRange? TimeRangeParam { get; set; }

    public enum TimeRange
    {
      [String("long_term")]
      LongTerm,

      [String("medium_term")]
      MediumTerm,

      [String("short_term")]
      ShortTerm
    }
  }
}

