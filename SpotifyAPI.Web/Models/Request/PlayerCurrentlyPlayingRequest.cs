using System;

namespace SpotifyAPI.Web
{
  public class PlayerCurrentlyPlayingRequest : RequestParams
  {
    public PlayerCurrentlyPlayingRequest(string market, AdditionalTypes types = AdditionalTypes.All)
    {
      Ensure.ArgumentNotNullOrEmptyString(market, nameof(market));
      Ensure.ArgumentNotNull(types, nameof(types));

      Market = market;
      AdditionalTypesParam = types;
    }

    [QueryParam("market")]
    public string Market { get; }

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

