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
        // If the duration_ms is an object, assume it's in the format {"totalMilliseconds": 188000}
        JObject jsonObject = JObject.Load(reader);
        JToken totalMillisecondsToken = jsonObject["totalMilliseconds"];

        if (totalMillisecondsToken != null && totalMillisecondsToken.Type == JTokenType.Integer)
        {
          // Convert totalMilliseconds to TimeSpan
          int totalMilliseconds = totalMillisecondsToken.Value<int>();
          return TimeSpan.FromMilliseconds(totalMilliseconds);
        }
      }

      throw new JsonSerializationException("Unexpected token or format for duration_ms");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value is int)
      {
        // If the value is an integer, write it as is
        serializer.Serialize(writer, value);
      }
      else if (value is TimeSpan)
      {
        // If the value is a TimeSpan, write it in the format {"totalMilliseconds": 188000}
        TimeSpan timeSpan = (TimeSpan)value;
        JObject jsonObject = new JObject(new JProperty("totalMilliseconds", (int)timeSpan.TotalMilliseconds));
        jsonObject.WriteTo(writer);
      }
      else
      {
        throw new JsonSerializationException("Unexpected type for duration_ms");
      }
    }
  }
}
