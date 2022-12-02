using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetItemsRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="types">
    /// A comma-separated list of item types that your client supports
    /// besides the default track type. Valid types are: track and episode.
    /// Note: This parameter was introduced to allow existing clients to maintain
    /// their current behaviour and might be deprecated in the future. In addition to
    /// providing this parameter, make sure that your client properly handles cases of new types in the
    ///  future by checking against the type field of each object. Defaults to ALL
    /// </param>
    public PlaylistGetItemsRequest(AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNull(types, nameof(types));

      AdditionalTypesParam = types;
      Fields = new List<string>();
    }

    /// <summary>
    /// Filters for the query: a comma-separated list of the fields to return.
    /// If omitted, all fields are returned. For example, to get just the total number of items and the request limit:
    /// fields=total,limit
    /// A dot separator can be used to specify non-reoccurring fields, while parentheses can be used to specify
    /// reoccurring fields within objects. For example, to get just the added date and user ID of the adder:
    /// fields=items(added_at,added_by.id)
    /// Use multiple parentheses to drill down into nested objects, for example:
    /// fields=items(track(name,href,album(name,href)))
    /// Fields can be excluded by prefixing them with an exclamation mark, for example:
    /// fields=items.track.album(!external_urls,images)
    /// </summary>
    /// <value></value>
    [QueryParam("fields")]
    public List<string> Fields { get; }

    /// <summary>
    /// The maximum number of items to return. Default: 100. Minimum: 1. Maximum: 100.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first object).
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking. For episodes, if a valid user access token is
    /// specified in the request header, the country associated with the user account will take priority over this
    /// parameter. Note: If neither market or user country are provided,
    /// the episode is considered unavailable for the client.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }

    /// <summary>
    /// The desired language, consisting of an ISO 639-1 language code and an ISO 3166-1 alpha-2 country code,
    /// joined by an underscore. For example: es_MX, meaning "Spanish (Mexico)".
    /// Provide this parameter if you want the category strings returned in a particular language.
    /// Note that, if locale is not supplied, or if the specified language is not available,
    /// the category strings returned will be in the Spotify default language (American English).
    /// </summary>
    /// <value></value>
    [QueryParam("locale")]
    public string? Locale { get; set; }

    /// <summary>
    ///   This is set to `"track", "episode"` by default.
    /// </summary>
    /// <value></value>
    [QueryParam("additional_types")]
    public AdditionalTypes AdditionalTypesParam { get; }

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

