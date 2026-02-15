using System;

namespace SpotifyAPI.Web
{
  public class SearchRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="type">
    /// A comma-separated list of item types to search across.
    /// Valid types are: album , artist, playlist, track, show and episode.
    /// Search results include hits from all the specified item types.
    /// </param>
    /// <param name="query">
    /// Search query keywords and optional field filters and operators.
    /// </param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/search/search/
    /// </remarks>
    public SearchRequest(Types type, string query)
    {
      Ensure.ArgumentNotNull(type, nameof(type));
      Ensure.ArgumentNotNullOrEmptyString(query, nameof(query));

      Type = type;
      Query = query;
    }

    /// <summary>
    /// A comma-separated list of item types to search across.
    /// Valid types are: album , artist, playlist, track, show and episode.
    /// Search results include hits from all the specified item types.
    /// </summary>
    /// <value></value>
    [QueryParam("type")]
    public Types Type { get; set; }

    /// <summary>
    /// Search query keywords and optional field filters and operators.
    /// </summary>
    /// <value></value>
    [QueryParam("q")]
    public string Query { get; set; }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// If a country code is specified, only content that is playable in that market is returned.
    /// Note:
    /// - Playlist results are not affected by the market parameter.
    /// - If market is set to from_token, and a valid access token is
    ///  specified in the request header, only content playable in the country
    /// associated with the user account, is returned.
    /// - Users can view the country that is associated with their account in the
    /// account settings. A user must grant access to the user-read-private scope
    /// prior to when the access token is issued.
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
    /// Maximum number of results to return.
    /// Default: 5
    /// Minimum: 1
    /// Maximum: 10
    /// Note: The limit is applied within each type, not on the total response.
    /// For example, if the limit value is 3 and the type is artist,album,
    /// the response contains 3 artists and 3 albums.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first result to return.
    /// Default: 0 (the first result). Maximum offset (including limit): 2,000.
    /// Use with limit to get the next page of search results.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// Possible values: audio
    /// If include_external = audio is specified the response
    /// will include any relevant audio content that is hosted externally.
    /// By default external content is filtered out from responses.
    /// </summary>
    /// <value></value>
    [QueryParam("include_external")]
    public IncludeExternals? IncludeExternal { get; set; }

    [Flags]
    public enum IncludeExternals
    {
      [String("audio")]
      Audio = 1,
    }

    [Flags]
    public enum Types
    {
      [String("album")]
      Album = 1,
      [String("artist")]
      Artist = 2,
      [String("playlist")]
      Playlist = 4,
      [String("track")]
      Track = 8,
      [String("show")]
      Show = 16,
      [String("episode")]
      Episode = 32,
      All = Album | Artist | Playlist | Track | Show | Episode
    }
  }
}

