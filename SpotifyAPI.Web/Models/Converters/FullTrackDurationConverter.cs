using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web
{
  public class FullTrackDurationConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(int) || objectType == typeof(TimeSpan);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Integer)
      {
        // If the duration_ms is a simple integer, just read it
        return serializer.Deserialize(reader, typeof(int));
      }
      else if (reader.TokenType == JsonToken.StartObject)
      {
        // If not, unpack object
        JObject jsonObject = JObject.Load(reader);
        JToken totalMillisecondsToken = jsonObject["totalMilliseconds"];

        if (totalMillisecondsToken != null && totalMillisecondsToken.Type == JTokenType.Integer)
        {
          // Return totalMilliseconds as an integer
          return totalMillisecondsToken.Value<int>();
        }
      }

      throw new JsonSerializationException("Unexpected token or format for duration_ms");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value is int)
      {
        serializer.Serialize(writer, value);
      }
      else
      {
        throw new JsonSerializationException("Unexpected type for duration_ms");
      }
    }
  }
  }
}
