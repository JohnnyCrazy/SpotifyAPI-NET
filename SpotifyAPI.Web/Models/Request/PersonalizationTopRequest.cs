namespace SpotifyAPI.Web
{
  public class PersonalizationTopRequest : RequestParams
  {
    [QueryParam("limit")]
    public int? Limit { get; set; }

    [QueryParam("offset")]
    public int? Offset { get; set; }

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
