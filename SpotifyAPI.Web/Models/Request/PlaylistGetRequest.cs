using System;
using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PlaylistGetRequest : RequestParams
  {
    public PlaylistGetRequest(AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNull(types, nameof(types));

      AdditionalTypesParam = types;
      Fields = new List<string>();
    }

    /// <summary>
    /// Filters for the query: a comma-separated list of the fields to return.
    /// If omitted, all fields are returned. For example, to get just the playlist’s description and URI: fields=description,uri.
    /// A dot separator can be used to specify non-reoccurring fields,
    /// while parentheses can be used to specify reoccurring fields within objects.
    /// For example, to get just the added date and user ID of the adder:
    /// fields=tracks.items(added_at,added_by.id). Use multiple parentheses to drill down into nested objects, for example:
    /// fields=tracks.items(track(name,href,album(name,href))).
    /// Fields can be excluded by prefixing them with an exclamation mark, for example:
    /// fields=tracks.items(track(name,href,album(!name,href)))
    /// </summary>
    /// <value></value>
    [QueryParam("fields")]
    public List<string> Fields { get; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking.
    /// For episodes, if a valid user access token is specified in the request header,
    /// the country associated with the user account will take priority over this parameter.
    /// Note: If neither market or user country are provided, the episode is considered unavailable for the client.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; }

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

