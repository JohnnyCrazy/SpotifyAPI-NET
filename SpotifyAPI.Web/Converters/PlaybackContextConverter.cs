using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Converters
{
  class PlaybackContextConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType) => true;

    public override object ReadJson(JsonReader reader, Type objectType,
        object existingValue, JsonSerializer serializer)
    {
      var token = JToken.ReadFrom(reader);
      if (token.Type == JTokenType.Null)
      {
        return null;
      }

      // Create an instance of MyClass, and set property as per "isFoo".
      var obj = new PlaybackContext();

      if (token["currently_playing_type"] != null)
      {
        var type = token["currently_playing_type"].Value<string>();
        if (type == "track")
        {
          obj.Item = new FullTrack();
        }
        else if (type == "episode")
        {
          obj.Item = new FullEpisode();
        }
        else
        {
          throw new Exception($"Received unkown currently playing type: {type}");
        }
      }

      // Populate properties
      serializer.Populate(token.CreateReader(), obj);
      return obj;
    }

    public override void WriteJson(JsonWriter writer, object value,
        JsonSerializer serializer)
    {
      throw new NotSupportedException();
    }
  }
}
