using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web
{
  public class PlayableItemConverter : JsonConverter
  {
    public override bool CanWrite { get => false; }

    public override bool CanConvert(Type objectType) => true;

    public override object? ReadJson(JsonReader reader, Type objectType,
        object? existingValue, JsonSerializer serializer)
    {
      Ensure.ArgumentNotNull(serializer, nameof(serializer));

      if (JToken.ReadFrom(reader) is not JObject obj)
      {
        return null;
      }

      var type = obj.GetValue("type", StringComparison.OrdinalIgnoreCase)?.Value<string>();
      if (string.Equals(type, "track", StringComparison.OrdinalIgnoreCase))
      {
        var track = new FullTrack();
        serializer.Populate(obj.CreateReader(), track);
        return track;
      }
      else if (string.Equals(type, "episode", StringComparison.OrdinalIgnoreCase))
      {
        var episode = new FullEpisode();
        serializer.Populate(obj.CreateReader(), episode);
        return episode;
      }
      else
      {
        throw new APIException($@"Received unkown playlist element type: {type}.
If you're requesting a subset of available fields via the fields query paramter,
make sure to include at least the type field. Often it's `items(track(type))` or `item(type)`");
      }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
      throw new NotSupportedException();
    }
  }
}

