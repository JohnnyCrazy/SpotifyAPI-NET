using System;
using System.Threading;

namespace SpotifyAPI.Web.Models.Request
{
    public class UsersTopItemsRequest : RequestParams
    {
    public UsersTopItemsRequest(TimeRange timeRange)
    {
      Ensure.ArgumentNotNull(timeRange, nameof(TimeRange));

      TimeRangeParam = timeRange;
    }

      /// <summary>
      /// The TimeRange Param : How far to look back for the top items.
      /// </summary>
      /// <value></value>
      [QueryParam("time_range")]
      public TimeRange TimeRangeParam  { get; } = TimeRange.MediumTerm;


      /// <summary>
      /// The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.
      /// </summary>
      /// <value></value>
      [QueryParam("limit")]
      public int? Limit { get; set; }

      /// <summary>
      /// The index of the first object to return. Default: 0 (i.e., the first object).
      /// Use with limit to get the next set of objects.
      /// </summary>
      /// <value></value>
      [QueryParam("offset")]
      public int? Offset { get; set; }
        
    }
    public enum TimeRange
    {
      [String("short_term")]
      ShortTerm,
      [String("medium_term")]
      MediumTerm,
      [String("long_term")]
      LongTerm
    }
}
