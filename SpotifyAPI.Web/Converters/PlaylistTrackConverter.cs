using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Converters
{
  class PlaylistTrackConverter : JsonConverter
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

      var type = token["type"].Value<string>();
      if (type == "track")
      {
        var obj = new FullTrack();
        serializer.Populate(token.CreateReader(), obj);
        return obj;
      }
      else if (type == "episode")
      {
        var obj = new FullEpisode();
        serializer.Populate(token.CreateReader(), obj);
        return obj;
      }
      else
      {
        throw new Exception($"Received unkown playlist track type: {type}");
      }
    }

    public override void WriteJson(JsonWriter writer, object value,
        JsonSerializer serializer)
    {
      throw new NotSupportedException();
    }
  }
}
