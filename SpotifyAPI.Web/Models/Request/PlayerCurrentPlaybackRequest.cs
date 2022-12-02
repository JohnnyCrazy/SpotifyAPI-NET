using System;

namespace SpotifyAPI.Web
{
  public class PlayerCurrentPlaybackRequest : RequestParams
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="types">
    /// A comma-separated list of item types that your client supports besides the default track type.
    /// Valid types are: track and episode. An unsupported type in the response is expected to be represented
    /// as null value in the item field. Note: This parameter was introduced to allow existing clients to
    /// maintain their current behaviour and might be deprecated in the future. In addition to providing
    /// this parameter, make sure that your client properly handles cases of new types in the future by
    /// checking against the currently_playing_type field.
    /// </param>
    public PlayerCurrentPlaybackRequest(AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNull(types, nameof(types));

      AdditionalTypesParam = types;
    }

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

