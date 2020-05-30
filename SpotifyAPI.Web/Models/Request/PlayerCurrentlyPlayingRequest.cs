using System;

namespace SpotifyAPI.Web
{
  public class PlayerCurrentlyPlayingRequest : RequestParams
  {

    /// <summary>
    /// A comma-separated list of item types that your client supports besides the default track type.
    /// Valid types are: track and episode. An unsupported type in the response is expected to be represented
    /// as null value in the item field. Note: This parameter was introduced to allow existing clients to
    /// maintain their current behaviour and might be deprecated in the future. In addition to providing
    /// this parameter, make sure that your client properly handles cases of new types in the future by
    /// checking against the currently_playing_type field. Defaults to AdditionalTypes.All
    /// </summary>
    /// <param name="types"></param>
    public PlayerCurrentlyPlayingRequest(AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNull(types, nameof(types));

      AdditionalTypesParam = types;
    }

    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }

    /// <summary>
    /// A comma-separated list of item types that your client supports besides the default track type.
    /// Valid types are: track and episode. An unsupported type in the response is expected to be represented
    /// as null value in the item field. Note: This parameter was introduced to allow existing clients to
    /// maintain their current behaviour and might be deprecated in the future. In addition to providing
    /// this parameter, make sure that your client properly handles cases of new types in the future by
    /// checking against the currently_playing_type field. Defaults to AdditionalTypes.All
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

