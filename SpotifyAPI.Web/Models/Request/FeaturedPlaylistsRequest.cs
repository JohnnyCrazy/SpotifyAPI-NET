using System.Globalization;
using System;
namespace SpotifyAPI.Web
{
  public class FeaturedPlaylistsRequest : RequestParams
  {
    /// <summary>
    /// A country: an ISO 3166-1 alpha-2 country code.
    /// Provide this parameter if you want the list of returned items to be relevant to a particular country.
    /// If omitted, the returned items will be relevant to all countries.
    /// </summary>
    /// <value></value>
    [QueryParam("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The desired language, consisting of a lowercase ISO 639-1 language code and an uppercase ISO 3166-1
    /// alpha-2 country code, joined by an underscore. For example: es_MX, meaning “Spanish (Mexico)”. Provide
    /// this parameter if you want the results returned in a particular language (where available). Note that,
    /// if locale is not supplied, or if the specified language is not available, all strings will be returned
    /// in the Spotify default language (American English). The locale parameter, combined with the country
    /// parameter, may give odd results if not carefully matched.
    /// For example country=SE&amp;locale=de_DE will return a list of categories relevant to Sweden but as German language strings.
    /// </summary>
    /// <value></value>
    [QueryParam("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first object). Use with limit to get the next set of items.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// A timestamp in ISO 8601 format: yyyy-MM-ddTHH:mm:ss. Use this parameter to specify the user’s
    /// local time to get results tailored for that specific date and time in the day. If not provided,
    /// the response defaults to the current UTC time. Example: “2014-10-23T09:00:00” for a user whose local
    /// time is 9AM. If there were no featured playlists (or there is no data) at the specified time,
    /// the response will revert to the current UTC time.
    /// </summary>
    /// <value></value>
    public DateTime? Timestamp { get; set; }

    [QueryParam("timestamp")]
    protected string? TimestampFormatted
    {
      get => Timestamp?.ToString("o", CultureInfo.InvariantCulture);
    }
  }
}

